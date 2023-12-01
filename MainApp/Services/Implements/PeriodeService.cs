
using System.Collections;
using System.Data.Common;
using MainApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MainApp;

public class PeriodeService : IPeriodeService
{
    private readonly ApplicationDbContext dbcontext;

    public PeriodeService(ApplicationDbContext _dbcontext)
    {
        dbcontext = _dbcontext;
    }

    public Task<bool> Delete(int id)
    {
        try
        {
            var item = dbcontext.DataPeriode.SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(item, "Data Tidak Ditemukan");
            dbcontext.DataPeriode.Remove(item);
            dbcontext.SaveChanges();
            return Task.FromResult(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<IEnumerable<Periode>> Get()
    {
        try
        {
            var data = dbcontext.DataPeriode.AsEnumerable();
            if (data == null)
                return Task.FromResult(Enumerable.Empty<Periode>());
            else
                return Task.FromResult(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Periode> GetActive()
    {
        var data = dbcontext.DataPeriode.SingleOrDefault(x => x.Status != Models.StatusKas.Setujui);
        return Task.FromResult(data);
    }

    public Task<Periode> GetById(int id)
    {
        try
        {
            var data = dbcontext.DataPeriode
                .Include(x => x.RencanaAnggaranBalanja)
                .ThenInclude(x => x.Akun).ThenInclude(x => x.Kategori)
                .SingleOrDefault(x => x.Id == id);
            return Task.FromResult(result: data)!;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Periode> Post(Periode model)
    {
        try
        {
            if (model.Tahun > DateTime.Now.Year)
                throw new SystemException("Belum saatnya membuat periode baru !");

            var oldPeriode = dbcontext.DataPeriode.OrderByDescending(x => x.Id).FirstOrDefault();
            if (oldPeriode != null)
            {
                if (oldPeriode.Status != Models.StatusKas.Setujui)
                    throw new SystemException("Periode Sebelumnya Belum Disetujui !");

                var lastPeriode = dbcontext.PeriodeKas.OrderByDescending(x => x.Id).First();
                lastPeriode.TanggalPenutupan = DateOnly.FromDateTime(DateTime.Now);
                oldPeriode.UtangAkhir = lastPeriode.Utang;
                oldPeriode.SaldoAkhir = lastPeriode.Saldo;
            }

            dbcontext.DataPeriode.Add(model);
            dbcontext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate key value"))
            {
                throw new Exception($"Periode Tahun {model.Tahun} Sudah Ada.");
            }
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<bool> Put(int id, Periode model)
    {
        try
        {

            if (model.Status == Models.StatusKas.Tutup)
            {
                var pKas = dbcontext.PeriodeKas.Where(x => x.PeriodeId == model.Id && x.Status != Models.StatusKas.Setujui).Count();
                if (pKas > 0)
                {
                    throw new SystemException("Ada Periode Kas Belum Di Setujui BPPK ");
                }
            }

            var data = dbcontext.DataPeriode.SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan");

            data.Tahun = model.Tahun;
            data.Status = model.Status;
            dbcontext.SaveChanges();
            return Task.FromResult(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public Task<bool> PutAnggaran(int id, Periode model)
    {
        try
        {
            var data = dbcontext.DataPeriode.Include(x => x.RencanaAnggaranBalanja).SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(data, "Data Tidak Ditemukan");
            dbcontext.Entry(data).CurrentValues.SetValues(model);
            dbcontext.SaveChanges();
            return Task.FromResult(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }


}

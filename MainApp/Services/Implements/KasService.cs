
using System.Collections;
using System.Data.Common;
using MainApp.Data;
using MainApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MainApp;

public class KasService : IKasService
{
    private readonly ApplicationDbContext dbcontext;

    public KasService(ApplicationDbContext _dbcontext)
    {
        dbcontext = _dbcontext;
    }

    public Task<bool> Delete(int id)
    {
        try
        {
            var item = dbcontext.DataKas.SingleOrDefault(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(item, "Data Tidak Ditemukan");
            dbcontext.DataKas.Remove(item);
            dbcontext.SaveChanges();
            return Task.FromResult(true);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<IEnumerable<Kas>> Get()
    {
        try
        {
            var data = dbcontext.DataKas.Include(x => x.Akun).ThenInclude(x => x.Kategori).AsEnumerable();
            if (data == null)
                return Task.FromResult(Enumerable.Empty<Kas>());
            else
                return Task.FromResult(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<IEnumerable<Kas>> Get(DateOnly start, DateOnly end)
    {
        try
        {
            var mulai = start.ToDateTime(new TimeOnly(0)).ToUniversalTime();
            var akhir = end.ToDateTime(new TimeOnly(0)).ToUniversalTime();
            var data = dbcontext.DataKas
                .Include(x => x.Akun).ThenInclude(x => x.Kategori)
                .Where(x => x.Tanggal.Value >= mulai && x.Tanggal.Value <= akhir)
                .AsEnumerable();
            if (data == null)
                return Task.FromResult(Enumerable.Empty<Kas>());
            else
                return Task.FromResult(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public Task<IEnumerable<Kas>> GetByYear(int year)
    {
        try
        {
            var data = dbcontext.DataKas.Where(x => x.Tanggal.Value.Year == year)
                .Include(x => x.Akun)
                .ThenInclude(x => x.Kategori).AsEnumerable();
            if (data == null)
                return Task.FromResult(Enumerable.Empty<Kas>());
            else
                return Task.FromResult(data);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Kas> GetById(int id)
    {
        try
        {
            var data = dbcontext.DataKas.Include(x => x.Akun).ThenInclude(x => x.Kategori).SingleOrDefault(x => x.Id == id);
            return Task.FromResult(result: data)!;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Task<Kas> Post(Kas model)
    {
        try
        {
            model.Tanggal = model.Tanggal.Value.ToUniversalTime();
            dbcontext.DataKas.Add(model);
            dbcontext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate key value"))
            {
                throw new Exception($"Kode : {model.Id} Sudah Ada.");
            }
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<bool> Put(int id, Kas model)
    {
        try
        {
            var data = dbcontext.DataKas.SingleOrDefault(x => x.Id == id);
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

    public Task<IEnumerable<PeriodeKas>> GetPeriodeKasByPeriodeId(int periodeId)
    {
        try
        {
            var periodes = dbcontext.PeriodeKas.Where(x => x.PeriodeId == periodeId);
            if (!periodes.Any())
                return Task.FromResult(Enumerable.Empty<PeriodeKas>());
            return Task.FromResult(periodes.AsEnumerable());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<PeriodeKas> GetPeriodeKasById(int id)
    {
        try
        {
            var periode = dbcontext.PeriodeKas.SingleOrDefault(x => x.Id == id);
            if (periode == null)
                throw new SystemException("Periode Kas Tidak Ditemukan !");
            return Task.FromResult(periode);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<PeriodeKas> GetActivePeriodeKas()
    {
        try
        {
            var p = dbcontext.DataPeriode.FirstOrDefault(x => x.Status == StatusKas.Baru);
            if (p == null)
                throw new SystemException("Tidak Ada Periode Tahun Buku Aktif ");

            var periode = dbcontext.PeriodeKas.Include(x=>x.Periode).FirstOrDefault(x => x.PeriodeId == p.Id && x.Status == StatusKas.Baru);
            return Task.FromResult(periode)!;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> TutupKas(PeriodeKas model, DateOnly tanggalPenutupan)
    {
        try
        {
            var p = dbcontext.DataPeriode.FirstOrDefault(x => x.Status == StatusKas.Baru);
            if (p == null)
                throw new SystemException("Tidak Ada Periode Tahun Buku Aktif ");

            var periode = dbcontext.PeriodeKas.FirstOrDefault(x => x.PeriodeId == p.Id && x.Status == StatusKas.Baru);
            if (periode == null)
                throw new SystemException("Periode Kas Tidak Ditemukan !");
            var kas = await Get(periode.Mulai, periode.Berakhir);
            periode.Penerimaan = kas.Where(x => x.Akun.Tipe == AkunType.Penerimaan).Sum(x => x.Jumlah);
            periode.Pengeluaran = kas.Where(x => x.Akun.Tipe == AkunType.Pengeluaran).Sum(x => x.Jumlah);
            periode.Sinode = kas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.Sinode > 0).Sum(x => x.Jumlah * x.Akun.Sinode / 100);
            periode.Klasis = kas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.Klasis > 0).Sum(x => x.Jumlah * x.Akun.Klasis / 100);
            periode.YPK = kas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.YPK > 0).Sum(x => x.Jumlah * x.Akun.YPK / 100);
            periode.Jemaat = kas.Where(x => x.Akun.Tipe == AkunType.Penerimaan && x.Akun.Jemaat > 0).Sum(x => x.Jumlah * x.Akun.Jemaat / 100);
            periode.PembayaranUtang = kas.Where(x => x.Akun.Tipe == AkunType.Pengeluaran && x.Akun.SetoranWajib).Sum(x => x.Jumlah);
            periode.TanggalPenutupan = tanggalPenutupan;
            periode.Status = StatusKas.Tutup;
            dbcontext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<PeriodeKas> BuatKasBaru(PeriodeKas periodeKas)
    {
        try
        {
            var p = dbcontext.DataPeriode.SingleOrDefault(x => x.Status == StatusKas.Baru);
            if (p == null)
                throw new SystemException("Tidak Ada Periode Tahun Buku Aktif ");


            if(periodeKas.Mulai.Year != p.Tahun || periodeKas.Berakhir.Year != p.Tahun)
                throw new SystemException("Tanggal Muilai dan Akhir tiddak valid !");

            var periode = dbcontext.PeriodeKas.SingleOrDefault(x => x.PeriodeId == p.Id && x.Status == StatusKas.Baru);
            if (periode != null)
                throw new SystemException("Periode Kas Belum Ditutup !");

            var last = dbcontext.PeriodeKas.Where(x => x.PeriodeId == p.Id).OrderByDescending(x => x.Id).Take(1);
            if (last.Any())
            {
                if (last.First().Bulan >= periodeKas.Bulan)
                {
                    throw new SystemException("Periode Bulan Harus Lebih Besar Dari Periode Sebelumnya !");
                }

                periodeKas.SaldoLalu = last.First().Saldo;
                periodeKas.UtangLalu = last.First().Utang;
            }
            else
            {
                var px = dbcontext.DataPeriode.Where(x => x.Status != StatusKas.Baru).OrderByDescending(x => x.Id).Take(1);
                if (px.Any())
                {
                    periodeKas.SaldoLalu = px.First().SaldoAkhir;
                    periodeKas.UtangLalu = px.First().UtangAkhir;
                }
            }

            periodeKas.Periode = p;
            dbcontext.PeriodeKas.Add(periodeKas);
            dbcontext.SaveChanges();
            return Task.FromResult(periodeKas);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public Task<PeriodeKas> GetLastPeriodeKas(PeriodeKas periode)
    {
        try
        {
            var p = dbcontext.PeriodeKas.Where(x => x.Id < periode.Id && periode.PeriodeId == periode.PeriodeId)
                .OrderByDescending(x=>x.Id).FirstOrDefault();
            return Task.FromResult(p);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public Task<IEnumerable<PeriodeKas>> GetPeriodeKasForPosisiKas()
    {
        try
        {
            var p = dbcontext.DataPeriode.SingleOrDefault(x => x.Status == StatusKas.Baru);
            if (p == null)
                throw new SystemException("Tidak Ada Periode Tahun Buku Aktif ");

            var periodes = dbcontext.PeriodeKas.OrderByDescending(x => x.Id).Take(2);
            if (!periodes.Any())
                throw new SystemException($"Periode Kas Tahun Buku {p.Tahun} Belum Ada !");


            return Task.FromResult(periodes.AsEnumerable());

        }
        catch (Exception)
        {

            throw;
        }
    }

    public Task<bool> PersetujuanPeriodeKas(PeriodeKas model)
    {
        try
        {
            var result = dbcontext.PeriodeKas.ExecuteUpdate(x => x.SetProperty(x => x.Status, model.Status));
            return Task.FromResult(result > 0);
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}

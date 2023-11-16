
using System.Collections;
using System.Data.Common;
using MainApp.Data;
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
            var data = dbcontext.DataKas.Include(x=>x.Akun).ThenInclude(x=>x.Kategori).AsEnumerable();
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
            var data = dbcontext.DataKas.Where(x=>x.Tanggal.Value.Year==year).Include(x => x.Akun).ThenInclude(x => x.Kategori).AsEnumerable();
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
            if(ex.InnerException!=null && ex.InnerException.Message.Contains("duplicate key value"))
            {
                throw new Exception($"Kode : {model.Id} Sudah Ada.");
            }
            throw;
        }
        catch (Exception){
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
}

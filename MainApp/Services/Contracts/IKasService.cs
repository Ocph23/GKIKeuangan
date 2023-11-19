using MainApp.Models;

namespace MainApp;

public interface IKasService
{
    Task<IEnumerable<Kas>> Get();
    Task<Kas> GetById(int id);
    Task<IEnumerable<Kas>> GetByYear(int year);
    Task<IEnumerable<Kas>> Get(DateOnly start , DateOnly end);
    Task<Kas> Post(Kas model);
    Task<bool> Put(int id, Kas model);
    Task<bool> Delete(int id);

    Task<IEnumerable<PeriodeKas>> GetPeriodeKasByPeriodeId(int periodeId);
    Task<IEnumerable<PeriodeKas>> GetPeriodeKasForPosisiKas();
    Task<PeriodeKas> GetPeriodeKasById(int id);
    Task<PeriodeKas> GetActivePeriodeKas();
    Task<bool> TutupKas(PeriodeKas model, DateOnly tanggalPenutupan);
    Task<PeriodeKas> BuatKasBaru(PeriodeKas model);
}

﻿namespace MainApp;

public interface IPeriodeService
{
    Task<IEnumerable<Periode>> Get();
    Task<Periode> GetById(int id);
    Task<Periode> GetActive();
    Task<Periode> Post(Periode model);
    Task<bool> Put(int id, Periode model);
    Task<bool> PutAnggaran(int id, Periode model);
    Task<bool> Delete(int id);
}

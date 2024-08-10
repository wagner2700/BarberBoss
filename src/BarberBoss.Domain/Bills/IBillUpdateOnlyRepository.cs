﻿using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Bills
{
    public interface IBillUpdateOnlyRepository
    {
        void Update(Fatura fatura);
        Task<Fatura?> GetById(long id);
    }
}

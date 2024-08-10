﻿using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Entities
{
    public class Fatura
    {
        public long Id { get; set; }    
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public TipoPagamento TipoPagamento { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}

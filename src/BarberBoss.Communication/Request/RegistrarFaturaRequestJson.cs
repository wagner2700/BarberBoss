﻿using BarberBoss.Domain.Enums;

namespace BarberBoss.Communication.Request
{
    public class RegistrarFaturaRequestJson
    {
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public TipoPagamento TipoPagamento { get; set; }
    }
}

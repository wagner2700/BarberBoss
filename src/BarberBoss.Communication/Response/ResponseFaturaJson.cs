namespace BarberBoss.Communication.Response
{
    public  class ResponseFaturaJson
    {
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}

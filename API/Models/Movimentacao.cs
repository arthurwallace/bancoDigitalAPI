namespace bancodigital_api.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Descricao { get; set; }
        public Conta Conta { get; set; }
    }
}

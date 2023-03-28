namespace bancodigital_api.Models
{
   public class Conta
    {
        public Guid? id { get; set; }
         public int numeroConta { get; set; }
        public decimal saldo { get; set; }
        public List<Movimentacao> movimentacoes { get; set; }
    }
}

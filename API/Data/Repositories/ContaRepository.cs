using bancodigital_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bancodigital_api.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly AppDbContext _context;

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Conta> GetContas()
        {
            return _context.Contas.Include(o => o.movimentacoes).ToList();
        }

        public Conta GetConta(int numeroConta)
        {
            return _context.Contas.Include(o => o.movimentacoes).FirstOrDefault(c => c.numeroConta == numeroConta);
        }
        public Conta CriarConta()
        {
            var conta = new Conta{
                id = Guid.NewGuid(),
                saldo = 0
            };

            var numconta = new Random().Next(10000, 99999);

            while(GetConta(numconta) != null){
                numconta = new Random().Next(10000, 99999);
            }
            
            conta.numeroConta = numconta;

            _context.Contas.Add(conta);
            _context.SaveChanges();
            return conta;
        }

        public void AtualizarSaldo(Conta conta)
        {
            _context.Contas.Update(conta);
            _context.SaveChanges();
        }

        public void CriarMovimentacao(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            _context.SaveChanges();
        }
    }
}

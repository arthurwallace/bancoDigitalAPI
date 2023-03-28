using bancodigital_api.Models;

namespace bancodigital_api.Data.Repositories
{
    public interface IContaRepository
    {
        List<Conta> GetContas();
        Conta GetConta(int id);
        Conta CriarConta();
        void AtualizarSaldo(Conta conta);
        void CriarMovimentacao(Movimentacao movimentacao);
    }
}

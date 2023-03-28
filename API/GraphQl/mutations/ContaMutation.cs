using bancodigital_api.Data;
using bancodigital_api.Data.Repositories;
using bancodigital_api.Models;

namespace bancodigital_api.GraphQl.mutations
{
    public class ContaMutation
    {
        [GraphQLName("sacar")]
        public Conta Sacar([Service] IContaRepository contaRepository, int numeroConta, decimal valor)
        {
            var conta = contaRepository.GetConta(numeroConta);
            if (conta == null)
            {
                throw new GraphQLException("Conta não encontrada.");
            }
            if (valor <= 0)
            {
                throw new GraphQLException("Valor inválido.");
            }
            if (valor > conta.saldo)
            {
                throw new GraphQLException("Saldo insuficiente.");
            }
            var movimentacao = new Movimentacao
            {
                Conta = conta,
                Valor = valor,
                DataMovimentacao = DateTime.Now,
                Descricao = "Saque"
            };

            contaRepository.CriarMovimentacao(movimentacao);

            conta.saldo -= valor;
            contaRepository.AtualizarSaldo(conta);

            return conta;
        }

        [GraphQLName("depositar")]
        public Conta Depositar([Service] IContaRepository contaRepository, int numeroConta, decimal valor)
        {
            var conta = contaRepository.GetConta(numeroConta);
            if (conta == null)
            {
                throw new GraphQLException("Conta não encontrada.");
            }
            if (valor <= 0)
            {
                throw new GraphQLException("Valor inválido.");
            }
            var movimentacao = new Movimentacao
            {
                Conta = conta,
                Valor = valor,
                DataMovimentacao = DateTime.Now,
                Descricao = "Depósito"
            };

            contaRepository.CriarMovimentacao(movimentacao);

            conta.saldo += valor;
            
            contaRepository.AtualizarSaldo(conta);

            return conta;
        }

        [GraphQLName("criar")]
        public Conta CriarConta([Service] IContaRepository contaRepository)
        {
            var conta = contaRepository.CriarConta();

            return conta;
        }
    }
}

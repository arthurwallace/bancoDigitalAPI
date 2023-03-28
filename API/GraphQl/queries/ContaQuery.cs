using bancodigital_api.Data.Repositories;
using GraphQL;
using GraphQL.Types;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using bancodigital_api.Data;
using bancodigital_api.Models;

namespace bancodigital_api.GraphQl.queries
{
    public partial class Query
    {
        public IQueryable<Conta> GetContas([Service] IContaRepository contaRepository)
        {
            return contaRepository.GetContas().AsQueryable();
        }

        public Conta GetConta(int numeroConta, [Service] IContaRepository contaRepository)
        {
            return contaRepository.GetConta(numeroConta);
        }

        public decimal GetSaldo(int numeroConta, [Service] IContaRepository contaRepository)
        {
            var conta = contaRepository.GetConta(numeroConta);
            return conta.saldo;
        }
    }
}

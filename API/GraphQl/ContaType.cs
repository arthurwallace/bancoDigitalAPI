using bancodigital_api.Models;
using GraphQL.Types;

namespace bancodigital_api.GraphQl
{
    public class ContaType : ObjectGraphType<Conta>
    {
        public ContaType()
        {
            Field(x => x.id, type: typeof(GuidGraphType)).Description("Id da conta");
            Field(x => x.numeroConta).Description("Número da conta");
            Field(x => x.saldo).Description("Saldo da conta");
        }
    }
}

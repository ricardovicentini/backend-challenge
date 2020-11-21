using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Linq.Expressions;

namespace PedidosME.Domain.Entities.Specifications
{
    public class PedidoAprovadoValorAMenor : IRule<Pedido>
    {
        private readonly AtualizarStatusDTO atualizarStatusDTO;

        public PedidoAprovadoValorAMenor(AtualizarStatusDTO atualizarStatusDTO)
        {
            this.atualizarStatusDTO = atualizarStatusDTO;
        }
        public Expression<Func<Pedido, bool>> RuleExpression => f => f != null &&
                       atualizarStatusDTO.ValorAprovado < f.ValorTotal() &&
                       atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();

        public string ObterStatus(Pedido entity)
        {
            return RuleExpression.Compile().Invoke(entity) ?
                StatusPedidoEnum.APROVADO_VALOR_A_MENOR.ToString() : "";
        }
    }
}

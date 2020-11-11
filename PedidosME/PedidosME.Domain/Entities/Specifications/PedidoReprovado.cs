using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Linq.Expressions;

namespace PedidosME.Domain.Entities.Specifications
{
    public class PedidoReprovado : IRule<Pedido>
    {
        private readonly AtualizarStatusDTO _atualizarStatusDTO;

        public PedidoReprovado(AtualizarStatusDTO atualizarStatusDTO)
        {
            _atualizarStatusDTO = atualizarStatusDTO;
        }

        public Expression<Func<Pedido, bool>> RuleExpression =>
            pedidoReprovado => pedidoReprovado != null && 
            _atualizarStatusDTO.Status == StatusPedidoEnum.REPROVADO.ToString();

        public string ObterStatus(Pedido entity)
        {
            return RuleExpression.Compile().Invoke(entity) ? 
                StatusPedidoEnum.REPROVADO.ToString() : 
                String.Empty;
        }
    }
}

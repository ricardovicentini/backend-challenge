using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PedidosME.Domain.Entities.Specifications
{
    public class PedidoAprovado : IRule<Pedido>
    {
        private readonly AtualizarStatusDTO _atualizarStatusDTO;

        public PedidoAprovado(AtualizarStatusDTO atualizarStatusDTO)
        {
            _atualizarStatusDTO = atualizarStatusDTO;
            
        }
        public Expression<Func<Pedido, bool>> RuleExpression => p => p != null &&
                        _atualizarStatusDTO.ItensAprovados == p.QuantidadeItens() &&
                        _atualizarStatusDTO.ValorAprovado == p.ValorTotal() &&
                        _atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();

        public string ObterStatus(Pedido entity)
        {
            return RuleExpression.Compile().Invoke(entity) ? StatusPedidoEnum.APROVADO.ToString() : "";
        }
    }
}

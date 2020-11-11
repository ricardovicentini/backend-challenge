using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PedidosME.Domain.Entities.Specifications
{
    public class PedidoAprovadoQuantidadeAMaior : IRule<Pedido>
    {
        private readonly AtualizarStatusDTO atualizarStatusDTO;

        public PedidoAprovadoQuantidadeAMaior(AtualizarStatusDTO atualizarStatusDTO)
        {
            this.atualizarStatusDTO = atualizarStatusDTO;
        }
        public Expression<Func<Pedido, bool>> RuleExpression => p => p != null &&
                        atualizarStatusDTO.ItensAprovados > p.QuantidadeItens() &&
                        atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();

        public string ObterStatus(Pedido entity)
        {
            return RuleExpression.Compile().Invoke(entity) ?
                StatusPedidoEnum.APROVADO_QTD_A_MENOR.ToString() : "";
        }
    }
}

using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PedidosME.Domain.Entities.Specifications
{
    public class PedidoInvalido : IRule<Pedido>
    {
        public Expression<Func<Pedido, bool>> RuleExpression =>
            p => p == null;

        public string ObterStatus(Pedido entity)
        {
            if (RuleExpression.Compile().Invoke(entity))
                return StatusPedidoEnum.CODIGO_PEDIDO_INVALIDO.ToString();

            return String.Empty;
        }
    }
}

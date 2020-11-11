using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Domain.Entities.Specifications
{
    public enum StatusPedidoEnum
    {
        CODIGO_PEDIDO_INVALIDO = 1,
        REPROVADO = 2,
        APROVADO = 3,
        APROVADO_VALOR_A_MENOR = 4,
        APROVADO_QTD_A_MENOR = 5,
        APROVADO_VALOR_A_MAIOR = 6,
        APROVADO_QTD_A_MAIOR = 7

    }
}

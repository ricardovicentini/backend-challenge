

using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System.Collections.Generic;


namespace PedidosME.Domain.Entities.Specifications
{
    public class StatusPedido2 
    {
        private readonly AtualizarStatusDTO _atualizarStatusDTO;
        private readonly List<IRule<Pedido>> rules = new List<IRule<Pedido>>();




        public StatusPedido2(AtualizarStatusDTO atualizarStatusDTO)
        {
            _atualizarStatusDTO = atualizarStatusDTO;
            rules.Add(new PedidoInvalido());
            rules.Add(new PedidoReprovado(_atualizarStatusDTO));
            rules.Add(new PedidoAprovado(_atualizarStatusDTO));
            rules.Add(new PedidoAprovadoQuantidadeAMaior(_atualizarStatusDTO));
            rules.Add(new PedidoAprovadoQuantidadeAMenor(_atualizarStatusDTO));
            rules.Add(new PedidoAprovadoValorAMaior(_atualizarStatusDTO));
            rules.Add(new PedidoAprovadoValorAMenor(_atualizarStatusDTO));

        }

        public IEnumerable<string> ClassificarPedido(Pedido pedido)
        {
            List<string> status = new List<string>();
            foreach (var rule in rules)
            {
                var result = rule.ObterStatus(pedido);
                if(!string.IsNullOrEmpty(result))
                    status.Add(result);
            }
            return status;
        }


    }
}

using MediatR;
using PedidosME.Domain.DTOs;
using PedidosME.Domain.Entities.PedidoAggregate;
using PedidosME.Domain.Entities.Specifications;
using PedidosME.Domain.Events;
using PedidosME.Domain.PedidoAggregate.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Domain.Services
{
    public class PedidoServices : IPedidoServices
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IMediator mediator;
        
        public PedidoServices(IPedidoRepository pedidoGenericRepository, IMediator mediator)
        {
            this.pedidoRepository = pedidoGenericRepository;
            this.mediator = mediator;
        }

        public async Task<StatusPedidoDTO> DefinirStatusPedido(AtualizarStatusDTO atualizarStatusDTO, CancellationToken cancellationToken)
        {
            
            var pedido = await pedidoRepository.ObterPedidoPorCodigoAsync(atualizarStatusDTO.pedido, cancellationToken);

            //var statusPedido = new StatusPedido(atualizarStatusDTO).ObterStatus(pedido);
            var statusPedido = new StatusPedido2(atualizarStatusDTO).ClassificarPedido(pedido);
            return new StatusPedidoDTO()
            {
                Pedido = pedido?.Codigo ?? atualizarStatusDTO.pedido,
                Status = statusPedido.ToList()
            };

            
        }

        public async Task<Pedido> ObterPedido(string codigoPedido, CancellationToken cancellationToken)
        {
            var pedido = await pedidoRepository.ObterPedidoPorCodigoAsync(codigoPedido, cancellationToken);
            await mediator.Publish(new PedidoConsultadoEvent(pedido));
            return pedido;
        }

        
    }
}

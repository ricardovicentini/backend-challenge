
using PedidosME.Domain.PedidoAggregate.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Domain.Entities.PedidoAggregate
{
    public interface IPedidoRepository 
    {
        Task<Pedido> ObterPedidoPorCodigoAsync(string codigoPedido, CancellationToken cancellationToken);
    }
}

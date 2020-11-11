using PedidosME.Domain.Entities.Core;
using System;
using System.Linq.Expressions;

namespace PedidosME.Domain.Entities.Specifications
{
    public interface IRule<TEntity> where TEntity : Entity
    {

        Expression<Func<TEntity, bool>> RuleExpression { get; }
        string ObterStatus(TEntity entity);
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BartenderApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICocktailRepository Cocktail { get; }
        IOrderRepository Order { get; }

        ISP_Call SP_Call { get; }

        void Save();
    }
}

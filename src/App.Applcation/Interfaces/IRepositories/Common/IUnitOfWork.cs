using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Interfaces.IRepositories.Common
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        Task<int> Save(CancellationToken cancellationToken);
    }
}

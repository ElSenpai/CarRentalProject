using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserOperationDal : IEntityRepository<UserOperationClaim>
    {
    }
}

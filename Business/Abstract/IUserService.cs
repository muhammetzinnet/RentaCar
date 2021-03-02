using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{

    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);

        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }

}

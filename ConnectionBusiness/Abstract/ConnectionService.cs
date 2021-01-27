
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConnectionBusiness.Abstract
{
    public interface ConnectionService
    {
        IDataResult<List<Client>> Get();
        IDataResult<Client> GetById(Guid id);
        IDataResult<Client> GetByGroup(Guid groupId);
        IDataResult<List<Client>> GetOnline();
        IDataResult<List<Client>> GetOffline();
        IDataResult<Client> Add(Client client);
        IResult AddRange(List<Client> clients);
        IResult Delete(Client client);
        IResult Update(Client client);

    }
}

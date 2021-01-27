using ConnectionBusiness.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConnectionBusiness.Concrete
{
    public class ClientManager : IClientService
    {
        private readonly IClientDal _clientDal;
        public ClientManager(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }

        public IDataResult<List<Client>> Get()
        {
            throw new NotImplementedException();
        }
        public IDataResult<Client> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public IDataResult<Client> GetByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<Client>> GetOffline()
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<Client>> GetOnline()
        {
            throw new NotImplementedException();
        }
        public IDataResult<Client> Add(Client client)
        {
            throw new NotImplementedException();
        }
        public IResult AddRange(List<Client> clients)
        {
            throw new NotImplementedException();
        }      
        public IResult Update(Client client)
        {
            throw new NotImplementedException();
        }
        public IResult Delete(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

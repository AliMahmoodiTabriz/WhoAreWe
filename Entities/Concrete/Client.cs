using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Client : IEntity
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public bool OnlineState { get; set; }
        public DateTime LostOnlineTime { get; set; }
        public DateTime UpTime { get; set; }
    }
}

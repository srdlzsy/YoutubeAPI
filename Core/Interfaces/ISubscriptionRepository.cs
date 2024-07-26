using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Task SubscribeAsync(int subscriberId, int channelId);

    }
}

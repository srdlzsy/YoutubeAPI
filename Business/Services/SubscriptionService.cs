using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SubscriptionService : BaseService<Subscription>
    {
        private ISubscriptionRepository _subscriptionRepository;
        public SubscriptionService(IRepository<Subscription> repository, ISubscriptionRepository subscriptionRepository) : base(repository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public Task SubscribeAsync(int subscriberId, int channelId)
        {
            return _subscriptionRepository.SubscribeAsync(subscriberId, channelId);
        }
    }
}

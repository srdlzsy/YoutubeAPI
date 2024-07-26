using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(MyContext context) : base(context)
        {

        }

        public async Task SubscribeAsync(int subscriberId, int channelId)
        {
            // Yeni bir Subscription nesnesi oluşturun
            var subscription = new Subscription
            {
                SubscriberId = subscriberId,
                ChannelId = channelId,
                SubscribedOn = DateTime.UtcNow // Opsiyonel olarak abone olma tarihini ekleyebilirsiniz
            };

            // Subscription nesnesini veritabanına ekleyin
            await _context.Subscriptions.AddAsync(subscription);

            // Veritabanındaki değişiklikleri kaydedin
            await _context.SaveChangesAsync();
        }
    }
    }

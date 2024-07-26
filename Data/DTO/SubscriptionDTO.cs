using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class SubscriptionDTO
    {
        public int SubscriberId { get; set; }  // Abonelik yapan kullanıcının ID'si
        public int ChannelId { get; set; }  // Abonelik yapılan kanalın ID'si
    }
}

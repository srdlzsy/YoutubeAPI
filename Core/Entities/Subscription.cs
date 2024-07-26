using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }  // Abonelik yapan kullanıcının ID'si
        public AppUser Subscriber { get; set; }  // Abonelik yapan kullanıcı
        public int ChannelId { get; set; }  // Abonelik yapılan kanalın ID'si
        public AppUser Channel { get; set; }  // Abonelik yapılan kanal (kullanıcı) 
        public DateTime SubscribedOn { get; set; }  // Abonelik tarihi
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Entities
{
    public class AppUser : IdentityUser<int>
    {

     
        
            public ICollection<Video> Videos { get; set; } = new List<Video>();
            public ICollection<Comment> Comments { get; set; } = new List<Comment>();
            public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        

    }
}

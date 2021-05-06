using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeDI.Models
{
    public class CurrentUser : ICurrentUser
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}

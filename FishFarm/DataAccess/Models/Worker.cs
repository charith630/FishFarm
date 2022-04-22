using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Worker
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Position { get; set; }
        public DateTime CertifiedUntil { get; set; }
        public string Image { get; set; }

        public virtual Farm Farm { get; set; }
    }
}

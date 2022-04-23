using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Response
{
    public class FarmWorker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime CertifiedUntil { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Request
{
    public class WorkerRequest
    {
        public int FarmId { get; set; }
        public string Name { get; set; }        
        public int  Age { get; set; }
        public string Email { get; set; }
        public string Workerposition { get; set; }
        public DateTime CertifiedUntil { get; set; }
    }
}

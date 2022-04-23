using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IWorkerService
    {
        public bool RegisterWorker();

        public void GetWokersByFarmId(int farmId);
    }
}

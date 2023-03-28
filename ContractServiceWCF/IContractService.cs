using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Diagnostics.Contracts;

namespace ContractServiceWCF
{
    [ServiceContract]
    public interface IContractService
    {
        [OperationContract]
        IEnumerable<Contract> GetContracts();
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContosoConsultancy.Administration.UI
{
    public class ContractService : IContractService
    {
        public List<string> ListContractTemplates()
        {
            return Directory.GetFiles("Contracts/").Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
        }
    }
}

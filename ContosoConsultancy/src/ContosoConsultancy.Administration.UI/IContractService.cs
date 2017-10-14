using ContosoConsultancy.Administration.UI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoConsultancy.Administration.UI
{
    public interface IContractService
    {
        List<string> ListContractTemplates();
        string GetContractContent(string contractTemplate, ContractData contractData);
        Task<string> GetContractContentAsync(string contractTemplate, ContractData contractData);
    }
}
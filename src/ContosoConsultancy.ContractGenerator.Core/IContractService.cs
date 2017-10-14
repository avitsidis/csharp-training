using ContosoConsultancy.ContractGenerator.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoConsultancy.ContractGenerator.Core
{
    public interface IContractService
    {
        List<string> ListContractTemplates();
        string GetContractContent(string contractTemplate, ContractData contractData);
        Task<string> GetContractContentAsync(string contractTemplate, ContractData contractData);
    }
}
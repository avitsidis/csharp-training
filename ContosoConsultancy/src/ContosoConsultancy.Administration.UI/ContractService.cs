using ContosoConsultancy.Administration.UI.Model;
using Nustache.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoConsultancy.Administration.UI
{
    public class ContractService : IContractService
    {
        private const string CONTRACT_FOLDER = "Contracts/";

        public List<string> ListContractTemplates()
        {
            return Directory.GetFiles(CONTRACT_FOLDER).Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
        }

        private string GetPathFromTemplateName(string templateName)
        {
            return Directory.GetFiles(CONTRACT_FOLDER)
                .Single(f => Path.GetFileNameWithoutExtension(f) == templateName);
        }

        public string GetContractContent(string contractTemplate,ContractData contractData)
        {
            var templateFilename = GetPathFromTemplateName(contractTemplate);
            return Render.FileToString(templateFilename, contractData, new RenderContextBehaviour { RaiseExceptionOnDataContextMiss = true});
        }

        public async Task<string> GetContractContentAsync(string contractTemplate, ContractData contractData)
        {
            var templateFilename = GetPathFromTemplateName(contractTemplate);
            using (var sr = File.OpenText(templateFilename))
            {
                var templateString = await sr.ReadToEndAsync();
                return Render.StringToString(templateString, contractData, new RenderContextBehaviour { RaiseExceptionOnDataContextMiss = true });
            }
        }
    }
}

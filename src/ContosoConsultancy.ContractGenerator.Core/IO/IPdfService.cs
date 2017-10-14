using System.IO;
using System.Threading.Tasks;

namespace ContosoConsultancy.ContractGenerator.Core.IO
{
    public interface IPdfService
    {
        Task WriteTextToPdfStreamAsync(Stream destination, string content);
    }
}
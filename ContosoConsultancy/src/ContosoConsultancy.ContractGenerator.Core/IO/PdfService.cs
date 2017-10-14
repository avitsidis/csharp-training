using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoConsultancy.ContractGenerator.Core.IO
{
    public class PdfService : IPdfService
    {
        public async Task WriteTextToPdfStreamAsync(Stream destination, string content)
        {
            using (var writer = new PdfWriter(destination))
            {
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                var paragraphs = content.Split('\n').Select(line => new Paragraph(line));
                foreach (var paragraph in paragraphs)
                {
                    document.Add(paragraph);
                }
                document.Close();
                await writer.FlushAsync();
            }
        }
    }
}

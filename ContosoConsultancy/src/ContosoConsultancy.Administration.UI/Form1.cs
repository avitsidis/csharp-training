using ContosoConsultancy.Administration.UI.Model;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContosoConsultancy.Administration.UI
{
    public partial class Form1 : Form
    {
        private readonly ContosoConsultancyServiceProxy contosoConsultancyServiceProxy;
        private readonly IContractService contractService;

        public Form1(ContosoConsultancyServiceProxy contosoConsultancyServiceProxy, IContractService contractService)
        {
            InitializeComponent();
            this.contosoConsultancyServiceProxy = contosoConsultancyServiceProxy;
            this.contractService = contractService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultantCb.DataSource = contosoConsultancyServiceProxy.FetchConsultants();
            customerCb.DataSource = contosoConsultancyServiceProxy.FetchCustomers();
            contractCb.DataSource = contractService.ListContractTemplates();
        }

        private void generateContractButton_Click(object sender, EventArgs e)
        {

        }

        private ContractData GetContractDataFromForm()
        {
            return new ContractData
            {
                Customer = customerCb.SelectedValue.ToString(),
                StartDate = startDp.Value.ToShortDateString(),
                EndDate = endDp.Value.ToShortDateString(),
                Rate = rateNud.Value.ToString(),
                ConsultantName = consultantCb.SelectedValue.ToString()
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var timeout = 5000/*ms*/;
            var result = saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                try
                {
                    var contractData = GetContractDataFromForm();
                    var contractTemplate = contractCb.SelectedValue.ToString();
                    var content = contractService.GetContractContent(contractTemplate, contractData);
                    using (var fs = saveFileDialog1.OpenFile())
                    {
                        WriteContract(fs, content).Wait(timeout);
                        toolStripStatusLabel1.Text = "Contract Successfully Generated";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error during contract creation");
                }

            }
        }

        private async Task WriteContract(Stream destination, string content)
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

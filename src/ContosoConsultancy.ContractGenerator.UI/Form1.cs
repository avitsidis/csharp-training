using ContosoConsultancy.ContractGenerator.Core;
using ContosoConsultancy.ContractGenerator.Core.IO;
using ContosoConsultancy.ContractGenerator.Core.Model;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContosoConsultancy.ContractGenerator.UI
{
    public partial class Form1 : Form
    {
        private readonly ContosoConsultancyServiceProxy contosoConsultancyServiceProxy;
        private readonly IContractService contractService;
        private readonly IPdfService pdfService;

        public Form1(ContosoConsultancyServiceProxy contosoConsultancyServiceProxy, IContractService contractService, IPdfService pdfService)
        {
            InitializeComponent();
            this.contosoConsultancyServiceProxy = contosoConsultancyServiceProxy;
            this.contractService = contractService;
            this.pdfService = pdfService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultantCb.DataSource = contosoConsultancyServiceProxy.FetchConsultants();
            customerCb.DataSource = contosoConsultancyServiceProxy.FetchCustomers();
            contractCb.DataSource = contractService.ListContractTemplates();
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
            var result = saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                GenerateContract();
            }
        }

        private void GenerateContract()
        {
            try
            {
                var content = BuildContractContent();
                using (var fs = saveFileDialog1.OpenFile())
                {
                    WriteContract(fs, content);
                    MessageBox.Show("Contract Successfully Generated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error during contract creation");
            }
        }

        private void WriteContract(Stream destination, string content)
        {
            var timeout = 10000/*ms*/;
            pdfService.WriteTextToPdfStreamAsync(destination, content).Wait(timeout);
        }

        private async Task WriteContractAsync(Stream destination, string content)
        {
            await pdfService.WriteTextToPdfStreamAsync(destination, content);
        }

        private string BuildContractContent()
        {
            var contractData = GetContractDataFromForm();
            var contractTemplate = contractCb.SelectedValue.ToString();
            var content = contractService.GetContractContent(contractTemplate, contractData);
            return content;
        }
    }
}

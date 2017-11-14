using ContosoConsultancy.ContractGenerator.Core;
using ContosoConsultancy.ContractGenerator.Core.IO;
using ContosoConsultancy.ContractGenerator.Core.Model;
using System;
using System.Collections.Generic;
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            consultantCb.DataSource = new List<string> {"Loading..." };
            customerCb.DataSource = new List<string> { "Loading..." };
            contractCb.DataSource = contractService.ListContractTemplates();
            consultantCb.DataSource = await contosoConsultancyServiceProxy.FetchConsultantsAsync();
            customerCb.DataSource = await contosoConsultancyServiceProxy.FetchCustomersAsync();
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

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                await GenerateContractAsync();
            }
        }

        private async Task GenerateContractAsync()
        {
            try
            {
                var content = await BuildContractContentAsync();
                using (var fs = saveFileDialog1.OpenFile())
                {
                    await WriteContractAsync(fs, content);
                    MessageBox.Show("Contract Successfully Generated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error during contract creation");
            }
        }

        private async Task WriteContractAsync(Stream destination, string content)
        {
            await pdfService.WriteTextToPdfStreamAsync(destination, content);
        }

        private async Task<string> BuildContractContentAsync()
        {
            var contractData = GetContractDataFromForm();
            var contractTemplate = contractCb.SelectedValue.ToString();
            var content = await contractService.GetContractContentAsync(contractTemplate, contractData);
            return content;
        }
    }
}

using System;
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
    }
}

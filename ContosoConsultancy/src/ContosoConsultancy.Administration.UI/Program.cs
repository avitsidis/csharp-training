using ContosoConsultancy.Rest.Client.ContosoConsultancyRest;
using Microsoft.Rest;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ContosoConsultancy.Administration.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var uri = ConfigurationManager.AppSettings["ContosoConsultancy.RestAPI.Uri"];
            var credentials = new BasicAuthenticationCredentials();
            var client = new ContosoConsultancyRestClient(new Uri(uri), credentials);
            var serviceProxy = new ContosoConsultancyServiceProxy(client);
            var contractService = new ContractService();
            Application.Run(new Form1(serviceProxy, contractService));
        }
    }
}

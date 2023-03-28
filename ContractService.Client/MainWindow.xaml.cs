using ContractService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using ContractService.Model.Interfaces;
using System.Net;

namespace ContractService.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Contract> ContractsList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/ContractService/");
            using (var channelFactory = new ChannelFactory<IContractService>(binding, endpointAddress))
            {
                IContractService contractClient = null;
                try
                {
                    contractClient = channelFactory.CreateChannel();                    
                    Contracts.ItemsSource = contractClient.GetContracts();

                }
                catch
                {
                    (contractClient as ICommunicationObject).Abort();
                }
            }
        }
    }
}

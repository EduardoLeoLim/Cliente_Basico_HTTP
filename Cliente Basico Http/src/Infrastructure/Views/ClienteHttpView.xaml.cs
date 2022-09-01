using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Cliente_Basico_Http.Application;
using Cliente_Basico_Http.Infrastructure.Services;

namespace Cliente_Basico_Http.Infrastructure.Views
{
    /// <summary>
    /// Interaction logic for ClienteHttpView.xaml
    /// </summary>
    public partial class ClienteHttpView : Window
    {
        public ClienteHttpView()
        {
            InitializeComponent();
            cbxMetodoHttp.Items.Add("GET");
            cbxMetodoHttp.Items.Add("POST");
            cbxMetodoHttp.Items.Add("PUT");
            cbxMetodoHttp.Items.Add("PATCH");
            cbxMetodoHttp.Items.Add("DELETE");
            cbxMetodoHttp.SelectedIndex = 0;
        }

        private void BtnSendRequest_OnClick(object sender, RoutedEventArgs e)
        {
            if (cbxMetodoHttp.SelectedIndex >= 0 && txtUrl.Text.Length > 0)
            {
                SendRequest();
            }
        }

        private async Task SendRequest()
        {
            var sender = new SendRequest(new HttpRequestService());
            ResponseData responseData = null;
            switch ((string)cbxMetodoHttp.SelectedValue)
            {
                case "GET":
                    responseData = await sender.SendGetRequest(txtUrl.Text, txtParametros.Text);
                    break;
            }
            
            if (responseData == null)
                return;
            
            gridRequestResult.Children.Clear();
            if (rdbRaw.IsChecked == true)
            {
                var textResult = new TextBlock();
                textResult.Text = responseData.Body;
                gridRequestResult.Children.Add(textResult);
            }

            if (rdbHtml.IsChecked == true)
            {
                var htmlResult = new WebBrowser();
                htmlResult.NavigateToString(responseData.Body);
                gridRequestResult.Children.Add(htmlResult);
            }
        }
    }
}

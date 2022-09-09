using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Cliente_Basico_Http.Application;
using Cliente_Basico_Http.Infrastructure.Services;
using Newtonsoft.Json;

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
            cbxMetodoHttp.Items.Add("HEAD");
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
            try
            {
                switch ((string)cbxMetodoHttp.SelectedValue)
                {
                    case "GET":
                        responseData = await sender.SendGetRequest(txtUrl.Text);
                        break;
                    case "HEAD":
                        responseData = await sender.SendHeadRequest(txtUrl.Text);
                        break;
                    case "POST":
                        responseData = await sender.SendPostRequest(txtUrl.Text, txtParametros.Text);
                        break;
                    case "PUT":
                        responseData = await sender.SendPutRequest(txtUrl.Text, txtParametros.Text);
                        break;
                    case "PATCH":
                        responseData = await sender.SendPatchRequest(txtUrl.Text, txtParametros.Text);
                        break;
                    case "DELETE":
                        responseData = await sender.SendDeleteRequest(txtUrl.Text);
                        break;
                }

                if (responseData == null)
                {
                    lblResultados.Content = "Error al obtener respuesta";
                    return;
                }

                lblResultados.Content =
                    $"StatusCode:{responseData.StatusCode} - ContentType:{responseData.ContentType}";
                gridRequestResult.Children.Clear();
                if (rdbHtml.IsChecked == true && responseData.ContentType == "text/html")
                {
                    var htmlResult = new WebBrowser();
                    htmlResult.NavigateToString(responseData.Body);
                    gridRequestResult.Children.Add(htmlResult);
                }
                else
                {
                    var textResult = new TextBlock();
                    textResult.Text = responseData.Body;
                    gridRequestResult.Children.Add(textResult);
                }
            }
            catch (JsonReaderException e)
            {
                lblResultados.Content = "El formato de los parámetros no es válido. Deben estar en formato JSON";
                gridRequestResult.Children.Clear();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using unirest_net.http;

namespace Application
{
    public partial class About : Page
    {
        private WebRequest _webRequest;
        private WebResponse _webResponse;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public static bool IsValidURL(string strURL)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(strURL, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }

        public void FillEmailField(object sender, EventArgs eventArgs)
        {
            if (LoginEmailAddress.Text.Length == 0 )
            {
                LoginEmailAddress.Text = "*";
            }
        }
        public void FillPasswordField(object sender, EventArgs eventArgs)
        {
            if (LoginPassword.Text.Length == 0)
            {
                LoginPassword.Text = "*";
            }
        }

        public void FillURLField(object sender, EventArgs eventArgs)
        {
            if (URLAddress.Text.Length == 0)
            {
                URLAddress.Text = "*";
            }
        }


        public void GoToURL(object sender, EventArgs parameters)
        {
            if (IsValidURL(URLAddress.Text) == false)
            {
                URLDisplayMessage.InnerHtml = "ERROR: " + URLAddress.Text.ToString() + " is not a valid url.";
            }
            else
            {
               CreateWebRequest();
               HandShake();
            }
        }
       
        public void HandShake(object sender=null, EventArgs eventArgs=null)
        {
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            _webRequest.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            _webRequest.ContentLength = byteArray.Length;
            
            // Get the request stream.
          //  Stream dataStream = _webRequest.GetRequestStream();
            // Write the data to the request stream.
          //  dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
          //  dataStream.Close();

            // Get the response.

            //Task<HttpResponse<WebResponse>> response = Unirest.get("https://community-angellist.p.mashape.com/follows/batch?ids=86500%2C173917")
            //    .header("X-Mashape-Key", "6SnbiXIGb3msh9AhBlez4Nbpm2Dxp1SlJJKjsn8bYg9r9kIfJ0")
            //    .header("Accept", "application/json")
            //    .asJson();

            HttpResponse<WebResponse> response = Unirest.get("https://community-angellist.p.mashape.com/follows/batch?ids=86500%2C173917")
                .header("X-Mashape-Key", "6SnbiXIGb3msh9AhBlez4Nbpm2Dxp1SlJJKjsn8bYg9r9kIfJ0")
                .header("Accept", "application/json").asJson<WebResponse>();
            // Display the status.
            ResponseStatusDescription.InnerHtml = ((HttpWebResponse) this._webResponse).StatusDescription;

            // Get the stream containing content returned by the server.
            var dataStream = response.Body.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            _webResponse.Close();

        }

        private void CreateWebRequest()
        {
            URLDisplayMessage.InnerHtml = "Now going to the web page ...";
            Uri urlAddress = new Uri(URLAddress.Text);
            _webRequest = WebRequest.Create(urlAddress);
            _webRequest.Method = "POST";
        }

        public void GotoWebPage(object sender = null, EventArgs paramEventArgs=null)
        {

            if ( _webRequest != null )
            {
                _webResponse = _webRequest.GetResponse();

                if ( _webResponse == null )
                {
                    Redirecting.InnerHtml = "ERROR: Could not process the web response.";
                }
                else
                {

                }
            }
        }



        public  void IsValidEmailAddress(object sender = null, EventArgs paramEventArgs = null)
        {
            if ( LoginEmailAddress.Text.Length == 0 )
            {
                EmailDisplayMessage.InnerHtml = "ERROR: Please enter an email address.";
            }
            else if (LoginEmailAddress.Text.Contains("@") == false)
            {
                EmailDisplayMessage.InnerHtml =
                    "ERROR: " + LoginEmailAddress.Text.ToString() + " is not a valid email address";
            }
            else
            {
                EmailDisplayMessage.InnerHtml = string.Empty;
            }
        }

        public void ValidatePassword(object sender = null, EventArgs paramEventArgs = null)
        {
            if (LoginPassword.Text.Length == 0)
            {
                EmailDisplayMessage.InnerHtml = "ERROR: Please enter a password.";
            }
            else if ( LoginPassword.Text.Length < 8 )
            {
                PasswordDisplayMessage.InnerHtml = "ERROR: " + LoginPassword.Text.ToString() +
                                                   " is not a valid password.";
            }
            else
            {
                PasswordDisplayMessage.InnerHtml = string.Empty;
            }
        }

        public void ValiateLoginInformation(object sender = null, EventArgs paramEventArgs = null)
        {

        }
    }
}
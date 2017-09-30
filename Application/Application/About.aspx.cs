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

        public void OnButtonClicked(object sender, EventArgs parameters)
        {
            if (IsValidURL(UserInput.Text) == false)
            {
                URLDisplayMessage.InnerHtml = "ERROR:Invalid URL ";
            }
            else
            {
                URLDisplayMessage.InnerHtml = "Now going to the web page ...";
                Uri urlAddress = new Uri(UserInput.Text);
                _webRequest = WebRequest.Create(urlAddress);
            }
            GotoWebPage();
        }

        public void GotoWebPage(object sender = null, EventArgs parameters=null)
        {
           
        }

    }
}
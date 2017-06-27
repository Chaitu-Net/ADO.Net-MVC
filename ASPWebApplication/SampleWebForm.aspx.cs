using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWebApplication
{
    public partial class SampleWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // string str = txt1.Text;
            txt1.Text = "Hi Welcome to Web Forms";
        }
    }
}
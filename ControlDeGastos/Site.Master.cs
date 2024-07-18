using System;
using System.Web.Security;
using System.Web.UI;

namespace ControlDeGastos
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && this.Page.User.Identity.IsAuthenticated)
            {
            }
        }
    }
}
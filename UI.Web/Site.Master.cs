using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                EsconderMenu();
            }
        }
        
        protected void EsconderMenu()
        {
            menuSuperior.Visible = false;
        }
    }
}
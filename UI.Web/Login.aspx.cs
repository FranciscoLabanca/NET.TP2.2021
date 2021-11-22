using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Web.Security;

namespace UI.Web
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
				Response.Redirect("~/Academia/Default.aspx");
            }
		}

        protected void LoginForm_Authenticate(object sender, AuthenticateEventArgs e)
        {
			UsuarioLogic ul = new UsuarioLogic();
			if (ul.ValidarUsuario(LoginForm.UserName, LoginForm.Password))
			{
				LoadSession(LoginForm.UserName);
				FormsAuthentication.RedirectFromLoginPage(LoginForm.UserName, LoginForm.RememberMeSet);
			}
        }

		protected void LoadSession(string userName)
        {
			UsuarioLogic ul = new UsuarioLogic();
			Usuario usuario = ul.GetOne(userName);
			ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
			List<ModuloUsuario> modulosUsuarios = mul.GetByUserID(usuario.ID);
			//Session.Add("Modulos", modulosUsuarios);
			Session["Modulos"] = modulosUsuarios;
        }
    }
}
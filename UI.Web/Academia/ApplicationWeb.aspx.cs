using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ApplicationWeb : Page
    {
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)ViewState["FormMode"];
            }
            set
            {
                ViewState["FormMode"] = value;
            }
        }

        protected int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        protected bool IsEntitySelected
        {
            get
            {
                return (SelectedID != 0);
            }
        }

        virtual protected void LoadGrid() { }

        virtual protected void LoadForm(int id) { }

        virtual protected void EnableForm(bool enable) { }

        virtual protected void ClearForm() { }

        virtual protected bool Validar() { return false; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;

namespace WebApplication1 {
    public partial class Default : System.Web.UI.Page {

        protected void Page_Load(object sender,EventArgs e) {
            if (IsPostBack) {
                Response.Write("PostBack");
            }
        }

        [WebMethod]
        public static string GetCurrentTime(string name){

            return ExcelExport.Start();
        }

        //public string SetLiteralText(){
        //    //literal.Text = "Готово";
        //    //return "Good";
        //}

        //public void StartPostBack()
        //{
        //    StringBuilder script = new StringBuilder();
        //    //Response.write("<body OnLoad=""javascript:__doPostBack('ForcePostBack','');"">")
        //    script.Append("<script language='JavaScript' type='text/javascript'>\n");
        //    script.Append("<!--\n");
        //    script.Append(ClientScript.GetPostBackEventReference(literal,"PBArg") + ";\n");
        //    script.Append("// -->\n");
        //    script.Append("</script>\n");
        //    ClientScript.RegisterStartupScript(this.GetType(),"AutoPostBackScript",script.ToString());
        //}
    }
}
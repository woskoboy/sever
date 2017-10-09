using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lances.Pages {
    public partial class MetalHoses : BasePage {
        private string hose_num;
        const string mark = "hose";
        public string Hose_num { get { return hose_num; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            hose_num = Hose_no_input.Value;
            if (!string.IsNullOrEmpty(hose_num)){
                Hose hose = GetDataFromCache<Hose>(mark+hose_num);
                TableBinding(hose);
            }
        }
        private void TableBinding(Hose hose){
            Repeater1.DataSource = new List<Hose> { hose };
            Repeater1.DataBind();
        }
        protected void Page_Init(object sender, EventArgs e){
            RequestButton.Click += RequestButtonHandler;
        }
        private void RequestButtonHandler(object sender, EventArgs e){
            EditLink.Visible = true;
            EditLink.NavigateUrl = GetRouteUrl("hose", new { hose = hose_num });//hose_no_input.Value });
        }
    }
}
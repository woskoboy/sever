﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data;
using System.Web.Services;

namespace Lances.Pages {
    public partial class Default : BasePage {
        private string lance_num;
        const string mark = "lance";
        public string Lance_num { get { return lance_num; } }

        protected void Page_Load(object sender,EventArgs e) {
            lance_num = Lance_no_input.Value;
            if (!string.IsNullOrEmpty(lance_num)){
                Lance lance = GetDataFromCache<Lance>(mark+lance_num);
                TableBinding(lance);
            }
        }

        [WebMethod]
        public static string GetCurrentTime(string name){
            return ExcelExport.Start();
        }
        //private Lance GetDataFromCache(){
        //    key = GetLanceFromRequestOrConrol();
        //    Lance lanceData = string.IsNullOrEmpty(key) ? null : Cache[key] as Lance;
        //    return lanceData;
        //}

        //private string GetLanceFromRequestOrConrol(){
        //    if (string.IsNullOrEmpty(Lance_no_input.Value)) {
        //        string reqValue = (string)RouteData.Values["lance_no"] ?? Request.QueryString["lance_no"];
        //        return reqValue;
        //    }
        //    return Lance_no_input.Value;
        //}
        private void TableBinding(Lance lance){
            Repeater1.DataSource = new List<Lance> { lance };
            Repeater1.DataBind();
        }
        protected void Page_Init(object sender, EventArgs e){
            RequestButton.Click += RequestButtonHandler;
        }
        private void RequestButtonHandler(object sender,EventArgs e){
            EditLink.Visible = true;
            EditLink.NavigateUrl = GetRouteUrl("lance", new { lance = lance_num});//Lance_no_input.Value });
            //int fblow_no;
            //Int32.TryParse(First_blow_hiden.Value, out fblow_no
            //WorkerDB worker = new WorkerDB();
            //tip_durability_out.Text = worker.CountDurability(lance_no, fblow_no);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;

namespace Lances.Pages {
    public partial class EditLance : BasePage {
        private string DATE_INSTALL = "DateInstall";
        private string DATE_DEINSTALL = "DateDeinstall";
        private Dictionary<string,string> dict;
        private string lance_num;
        const string mark = "lance";

        protected void Page_Load(object sender,EventArgs e){
            lance_num = string.IsNullOrEmpty(Lance_no.Value) ? GetNumberFromRequest("lance") : Lance_no.Value;
            Lance_no.Value = lance_num;
        }
        protected void Page_Init(object sender,EventArgs e){
            SaveEditButton.Click += SaveEditHandler;
            //JobsSelect += JobsHandler; //на событие Выполненных работ
            //ReasonSelect += ReasonHandler; //на событие Причина замены 
        }
        protected void Page_PreRender(object sender,EventArgs e){
            Lance lance = GetDataFromCache<Lance>(mark+lance_num);
            if (lance != null){
                dict = GetDictFromObject(lance);
                FillControls(dict, EditTableDiv.Controls);

                Page.ClientScript.RegisterHiddenField(DATE_INSTALL+"_hidden", lance.DateInstall);
                Page.ClientScript.RegisterHiddenField(DATE_DEINSTALL+"_hidden", lance.DateDeinstall);
            }
        }
        private void SaveEditHandler(object sender,EventArgs e){
            Lance lance = GetObjectFromControls(new Lance { }, EditTableDiv.Controls);
            lance.DateInstall = Request.Form[DATE_INSTALL];
            lance.DateDeinstall = Request.Form[DATE_DEINSTALL];

            Cache.Insert(mark+lance_num,lance,null,DateTime.Now.AddMinutes(10),TimeSpan.Zero);
            Response.Redirect("~/lances/"+lance_num);
        }

        // обработчик select Причина замены
        //private void ReasonHandler(object sender,CommandEventArgs e){
        //    string txt = (string)e.CommandArgument;
        //    if (DL_Reasons.SelectedIndex == 0) {//пустой элемент
        //        Reason.Visible = false;
        //        Reason.Value = "";
        //        return;
        //    }
        //    Reason.Visible = true;
        //    Reason.Value += txt + ", ";
        //}
        // стартуем событие IndexChanged Выполненных работ
        //protected void DL_Jobs_SelectedIndexChanged(object sender,EventArgs e){
        //    int index = DL_Jobs.SelectedIndex;
        //    if (index != -1)
        //        JobsSelect?.Invoke(this,new CommandEventArgs("Jobs_select",DL_Jobs.SelectedValue));
        //}
        // стартуем событие IndexChanged Причины замены
        //protected void DL_Reasons_SelectedIndexChanged(object sender,EventArgs e){
        //    int index = DL_Reasons.SelectedIndex;
        //    if (index != -1)
        //        ReasonSelect?.Invoke(this,new CommandEventArgs("Reason_select",DL_Reasons.SelectedItem.Text));
        //}

        //private void SaveDatesInViewState(){
        //    foreach (string date in dates)
        //        ViewState[date] = String.Format("{0}",Request.Form[date]);
        //}
        //private void SaveDatesForJsRestore(){
        //    foreach (string date in dates) {
        //        ViewState[date] = Request.Form[date];
        //        //Page.ClientScript.RegisterHiddenField(date + "_hidden",(string)ViewState[date]);
        //    }
        //}
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lances.Pages {
    public class BasePage : System.Web.UI.Page{
        protected T GetDataFromCache<T>(string key){
            T obj;
            try { obj = (T)Cache[key]; }
            catch { obj = default(T); }
            return obj;
        }
        protected string GetNumberFromRequest(string name){
                string reqValue = (string)RouteData.Values[name] ?? Request.QueryString[name];
                return reqValue;
        }
        // превратить объект в словарь
        protected Dictionary<string,string> GetDictFromObject<T>(T obj){
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
            Dictionary<string,string> dic = new Dictionary<string,string>();
            foreach (PropertyDescriptor prop in properties)
                dic.Add(prop.Name,string.Format("{0}",prop.GetValue(obj)));
            return dic;
        }
        // из словаря заполнить контролы
        protected void FillControls(Dictionary<string, string> dict, ControlCollection collection){
            foreach (Control c in collection)
                if (c.ID != null && dict.ContainsKey(c.ID)){
                    if (c is HtmlInputText)
                        ((HtmlInputText)c).Value = dict[c.ID];
                    if (c is HtmlTextArea)
                        ((HtmlTextArea)c).Value = dict[c.ID];
                    if (c is HtmlSelect)
                        ((HtmlSelect)c).Value = dict[c.ID];
                }
        }
        // собрать объект из контролов (их значений)
        protected T GetObjectFromControls<T>(T obj, ControlCollection collection) {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
            foreach (Control c in collection)
                foreach (PropertyDescriptor prop in properties){
                    if(c.ID == prop.Name){
                        if (c is HtmlInputText)
                            prop.SetValue(obj, ((HtmlInputText)c).Value);
                        if (c is HtmlTextArea)
                            prop.SetValue(obj, ((HtmlTextArea)c).Value);
                        if (c is HtmlSelect)
                            prop.SetValue(obj, ((HtmlSelect)c).Value);
                    } 
                }
            return obj;
        }
    }
}

//const string LANCE_NUMBER = "lance";
//private string[] IDs = new string[] { "id","Id","ID" };

//protected Lance GetDataFromCache(string key){
//    Lance lanceData = string.IsNullOrEmpty(key) ? null : Cache[key] as Lance;
//    return lanceData;
//}

//T lanceData = string.IsNullOrEmpty(key) ? default(T) : (T)Cache[key];

//string value = String.Format("{0}",Request.Form[control_id]);

//protected void SetPropertyForControl<T>(T obj,Dictionary<string,string> dict) where T:class{
//    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
//    foreach (PropertyDescriptor prop in properties) {
//        // из ID контрола получаем его значение, которое будем использовать в качестве ключа
//        if (Array.IndexOf(IDs,prop.Name) != -1 && prop.GetValue(obj) != null) {
//            string key = string.Format("{0}",prop.GetValue(obj));
//            if (dict.ContainsKey(key)) {
//                Response.Write(obj.ToString() + key + ":" + dict[key]);
//            }
//        }
//    }
//}
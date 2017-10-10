﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditHose.aspx.cs" Inherits="Lances.Pages.EditHose" MasterPageFile="~/Site.Master" %>
<asp:Content ContentPlaceHolderID="EditHosesContent" ID="HosesEditPage" runat="server">
<div id="EditTableDiv" runat="server" style="text-align:center">
        <h4>Для рукава <input runat="server" readonly="readonly" ID="Hose_no"/></h4>
        <table id="MainProperty" class="table table-striped table-hover">
            <thead>
                <tr>
                    <th class="warning">Причина замены</th>
                    <th class="success">Выполненные работы</th>
                    <th class="danger">Стойкость общая</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="warning">
                        <select ID="DL_Reasons" multiple="multiple" class="form-control"> 
                            <%--AutoPostBack="true" OnSelectedIndexChanged="DL_Reasons_SelectedIndexChanged"--%>
                            <option value="причина1">причина1</option>
                            <option value="причина2">причина2</option>
                            <option value="причина3">причина3</option>
                        </select>
                    </td>
                    <td class="success">
                        <select ID="DL_Jobs" multiple="multiple" class="form-control">
                        <%--AutoPostBack="true" OnSelectedIndexChanged="DL_Jobs_SelectedIndexChanged"--%>
                        <option value="работа1">работа1</option>
                        <option value="работа2">работа2</option>
                        <option value="работа3">работа3</option>
                        <option value="работа4">работа4</option>
                        </select>
                    </td>
                    <td id="durability" class="danger">
                        <div>
                            <asp:Literal ID="DurabilityControl" runat="server"></asp:Literal>
                        </div>
                        Ручной ввод:
                    </td>
                </tr>
                <tr>
                    <td class="warning">
                        <textarea id="Reason" rows="2" runat="server" ClientIDMode="Static"
                            style="width: 100%" class="form-control"></textarea>
                    </td>
                    <td class="success">
                        <textarea id="Jobs" rows="2" runat="server"  ClientIDMode="Static"
                            style="width: 100%" class="form-control"></textarea>
                    </td>
                    <td class="danger"><input id="Durability" class="form-control" runat="server"></td>
                </tr>
            </tbody>
        </table>

        <table class="table table-striped table-hover">
            <thead><tr>
                <td>№ конвертера</td>
                <td>МПК</td>
                <td>Тип</td>
                <td>Бригада</td>
            </tr></thead>
            <tbody><tr>
                <td><select id=Cv_no runat="server" class="form-control">
                        <option value=""></option>
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                    </select></td>
                <td><select id=Mpk runat="server" class="form-control">
                        <option value=""></option>
                        <option value="левая">левая</option>
                        <option value="правая">правая</option>
                    </select></td>
                <td><select id="Kind" runat="server" class="form-control">
                        <option value=""></option>
                        <option value="кислородный">кислородный</option>
                        <option value="напорный">напорный</option>
                        <option value="сливной">сливной</option>
                    </select></td>
                <td><input id=Team runat="server" class="form-control" /></td>
            </tr></tbody>
        </table>

        <table class="table table-striped table-hover">
            <tr>
                <td>Дата монтажа</td>
                <td>
                    <div class="bootstrap-iso">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="form-group ">
                                        <div class="col-sm-10">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <input class="form-control" id="DateInstall" name="DateInstall" placeholder="Д/М/Г" 
                                                    style="width:100px">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-10 col-sm-offset-2">
                                            <input name="_honey" style="display: none" type="text">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <td>Дата демонтажа</td>
                <td>
                    <div class="bootstrap-iso">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="form-group ">
                                        <div class="col-sm-10">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </div>
                                                <input class="form-control" style="width:100px"
                                                    id="DateDeinstall" name="DateDeinstall" placeholder="Д/М/Г">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-10 col-sm-offset-2">
                                            <input name="_honey" style="display: none" type="text">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>


        <table class="table alert-warning">
            <thead>
            <tr>
                <td colspan="8">Стойкость вставок</td>
            </tr>
            <tr>
                <td>1</td>
                <td>2</td>
                <td>3</td>
                <td>4</td>
                <td>5</td>
                <td>6</td>
                <td>7</td>
                <td>8</td>
            </tr>
                </thead><tbody>
            <tr>
                <td><input id=part1 runat="server" class="form-control" /></td>
                <td><input id=part2 runat="server" class="form-control" /></td>
                <td><input id=part3 runat="server" class="form-control" /></td>
                <td><input id=part4 runat="server" class="form-control" /></td>
                <td><input id=part5 runat="server" class="form-control" /></td>
                <td><input id=part6 runat="server" class="form-control" /></td>
                <td><input id=part7 runat="server" class="form-control" /></td>
                <td><input id=part8 runat="server" class="form-control" /></td>
            </tr>
                    </tbody>
        </table>
    <br />


        <asp:Button class="btn btn-danger" id="SaveEditButton" runat="server" Text="Сохранить"/>
    </div>

    <script>
        $(document).ready(function () {
            var date_input = $('input[name="DateInstall"]'); //our date input has the name "date"
            var container = $('.bootstrap-iso').length > 0 ? $('#DateInstall').parent() : "body";
            date_input.datepicker({
                format: 'dd/mm/yyyy',
                container: container,
                todayHighlight: true,
                autoclose: true,
                language: 'ru',
            });;
            var date_input = $('input[name="DateDeinstall"]'); //our date input has the name "date"
            var container = $('.bootstrap-iso').length > 0 ? $('#DateDeinstall').parent() : "body";
            date_input.datepicker({
                format: 'dd/mm/yyyy',
                container: container,
                todayHighlight: true,
                autoclose: true,
                language: 'ru',
            });;
        })
    </script>
    <script>
            ; (function ($) {
                $.fn.datepicker.dates['ru'] = {
                    days: ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"],
                    daysShort: ["Вск", "Пнд", "Втр", "Срд", "Чтв", "Птн", "Суб"],
                    daysMin: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"],
                    months: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
                    monthsShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июн", "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"],
                    today: "Сегодня",
                    clear: "Очистить",
                    format: "dd.mm.yyyy",
                    weekStart: 1,
                    monthsTitle: 'Месяцы'
                };
            }(jQuery));
    </script>
    <script>
            $(document).ready(function () {
                var date = $("#DateInstall_hidden").attr("value");
                $("#DateInstall").attr("value", date);

                date = $("#DateDeinstall_hidden").attr("value");
                $("#DateDeinstall").attr("value", date);
            });
    </script>
    <script>
        $(document).ready(function () {
            $("#DL_Reasons").change(function () {
                    var str = "";
                    $("#DL_Reasons option:selected").each(function () {
                        str += $(this).text() + ", ";
                    });
                    $('#Reason').text(str);
                });
        });
    </script>
    <script>
            $(document).ready(function () {
                $("#DL_Jobs").change(function () {
                    var str = "";
                    $("#DL_Jobs option:selected").each(function () {
                        str += $(this).text() + ", ";
                    });
                    $('#Jobs').text(str);
                });
            });
    </script>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvailabilityLances.aspx.cs" Inherits="Lances.Pages.AvailabilityLances" MasterPageFile="~/Site.Master"%>

<asp:Content ContentPlaceHolderID="AvailabilityContent" runat="server">
    
    <table class="table table-striped table-hover" style="text-align:center">
        <thead>
            <tr>
                <td colspan="7" class="active">Наличие фурм</td>
            </tr>
            <tr>
                <td rowspan="2" class="info">№ фурмы</td>
                <td colspan="2" class="success">МПК-1</td>
                <td colspan="2" class="warning">МПК-2</td>
                <td colspan="2" class="danger">МПК-3</td>
            </tr>
            <tr>
                <td>левая</td>
                <td>правая</td>
                <td>левая</td>
                <td>правая</td>
                <td>левая</td>
                <td>правая</td>
            </tr>
        </thead>
        <tr>
            <td colspan="7">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        </table>
    
</asp:Content>
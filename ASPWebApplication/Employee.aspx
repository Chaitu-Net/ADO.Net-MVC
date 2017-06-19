<%@ Page Language="C#" MasterPageFile ="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="ASPWebApplication.Employee" %>

<asp:Content ID ="Content1" ContentPlaceHolderID="MainContent" runat ="server">
    <table>
        <tr>
            <td> ID : </td>
            <td> <asp:TextBox ID ="txtID" runat="server"></asp:TextBox> </td>
        </tr>

        <tr>
            <td> Name : </td>
            <td> <asp:TextBox ID ="txtName" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td> Age : </td>
            <td> <asp:TextBox ID ="txtAge" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td> Salary : </td>
            <td> <asp:TextBox ID ="txtSalary" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <td>Department ID :</td>
            <td><asp:TextBox ID ="txtDid" runat ="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Date Of Joining:</td>
            <td><asp:TextBox ID ="txtDOJ" runat ="server"></asp:TextBox></td>
        </tr>
        <tr> <td> <asp:Button ID ="butSave" runat ="server" text ="Save" OnClick="butSave_Click"/> </td> 
             <td> <asp:Button ID ="butUpdate" runat ="server" text ="Update" OnClick="butUpdate_Click"/> </td> 
             <td> <asp:Button ID ="butSelect" runat ="server" text ="Select" OnClick="butSelect_Click"/> </td>
             <td> <asp:Button ID ="butDelete" runat ="server" text ="Delete" OnClick="butDelete_Click"/> </td> </tr> 
    </table>
    <asp:GridView ID="GvDisplayEmp" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
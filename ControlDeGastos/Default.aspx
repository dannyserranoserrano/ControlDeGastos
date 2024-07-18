<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlDeGastos._Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
       <div>
            <h3>Agregar nuevo gasto</h3>
            <asp:TextBox ID="txtDescription" runat="server" placeholder="Descripcion"></asp:TextBox>
            <asp:TextBox ID="txtAmount" runat="server" placeholder="Cantidad"></asp:TextBox>
            <asp:TextBox ID="txtDate" runat="server" placeholder="Fecha (DD/MM/AAAA)"></asp:TextBox>
            <asp:Button class="btn btn-success" ID="btnAddExpense" runat="server" Text="Agregar" OnClick="btnAddExpense_Click" />
        </div>
        <hr />
        <div>
            <h1>Gastos</h1>
            <asp:GridView class="table" ID="GridViewExpenses" runat="server" AutoGenerateColumns="false" DataKeyNames="ExpenseId"  OnRowEditing="GridViewExpenses_RowEditing" OnRowCancelingEdit="GridViewExpenses_RowCancelingEdit" OnRowUpdating="GridViewExpenses_RowUpdating" OnRowDeleting="GridViewExpenses_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ExpenseId" HeaderText="ID" ReadOnly="true" InsertVisible="false" Visible="false" />
                    <asp:BoundField DataField="Description" HeaderText="Descripcion"/>
                    <asp:BoundField DataField="Amount" HeaderText="Cantidad" />
                    <asp:BoundField  DataField="Date" HeaderText="Fecha (DD/MM/AAAA)" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:commandfield ShowEditButton="true" ShowDeleteButton="true" EditText="Editar" CancelText="Cancelar" UpdateText="Actualizar" DeleteText="Borrar" HeaderText="Controles de Edicion"/>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" Font-Size="Large" ForeColor="Red" Visible="False"></asp:Label>
        <hr />
        <div>
            <h2>Resumen Mensual</h2>
            <asp:GridView class="table" ID="GridViewMonthlySummary" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Month" HeaderText="Mes" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Gastos" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <h3>Exportar a Excel</h3>
            <asp:Button class="btn btn-info" ID="btnExportToExcel" runat="server" Text="Exportar" OnClick="btnExportToExcel_Click" />
        </div>
    </div>
</asp:Content>





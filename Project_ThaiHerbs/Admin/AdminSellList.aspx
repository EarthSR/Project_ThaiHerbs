<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminSellList.aspx.cs" Inherits="AdminSellList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <div class = "addminproduct-container"> 
                    <div class = "manage-products">
                        <div class = "txt-addminproduct"
                           <p><h1>สินค้าที่ต้องยืนยัน</h1></p>

                        <div>
                            <p>
                            <asp:Label runat="server" ID="lblshow"></asp:Label>
                        
                            </p>    
                        </div>
                            <br />
                            <br />
                            <br />
                            <div>
                                <p>
                                </p>
                                <h3>
                                    <asp:Label ID="Label1" runat="server" Text="กรอกorderid"></asp:Label>
                                </h3>
                                <asp:TextBox ID="txtid" runat="server" CssClass="manage-products-box" 
                                    Height="34px" Width="100%"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="btbone" runat="server" Text="ยืนยันตามidที่เลือก" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" OnClick="btbone_Click"/>
                            </div>
                            <br />
                            <p><asp:Button ID="btbdelete" runat="server" Text="ลบออเดอร์ตามidที่เลือก" Height="30px" 
                                    Width="100%" cssClass= "btn-manage-products" OnClick="btbdelete_Click"/></p>     



                        </div>
                        </div>
                        </div>



</asp:Content>


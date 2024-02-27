<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true" CodeFile="AdminProductAll.aspx.cs" Inherits="AdminProductAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                <div class = "addminproduct-container"> 
                <div class = "manage-products">
                <div class = "txt-addminproduct1">




                    <asp:ListView ID="ListView1" runat="server" DataKeyNames="productid" 
                        DataSourceID="SqlDataSource1">
                        <AlternatingItemTemplate>
                            <span style="">productid:
                            <asp:Label ID="productidLabel" runat="server" Text='<%# Eval("productid") %>' />
                            <br />
                            pname:
                            <asp:Label ID="pnameLabel" runat="server" Text='<%# Eval("pname") %>' />
                            <br />
                            pprice:
                            <asp:Label ID="ppriceLabel" runat="server" Text='<%# Eval("pprice") %>' />
                            <br />
                            pdetail:
                            <asp:Label ID="pdetailLabel" runat="server" Text='<%# Eval("pdetail") %>' />
                            <br />
                            ptype:
                            <asp:Label ID="ptypeLabel" runat="server" Text='<%# Eval("ptype") %>' />
                            <br />
                            pamount:
                            <asp:Label ID="pamountLabel" runat="server" Text='<%# Eval("pamount") %>' />
                            <br />
                            pimage:
                            <asp:Label ID="pimageLabel" runat="server" Text='<%# Eval("pimage") %>' />
                            <br />
                            <br />
                            </span>
                        </AlternatingItemTemplate>
                        <EditItemTemplate>
                            <span style="">productid:
                            <asp:Label ID="productidLabel1" runat="server" 
                                Text='<%# Eval("productid") %>' />
                            <br />
                            pname:
                            <asp:TextBox ID="pnameTextBox" runat="server" Text='<%# Bind("pname") %>' />
                            <br />
                            pprice:
                            <asp:TextBox ID="ppriceTextBox" runat="server" Text='<%# Bind("pprice") %>' />
                            <br />
                            pdetail:
                            <asp:TextBox ID="pdetailTextBox" runat="server" Text='<%# Bind("pdetail") %>' />
                            <br />
                            ptype:
                            <asp:TextBox ID="ptypeTextBox" runat="server" Text='<%# Bind("ptype") %>' />
                            <br />
                            pamount:
                            <asp:TextBox ID="pamountTextBox" runat="server" Text='<%# Bind("pamount") %>' />
                            <br />
                            pimage:
                            <asp:TextBox ID="pimageTextBox" runat="server" Text='<%# Bind("pimage") %>' />
                            <br />
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                Text="Cancel" />
                            <br />
                            <br />
                            </span>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <span>No data was returned.</span>
                        </EmptyDataTemplate>
                        <InsertItemTemplate>
                            <span style="">pname:
                            <asp:TextBox ID="pnameTextBox" runat="server" Text='<%# Bind("pname") %>' />
                            <br />
                            pprice:
                            <asp:TextBox ID="ppriceTextBox" runat="server" Text='<%# Bind("pprice") %>' />
                            <br />
                            pdetail:
                            <asp:TextBox ID="pdetailTextBox" runat="server" Text='<%# Bind("pdetail") %>' />
                            <br />
                            ptype:
                            <asp:TextBox ID="ptypeTextBox" runat="server" Text='<%# Bind("ptype") %>' />
                            <br />
                            pamount:
                            <asp:TextBox ID="pamountTextBox" runat="server" Text='<%# Bind("pamount") %>' />
                            <br />
                            pimage:
                            <asp:TextBox ID="pimageTextBox" runat="server" Text='<%# Bind("pimage") %>' />
                            <br />
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                Text="Clear" />
                            <br />
                            <br />
                            </span>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <span style="">productid:
                            <asp:Label ID="productidLabel" runat="server" Text='<%# Eval("productid") %>' />
                            <br />
                            pname:
                            <asp:Label ID="pnameLabel" runat="server" Text='<%# Eval("pname") %>' />
                            <br />
                            pprice:
                            <asp:Label ID="ppriceLabel" runat="server" Text='<%# Eval("pprice") %>' />
                            <br />
                            pdetail:
                            <asp:Label ID="pdetailLabel" runat="server" Text='<%# Eval("pdetail") %>' />
                            <br />
                            ptype:
                            <asp:Label ID="ptypeLabel" runat="server" Text='<%# Eval("ptype") %>' />
                            <br />
                            pamount:
                            <asp:Label ID="pamountLabel" runat="server" Text='<%# Eval("pamount") %>' />
                            <br />
                            pimage:
                            <asp:Label ID="pimageLabel" runat="server" Text='<%# Eval("pimage") %>' />
                            <br />
                            <br />
                            </span>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div id="itemPlaceholderContainer" runat="server" style="">
                                <span runat="server" id="itemPlaceholder" />
                            </div>
                            <div style="">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                            ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <span style="">productid:
                            <asp:Label ID="productidLabel" runat="server" Text='<%# Eval("productid") %>' />
                            <br />
                            pname:
                            <asp:Label ID="pnameLabel" runat="server" Text='<%# Eval("pname") %>' />
                            <br />
                            pprice:
                            <asp:Label ID="ppriceLabel" runat="server" Text='<%# Eval("pprice") %>' />
                            <br />
                            pdetail:
                            <asp:Label ID="pdetailLabel" runat="server" Text='<%# Eval("pdetail") %>' />
                            <br />
                            ptype:
                            <asp:Label ID="ptypeLabel" runat="server" Text='<%# Eval("ptype") %>' />
                            <br />
                            pamount:
                            <asp:Label ID="pamountLabel" runat="server" Text='<%# Eval("pamount") %>' />
                            <br />
                            pimage:
                            <asp:Label ID="pimageLabel" runat="server" Text='<%# Eval("pimage") %>' />
                            <br />
                            <br />
                            </span>
                        </SelectedItemTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:dbWebThaiHerbs %>" 
                        SelectCommand="SELECT * FROM [product]"></asp:SqlDataSource>




                </div>
                </div>
                </div>


</asp:Content>


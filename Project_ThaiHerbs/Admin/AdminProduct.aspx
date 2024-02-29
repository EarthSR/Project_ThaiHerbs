<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true"
    CodeFile="AdminProduct.aspx.cs" Inherits="AdminProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="addminproduct-container">
        <div class="manage-products">
            <div class="txt-addminproduct">
                <h1>
                    <asp:Label ID="lblresult" runat="server" Text="จัดการเพิ่มสินค้า" CssClass="manage-products-title"></asp:Label>
                </h1>
                <br />
            </div>

            <div>
                <p>
                    <h3>
                        <asp:Label ID="Label1" runat="server" Text="ชื่อสินค้า"></asp:Label></h3>
                    <asp:TextBox ID="txtname" runat="server" Height="34px" Width="100%" CssClass="manage-products-box"></asp:TextBox>
                </p>
            </div>
            <div>
                    <h3>
                        <asp:Label ID="Label6" runat="server" Text="ประเภทสินค้า"></asp:Label></h3>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>กรุณาเลือกประเภทสินค้า</asp:ListItem>
                        <asp:ListItem>สมุนไพรรับประทาน</asp:ListItem>
                        <asp:ListItem>สมุนไพรแห้ง</asp:ListItem>
                        <asp:ListItem>สมุนไพรเกี่ยวกับช่องปาก</asp:ListItem>
                        <asp:ListItem>สมุนไพรเกี่ยวกับเส้นผม</asp:ListItem>
                        <asp:ListItem>สมุนไพรเกี่ยวกับใบหน้า</asp:ListItem>
                        <asp:ListItem>อาหารเสริม</asp:ListItem>
                         <asp:ListItem>สมุนไพรขัดผิว</asp:ListItem>
                </asp:DropDownList>
                    <br />
            </div>

            <div>
                    <h3>
                        <asp:Label ID="Label2" runat="server" Text="ราคา"></asp:Label></h3>
                    <asp:TextBox ID="txtprice" runat="server" Height="38px" Width="100%" CssClass="manage-products-box"></asp:TextBox>
                </p>
                <h3>
                    <asp:Label ID="Label3" runat="server" Text="จำนวน"></asp:Label></h3>
                <asp:TextBox ID="txtamount" runat="server" Height="38px" Width="100%" CssClass="manage-products-box"></asp:TextBox>
            </div>

            <div>
                <p>
                    &nbsp;<h3>
                        <asp:Label ID="Label4" runat="server" Text="รายละเอียด"></asp:Label></h3>
                    <asp:TextBox ID="txtdetail" runat="server" Height="100px" Width="100%" TextMode="MultiLine"
                        CssClass="manage-products-box"></asp:TextBox>
                </p>
            </div>

            <div>
                <p>
                    <h3>
                        <asp:Label ID="Label5" runat="server" Text="เพิ่มรูปภาพ"></asp:Label></h3>
                    <p>
                        <asp:Image ID="uploaded" runat="server" Width="100px" Height="100px" />
                    </p>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Button ID="ButtonUpload" runat="server" Text="เพิ่มรูปภาพ" 
                    OnClick="ButtonUpload_Click" />
            </div>
            <div>
                <br />
                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Button ID="ButtonSignIn" runat="server" Text="เพิ่มสินค้า" Height="30px"
                    Width="100%" CssClass="btn-manage-products" OnClick="ButtonSignIn_Click" />
            </div>
        </div>
    </div>
</asp:Content>


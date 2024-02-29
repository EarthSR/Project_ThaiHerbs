<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageaccount.master" AutoEventWireup="true"
    CodeFile="AdminEditandDelete.aspx.cs" Inherits="AdminEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="addminproduct-container">
        <div class="manage-products">
            <div class="txt-addminproduct">
                <h1>
                    <asp:Label ID="lblresult" runat="server" Text="จัดการแก้ไขสินค้า" CssClass="manage-products-title"></asp:Label>
                </h1>
                <br />
            </div>
            <h3>
                <asp:Label ID="Label6" runat="server" Text="ค้นหาด้วยID"></asp:Label></h3>
            <asp:TextBox ID="txtserch" runat="server" Height="34px" Width="100%" 
                CssClass="manage-products-box" OnTextChanged="txtserch_TextChanged"></asp:TextBox>
            <div>
                    <h3>
                        <asp:Label ID="Label1" runat="server" Text="ชื่อสินค้า"></asp:Label></h3>
                    <asp:TextBox ID="txtname" runat="server" Height="34px" Width="100%"
                        CssClass="manage-products-box" Enabled="False"></asp:TextBox>
            </div>
            <div>
                                    <h3>
                        <asp:Label ID="Label8" runat="server" Text="ประเภทสินค้า"></asp:Label></h3>
                                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False">
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
                <asp:TextBox ID="txtprice" runat="server" Height="38px" Width="100%"
                    CssClass="manage-products-box" Enabled="False"></asp:TextBox>
                <h3>
                    <asp:Label ID="Label3" runat="server" Text="จำนวน"></asp:Label></h3>
                <asp:TextBox ID="txtamount" runat="server" Height="38px" Width="100%"
                    CssClass="manage-products-box" Enabled="False"></asp:TextBox>
            </div>

            <div>
                <h3>
                    <asp:Label ID="Label4" runat="server" Text="รายละเอียด"></asp:Label></h3>
                <asp:TextBox ID="txtdetail" runat="server" Height="100px" Width="100%"
                    TextMode="MultiLine" CssClass="manage-products-box" Enabled="False"></asp:TextBox>
                </p>
            </div>

            <div>
                <h3>
                    <asp:Label ID="Label5" runat="server" Text="รูปภาพ"></asp:Label></h3>
                <p>
                    <asp:Image ID="uploaded1" runat="server" Width="100px" Height="100px" /></p>
                <asp:FileUpload ID="FileUpload1" runat="server" Enabled="False" />
                <asp:Button ID="ButtonUpload" runat="server" Text="เพิ่มรูปภาพ" />

            </div>
            <div>
                <br />
                <br />
                <asp:Label ID="lbleror" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="ButtonSignIn" runat="server" Text="แก้ไขข้อมูลสินค้า" Height="30px"
                    Width="100%" CssClass="btn-manage-products" OnClick="ButtonSignIn_Click" 
                    Enabled="False" />
                <br />
                <br />
                <asp:Button ID="ButtonSignIn0" runat="server" cssClass="btn-manage-products" 
                    Enabled="False" Height="30px" OnClick="ButtonSignIn0_Click" Text="ลบสินค้า" 
                    Width="100%" />
            </div>
        </div>
    </div>
</asp:Content>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QRCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonUpload_Click(object sender, EventArgs e)
    {

        
        if (FileUpload1.HasFile)
        {
            try
            {
                // กำหนดตำแหน่งที่จะบันทึกไฟล์
                string filePath = Server.MapPath("~/Bill/" + FileUpload1.FileName);

                // บันทึกไฟล์
                FileUpload1.SaveAs(filePath);

                // แสดงข้อความว่าอัพโหลดไฟล์สำเร็จ
                Response.Write("File uploaded successfully.");
                ClientScript.RegisterStartupScript(GetType(), "message", "alert('อัพโหลดรูปสำเร็จ');", true);
            }
            catch (Exception ex)
            {
                // แสดงข้อความว่าเกิดข้อผิดพลาดในการอัพโหลดไฟล์
                Response.Write("Error: " + ex.Message);
            }
        }
        else
        {
            // แสดงข้อความว่าไม่พบไฟล์ที่อัพโหลด
            Response.Write("Please select a file.");
            ClientScript.RegisterStartupScript(GetType(), "message", "alert('อัพโหลดรูปไม่สำเร็จ');", true);
        }
    }
}
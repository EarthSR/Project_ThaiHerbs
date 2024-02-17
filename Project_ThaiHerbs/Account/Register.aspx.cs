using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateMonthDropDown();
            PopulateYearDropDown();
            PopulateDayDropDown();
        }
    }

    private void PopulateDayDropDown()
    {
        DropDownListDay.Items.Clear();
        DropDownListDay.Items.Add(new ListItem("Day", ""));

        int selectedMonth;
        int selectedYear;

        if (int.TryParse(DropDownListMonth.SelectedValue, out selectedMonth) && int.TryParse(DropDownListYear.SelectedValue, out selectedYear))
        {
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            int currentDay = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            for (int day = 1; day <= daysInMonth; day++)
            {
                if (selectedYear == currentYear && selectedMonth == currentMonth && day > currentDay)
                {
                    DropDownListDay.Items.Add(new ListItem(day.ToString(), day.ToString()) { Enabled = false });
                }
                else
                {
                    DropDownListDay.Items.Add(new ListItem(day.ToString(), day.ToString()));
                }
            }
        }
    }

    private void PopulateMonthDropDown()
    {
        DropDownListMonth.Items.Clear();
        DropDownListMonth.Items.Add(new ListItem("Month", ""));
        int currentYear = DateTime.Now.Year;
        int currentMonth = DateTime.Now.Month;


        for (int i = 1; i <= 12; i++)
        {

            if (!string.IsNullOrEmpty(DropDownListYear.SelectedValue) && int.Parse(DropDownListYear.SelectedValue) == currentYear && i > currentMonth)
            {
                DropDownListMonth.Items.Add(new ListItem(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), i.ToString()) { Enabled = false });
            }
            else
            {
                DropDownListMonth.Items.Add(new ListItem(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), i.ToString()));
            }
        }
    }


    private void PopulateYearDropDown()
    {
        DropDownListYear.Items.Clear();
        DropDownListYear.Items.Add(new ListItem("Year", ""));

        int currentYear = DateTime.Now.Year;
        for (int year = currentYear; year >= 1900; year--)
        {
            DropDownListYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
        }
    }

    protected void DropDownListMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateDayDropDown();
    }

    protected void txtusername_TextChange(object sender, EventArgs e)
    {
        int valueMessage = ConnectionClass.ValidUser(txtusername.Text);
        if (valueMessage == 0)
        {
            txtusername.Text = "";
            lblCheck.Text = "ชื่อซ้ำกรอกใหม่ด้วยครับ";

        }
        else
        {
            lblCheck.Text = "ชื่อนี้ใช้ได้ครับ";

        }
    }

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        int year = int.Parse(DropDownListYear.SelectedValue);
        int month = int.Parse(DropDownListMonth.SelectedValue);
        int day = int.Parse(DropDownListDay.SelectedValue);
        DateTime birthday = new DateTime(year, month, day);
        User user = new User(txtusername.Text,txtconpassword.Text,txtemail.Text, "users", birthday);
        lblresult.Text = ConnectionClass.RegisterUser(user);
    }
}

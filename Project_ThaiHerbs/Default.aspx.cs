using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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

    protected void DropDownListMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateDayDropDown();
    }

    protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateDayDropDown();
    }

    private void PopulateDayDropDown()
    {
        DropDownListDay.Items.Clear();
        DropDownListDay.Items.Add(new ListItem("Day", ""));

        int selectedMonth, selectedYear;

        if (!string.IsNullOrEmpty(DropDownListMonth.SelectedValue) &&
            !string.IsNullOrEmpty(DropDownListYear.SelectedValue) &&
            int.TryParse(DropDownListMonth.SelectedValue, out selectedMonth) &&
            int.TryParse(DropDownListYear.SelectedValue, out selectedYear))
        {
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

            for (int day = 1; day <= daysInMonth; day++)
            {
                string dayValue = day.ToString();
                DropDownListDay.Items.Add(new ListItem(dayValue, dayValue));
            }
        }
    }

    private void PopulateMonthDropDown()
    {
        if (DropDownListMonth.Items.Count == 0)
        {
            DropDownListMonth.Items.Add(new ListItem("Month", ""));

            for (int i = 1; i <= 12; i++)
            {
                DropDownListMonth.Items.Add(new ListItem(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), i.ToString()));
            }
        }
    }

    private void PopulateYearDropDown()
    {
        if (DropDownListYear.Items.Count == 0)
        {
            DropDownListYear.Items.Add(new ListItem("Year", ""));

            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= 1900; year--)
            {
                DropDownListYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int year, month, day;
        if (int.TryParse(DropDownListYear.SelectedValue, out year) &&
            int.TryParse(DropDownListMonth.SelectedValue, out month) &&
            int.TryParse(DropDownListDay.SelectedValue, out day))
        {
            DateTime birthday = new DateTime(year, month, day);
            Response.Redirect("~/Account/Login.aspx");
        }
        else
        {
            string re = "Please select a valid birthday.";
        }
    }
}
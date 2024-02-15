﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateMonthDropDown();
            PopulateYearDropDown();
            // Initially populate the day dropdown based on the current month
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
                // Disable days greater than the current day if the month and year are current
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
}
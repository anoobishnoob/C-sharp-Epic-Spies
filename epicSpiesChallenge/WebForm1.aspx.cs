using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace epicSpiesChallenge
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                preCalendar.SelectedDate = DateTime.Now.Date;
                newCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                endCalendar.SelectedDate = DateTime.Now.AddDays(21);
            }
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            //spies = $500/d && totalduration > 21 days then + 1K
            TimeSpan totalDurationOfAssignment = endCalendar.SelectedDate.Subtract(newCalendar.SelectedDate);
            double totalCost = totalDurationOfAssignment.TotalDays * 500.0;
            if (totalDurationOfAssignment.TotalDays > 21)
            {
                totalCost += 1000;
            }

            resultLabel.Text = String.Format
                ("Assignment of {0} to Assignment " +
                "{1} is authorized. Budget total: " +
                "{2:C},", 
                codeNameTextBox.Text, 
                newAssignmentTextBox.Text, 
                totalCost);

            TimeSpan timeBetweenAssignment = newCalendar.SelectedDate.Subtract(preCalendar.SelectedDate);
            if (timeBetweenAssignment.TotalDays < 14)
            {
                resultLabel.Text = "spies are needy and need their 14 days between assignments";

                DateTime earliestNewAssignmentDate = preCalendar.SelectedDate.AddDays(14);

                newCalendar.SelectedDate = earliestNewAssignmentDate;
                newCalendar.VisibleDate = earliestNewAssignmentDate;

            }
        }
    }
}
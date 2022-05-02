using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //on initial page load
            if (!IsPostBack)
            {
                //get the session
                List<Student> students = (List<Student>)Session["students"];

                //populate the drop down with added students from AddStudent.aspx
                foreach (Student s in students)
                {
                    //set the value of each list item as the student's id
                    ListItem stuItem = new ListItem();
                    stuItem.Value = (s.Id).ToString();
                    stuItem.Text = s.ToString();
                    studentDropDown.Items.Add(stuItem);
                }

                //populate checkbox list with course options
                List<Course> availableCourses = Helper.GetAvailableCourses();
                for (int i = 0; i < availableCourses.Count; i++)
                {
                    //add a checkbox for the course
                    courseSelection.Items.Add(new ListItem($"{availableCourses[i].Code} {availableCourses[i].Title} - {availableCourses[i].WeeklyHours} hour/week"));

                    //give the checkbox a value containing the course's code
                    courseSelection.Items[i].Value = availableCourses[i].Code;
                }
            }
        }

        protected void studentDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //disable the default dropdown option
            studentDropDown.Items[0].Enabled = false;

            //clear the error message
            errorMsg.Visible = false;

            //get the session
            List<Student> students = (List<Student>)Session["students"];

            // clear the drop down when the default option is selected 
            if (studentDropDown.SelectedValue == "")
            {
                registrationSummary.Visible = false;
                return;
            }
            else
            {
                registrationSummary.Visible = true;
            }

            //display the Registration Summary 
            registrationSummary.InnerText = $"Selected student has registered {students[studentDropDown.SelectedIndex - 1].RegisteredCourses.Count} course(s), {students[studentDropDown.SelectedIndex - 1].TotalWeeklyHours()} hours weekly.";

            //clear the checkboxes
            foreach (ListItem item in courseSelection.Items)
            {
                item.Selected = false;
            }

            //check if selected student has anything registered already
            if (students[studentDropDown.SelectedIndex - 1].RegisteredCourses.Count > 0)
            {
                //select each registered course's corresponding checkbox
                foreach (ListItem item in courseSelection.Items)
                {
                    foreach (Course course in students[studentDropDown.SelectedIndex - 1].RegisteredCourses)
                    {
                        if ((item.Text).Contains(course.Code))
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            //get the session info
            List<Student> students = (List<Student>)Session["students"];

            //create a list to store the selected courses 
            List<Course> selectedCourses = new List<Course>();

            //clear the error message
            errorMsg.Visible = false;

            //display the subtitle 
            subTitle.Visible = true;

            //register the selected student's chosen courses
            try
            {
                //check for no selections made
                if (courseSelection.SelectedIndex == -1)
                {
                    throw new Exception("You need select at least one course");
                }
                else
                {
                    //add the selected courses to the selectedCourses List
                    int numOfCourses = 0;
                    foreach (ListItem item in courseSelection.Items)
                    {
                        if (item.Selected)
                        {
                            numOfCourses++;
                            Course course = Helper.GetCourseByCode(item.Value);
                            selectedCourses.Add(course);
                        }
                    }
                }

                //regester all the selected courses
                students[studentDropDown.SelectedIndex - 1].RegisterCourses(selectedCourses);

                //clear the errors and show the summary
                errorMsg.Visible = false;
                registrationSummary.Visible = true;

                //update registration summary 
                registrationSummary.InnerText = $"Selected student has registered {students[studentDropDown.SelectedIndex - 1].RegisteredCourses.Count} course(s), {students[studentDropDown.SelectedIndex - 1].TotalWeeklyHours()} hours weekly.";

            }
            catch (Exception ex)
            {
                //hide the subtitle
                subTitle.Visible = false;

                //display the error message
                errorMsg.Visible = true;
                errorMsg.InnerText = ex.Message;
            }

        }
    }
}
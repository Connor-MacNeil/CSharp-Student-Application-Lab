/*******************************************************************/
/**                                                               **/
/**                                                               **/
/**    Student Name                :  Connor MacNeil              **/
/**    EMail Address               :  macn0180@algonquinlive.com  **/
/**    Student Number              :  040796516                   **/
/**    Course Number               :  CST 8253                    **/
/**    Lab Section Number          :  Lab Section 303             **/
/**    Professor Name              :  Sanaa Issa                  **/
/**    Assignment Name/Number/Date :  Lab 8 / April 5 2022       **/
/**    Optional Comments           :                              **/
/**                                                               **/
/**                                                               **/
/*******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On first page load
            if (!IsPostBack)
            {
                List<Student> students;

                //Check if session exists   
                if (Session["students"] == null)
                {
                    //create list and add it to the Session
                    students = new List<Student>();
                    Session["students"] = students;
                }
                else
                {
                    //update the existing Session list
                    students = (List<Student>)Session["students"];
                }

                //clear the no students warning if no longer empty
                if (students.Count == 0)
                {
                    warningRow.Visible = true;
                }
                else
                {
                    warningRow.Visible = false;
                }

                //Update the table
                foreach (Student student in students)
                {
                    TableRow newRow = new TableRow();
                    table.Rows.Add(newRow);

                    TableCell cell1 = new TableCell();
                    newRow.Cells.Add(cell1);

                    TableCell cell2 = new TableCell();
                    newRow.Cells.Add(cell2);

                    cell1.Text = student.Id.ToString();
                    cell2.Text = student.Name;
                }
            }

            // On form Submission
            if (IsPostBack)
            {
                //update the existing Session list
                List<Student> students = (List<Student>)Session["students"];

                bool isBlank = false;

                //Check for blank input
                if (StudentName.Text == "" || TypeDropDownList.SelectedIndex == 0)
                {
                    isBlank = true;
                }
                else if (TypeDropDownList.SelectedIndex == 1)
                {
                    students.Add(new FulltimeStudent(StudentName.Text));
                }
                else if (TypeDropDownList.SelectedIndex == 2)
                {
                    students.Add(new ParttimeStudent(StudentName.Text));
                }
                else if (TypeDropDownList.SelectedIndex == 3)
                {
                    students.Add(new CoopStudent(StudentName.Text));
                }


                //Update the table
                foreach (Student student in students)
                {
                    TableRow newRow = new TableRow();
                    table.Rows.Add(newRow);

                    TableCell cell1 = new TableCell();
                    newRow.Cells.Add(cell1);
                    
                    TableCell cell2 = new TableCell();
                    newRow.Cells.Add(cell2);

                    cell1.Text = student.Id.ToString();
                    cell2.Text = student.Name;
                }

                //display empty student warning
                if (students.Count == 0)
                {
                    warningRow.Visible = true;
                }
                else
                {
                    warningRow.Visible = false;
                }

            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            //Reset the input fields
            StudentName.Text = "";
            TypeDropDownList.SelectedIndex = 0;
        }
    }
}
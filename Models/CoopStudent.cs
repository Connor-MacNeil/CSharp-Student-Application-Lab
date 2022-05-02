using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class CoopStudent : Student
    {
        //Properties
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        //Constructor 
        public CoopStudent(string name)
            : base(name)
        {

        }
        //Methods

        // add the given list of courses to this student's registered course list
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            //Check the validity of total weekly hours and number of courses selected

            //check hours total
            int hours = 0;
            foreach (Course course in selectedCourses)
            {
                hours += course.WeeklyHours;
            }

            if (hours > MaxWeeklyHours)
            {
                throw new Exception($"Your selection exceeds the maximum weekly hours: {MaxWeeklyHours}");
            }
            else if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Your selection exceeds the maximum number of courses: {MaxNumOfCourses}");
            }
            else
            {
                //Course selection is valid
                base.RegisterCourses(selectedCourses);
            }
        }
        // return the student's information as a string
        public override string ToString()
        {
            return $"{Id} - {Name}(Co-op)";
        }

    }
}
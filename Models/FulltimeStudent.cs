using System;
using System.Collections.Generic;

namespace Lab8.Models
{
    public class FulltimeStudent : Student
    {
        //Properties
        public static int MaxWeeklyHours { get; set; }
        
        //Constructor
        public FulltimeStudent(string name)
            : base(name)
        {

        }

        //Methods
        // add the given list of courses to this student's registered course list
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            // Check hours total
            int hours = 0;
            foreach (Course course in selectedCourses)
            {
                hours += course.WeeklyHours;
            }
            if (hours > MaxWeeklyHours)
            {
                throw new Exception($"Your selecton exceeds the maximum weekly hours: {MaxWeeklyHours}");
            }

            // Change courses and return
            base.RegisterCourses(selectedCourses);
            return;
        }

        // return the student's information as a string
        public override string ToString()
        {
            return $"{Id} - {Name}(Full time)";
        }


    }
}
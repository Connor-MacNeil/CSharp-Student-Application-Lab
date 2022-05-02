using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ParttimeStudent : Student
    {
        //Properties
        public static int MaxNumOfCourses { get; set; }

        //Constructor
        public ParttimeStudent(string name) 
            : base(name)
        {

        }

        //Methods

        // add the given list of courses to this student's registered course list
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            // Check validity
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Your selection exceeds the maximum number of courses: {MaxNumOfCourses}");
            }
            else
            {
                //amount of courses is valid
                base.RegisterCourses(selectedCourses);
            }
        }
        // return the student's information as a string
        public override string ToString()
        {
            return $"{Id} - {Name}(Part time)";
        }

    }
}
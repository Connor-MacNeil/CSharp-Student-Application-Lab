using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        //Properties
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; }

        //Constructor
        protected Student(string name)
        {
            Name = name;

            //6 Digit id is randomly generated
            Id = new Random().Next(100000, 999999);

            //instantiate the list of courses
            List<Course> courses;

            this.RegisteredCourses = new List<Course>();
        }

        //Methods

        // add the given list of courses to this student's registered course list
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            //remove all elements in RegistredCourses
            this.RegisteredCourses.Clear();

            //add selectedCourses to RegisteredCourses
            foreach(Course course in selectedCourses)
            {
                this.RegisteredCourses.Add(course);
            }
        }

        //Returns the total calculated hours of all courses registered by the student.
        // *Disclaimer: this is only useful for checking the already regestered courses!
        // I did not use this as I needed to error check the user selected courses before actually registering them to the student.*
        public int TotalWeeklyHours()
        {
            int total = 0;
            foreach(Course c in this.RegisteredCourses)
            {
                total += c.WeeklyHours;
            }
            return total;
        }

    }
}
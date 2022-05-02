using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Course
    {
        //Properties
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        //Constructor 
        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }
    }
}
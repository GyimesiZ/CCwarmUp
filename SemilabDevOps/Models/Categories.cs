using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemilabDevOps.Models
{
    public enum Case { Bug, Backlog, Both }
    public enum ArgumentType { Required, Selectable, Decide, Optional}
    public enum ArgumentTarget { Title, Description}

    public class Categories
    {
        public string Name { get; set; }
        public int Thread { get; set; }
        public bool Bug { get; set; } = false;
    
        //public Categories(string Name, int Thread, bool Bug = false)
        //{
        //    this.Name = Name;
        //    this.Thread = Thread;
        //    this.Bug = Bug;
        //}
    }

    public class Threads
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Case Root { get; set; }
    }

    public class Arguments
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public ArgumentType Type { get; set; }
        public ArgumentTarget Target { get; set; }
        public int PlacePriority { get; set; } = 0;
    }

}
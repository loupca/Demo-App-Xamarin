using System;

namespace MASXamarinFormsDemo.Models
{
    /// <summary>
    /// Represents an Idea.
    /// </summary>
    public class Idea
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Department{ get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace MASXamarinFormsDemo.Models
{
    public class MenuItem
    {
        /// <summary>
        /// Menu item text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Filename of the image resource to render for this menu item.
        /// </summary>
        public string ImageFilename { get; set; }
    }
}

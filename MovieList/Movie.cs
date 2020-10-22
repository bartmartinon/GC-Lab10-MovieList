using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList
{
    class Movie
    {
        // Fields
        private string title;
        private string category;

        // Properties
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        // Constructor
        public Movie(string t, string c)
        {
            title = t;
            category = c;
        }
    }
}

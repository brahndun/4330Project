using System.Collections;
using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions;
using Plugin.Media;
using System.Linq;
using Plugin.Media.Abstractions;
using System.ComponentModel;

namespace LoginNavigation
{
    public class Interest 
    {
        public string Subject { get; set; }

        public string[] SubjectInterests { get; set; }
    }
}
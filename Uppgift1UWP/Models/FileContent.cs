﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1UWP.Models
{
    public class FileContent
    {
        public string Text { get; set; }

        public FileContent(string text)
        {
            Text = text;
        }
    }
}

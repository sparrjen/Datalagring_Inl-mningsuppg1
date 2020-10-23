using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1UWP.Models
{
    public class FileContentList : ObservableCollection<FileContent>
    {
        public FileContentList()
        {

        }
        public FileContentList(string text)
        {
            Add(new FileContent(text));
        }
    }
}

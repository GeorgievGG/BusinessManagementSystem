using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmsWpf.ViewModels
{
    public class PFNotesViewModel : ViewModelBase
    {
        public string TabTitle { get; protected set; }

        public PFNotesViewModel()
        {
            TabTitle = "Notes";
        }
    }
}

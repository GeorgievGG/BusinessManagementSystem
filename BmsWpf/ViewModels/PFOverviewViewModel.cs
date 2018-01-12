using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmsWpf.ViewModels
{
    public class PFOverviewViewModel : ViewModelBase
    {
        private string name;

        public string TabTitle { get; protected set; }

        public PFOverviewViewModel()
        {
            TabTitle = "Project Overview";
            this.Name = "ProbaProbaproba";
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged(nameof(Name));
            }
        }
    }
}

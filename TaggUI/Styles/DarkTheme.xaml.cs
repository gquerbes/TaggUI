using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaggUI.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DarkTheme 
    {
        private static readonly Lazy<DarkTheme> lazy = new Lazy<DarkTheme>
            (() => new DarkTheme());

        public static DarkTheme Instance { get { return lazy.Value; } }


        private DarkTheme()
        {
            InitializeComponent();
        }

    }
}
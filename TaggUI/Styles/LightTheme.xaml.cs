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
    public partial class LightTheme 
    {
        private static readonly Lazy<LightTheme> lazy = new Lazy<LightTheme>
            (() => new LightTheme());

        public static LightTheme Instance { get { return lazy.Value; } }


        private LightTheme()
        {
            InitializeComponent();
        }
    }
}
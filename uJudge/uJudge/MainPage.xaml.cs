using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uJudge.Model;
using Xamarin.Forms;

namespace uJudge
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
		{
            InitializeComponent();
            
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
                       
            decimal score;
            if (Decimal.TryParse(button.Text, out score)) {
               ((BaseFighterScores)button.BindingContext).AddScore((int)score);
            }
            
        }
               
    }
}

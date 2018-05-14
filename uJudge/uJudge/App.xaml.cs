using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uJudge.Model;
using Xamarin.Forms;

namespace uJudge
{
	public partial class App : Application
	{
        BlueFighterScores blueFighterScores { get; }
        RedFighterScores redFighterScores { get; }

        public App ()
		{
            blueFighterScores = new BlueFighterScores();
            redFighterScores = new RedFighterScores();

            InitializeComponent();

			MainPage = new uJudge.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

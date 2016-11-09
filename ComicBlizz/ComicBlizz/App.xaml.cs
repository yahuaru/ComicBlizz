using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ComicBlizz
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new ComicBlizz.MainPage();

            var taskImage = WebUtils.LoadImage(new Uri("https://www.google.ru/images/nav_logo242.png"));
            taskImage.Wait();
            var result = taskImage.Result;
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

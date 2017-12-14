using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Puzzle_Tools
{
	public partial class BraillePage : PhoneApplicationPage
	{
		private char[] brailleArray = new char[64];
		private bool newPageInstance = false;

		public BraillePage()
		{
			InitializeComponent();

			newPageInstance = true;

			#region brailleArray Initialization
			for (int k = 0; k < brailleArray.Length; k++)
			{
				brailleArray[k] = '?';
			}
			brailleArray[32] = 'A';
			brailleArray[40] = 'B';
			brailleArray[48] = 'C';
			brailleArray[52] = 'D';
			brailleArray[36] = 'E';
			brailleArray[56] = 'F';
			brailleArray[60] = 'G';
			brailleArray[44] = 'H';
			brailleArray[24] = 'I';
			brailleArray[28] = 'J';
			brailleArray[34] = 'K';
			brailleArray[42] = 'L';
			brailleArray[50] = 'M';
			brailleArray[54] = 'N';
			brailleArray[38] = 'O';
			brailleArray[58] = 'P';
			brailleArray[62] = 'Q';
			brailleArray[46] = 'R';
			brailleArray[26] = 'S';
			brailleArray[30] = 'T';
			brailleArray[35] = 'U';
			brailleArray[43] = 'V';
			brailleArray[29] = 'W';
			brailleArray[51] = 'X';
			brailleArray[55] = 'Y';
			brailleArray[39] = 'Z';
			#endregion
		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			convert();
		}

		private void checkBox_Unchecked(object sender, RoutedEventArgs e)
		{
			convert();
		}

		private void clearButton_Click(object sender, RoutedEventArgs e)
		{
			first.IsChecked = false;
			second.IsChecked = false;
			third.IsChecked = false;
			fourth.IsChecked = false;
			fifth.IsChecked = false;
			sixth.IsChecked = false;
		}

		private void convert()
		{
			int sum = 0;
			if ((bool)sixth.IsChecked)
				sum += 32;
			if ((bool)fifth.IsChecked)
				sum += 16;
			if ((bool)fourth.IsChecked)
				sum += 8;
			if ((bool)third.IsChecked)
				sum += 4;
			if ((bool)second.IsChecked)
				sum += 2;
			if ((bool)first.IsChecked)
				sum += 1;

			if (sum == 0)
				convertedTextBlock.Text = "";
			else
				convertedTextBlock.Text = "" + brailleArray[sum];
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			if (State.ContainsKey("sixth") && newPageInstance)
			{
				sixth.IsChecked = (bool)State["sixth"];
				fifth.IsChecked = (bool)State["fifth"];
				fourth.IsChecked = (bool)State["fourth"];
				third.IsChecked = (bool)State["third"];
				second.IsChecked = (bool)State["second"];
				first.IsChecked = (bool)State["first"];
			}
			base.OnNavigatedTo(e);
		}


		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			newPageInstance = false;

			State["sixth"] = sixth.IsChecked;
			State["fifth"] = fifth.IsChecked;
			State["fourth"] = fourth.IsChecked;
			State["third"] = third.IsChecked;
			State["second"] = second.IsChecked;
			State["first"] = first.IsChecked;
		}
	}
}
using System;
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
	public partial class SemaphorePage : PhoneApplicationPage
	{
		private Dictionary<string, string> flags;

		private List<CheckBox> allCheckBoxes;

		private bool newPageInstance = false;
		private bool initialized = false;

		private string c_fourSpaces = "    ";

		public SemaphorePage()
		{
			InitializeComponent();
			InitializeObjects();

			ConvertFromSemaphore();
		}

		private void InitializeObjects()
		{
			flags = new Dictionary<string, string>();
			flags.Add("76", "A or 1");
			flags.Add("96", "B or 2");
			flags.Add("106", "C or 3");
			flags.Add("126", "D or 4");
			flags.Add("26", "E or 5");
			flags.Add("36", "F or 6");
			flags.Add("46", "G or 7");
			flags.Add("97", "H or 8");
			flags.Add("107", "I or 9");
			flags.Add("123", "J");
			flags.Add("127", "K");
			flags.Add("27", "L");
			flags.Add("37", "M");
			flags.Add("74", "N");
			flags.Add("109", "O");
			flags.Add("129", "P");
			flags.Add("92", "Q");
			flags.Add("93", "R");
			flags.Add("94", "S");
			flags.Add("1012", "T");
			flags.Add("102", "U");
			flags.Add("124", "V");
			flags.Add("23", "W");
			flags.Add("24", "X");
			flags.Add("103", "Y");
			flags.Add("43", "Z");

			allCheckBoxes = new List<CheckBox>();
			allCheckBoxes.Add(checkBox12);
			allCheckBoxes.Add(checkBox2);
			allCheckBoxes.Add(checkBox3);
			allCheckBoxes.Add(checkBox4);
			allCheckBoxes.Add(checkBox6);
			allCheckBoxes.Add(checkBox7);
			allCheckBoxes.Add(checkBox9);
			allCheckBoxes.Add(checkBox10);

			checkBox7.IsChecked = true;
			checkBox6.IsChecked = true;

			initialized = true;
			newPageInstance = true;
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			if(State.ContainsKey("checkBox12") && newPageInstance)
			{
				checkBox12.IsChecked = (bool)State["checkBox12"];
				checkBox2.IsChecked = (bool)State["checkBox2"];
				checkBox3.IsChecked = (bool)State["checkBox3"];
				checkBox4.IsChecked = (bool)State["checkBox4"];
				checkBox6.IsChecked = (bool)State["checkBox6"];
				checkBox7.IsChecked = (bool)State["checkBox7"];
				checkBox9.IsChecked = (bool)State["checkBox9"];
				checkBox10.IsChecked = (bool)State["checkBox10"];
				convertedTextBlock.Text = (string)State["convertedTextBlock"];
			}
			base.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			newPageInstance = false;

			State["checkBox12"] = checkBox12.IsChecked;
			State["checkBox2"] = checkBox2.IsChecked;
			State["checkBox3"] = checkBox3.IsChecked;
			State["checkBox4"] = checkBox4.IsChecked;
			State["checkBox6"] = checkBox6.IsChecked;
			State["checkBox7"] = checkBox7.IsChecked;
			State["checkBox9"] = checkBox9.IsChecked;
			State["checkBox10"] = checkBox10 .IsChecked;
			State["convertedTextBlock"] = convertedTextBlock.Text;
			
			base.OnNavigatedTo(e);
		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			// This code used to only let two check boxes be active at a time,
			// but it's quite buggy and for now I don't want it in use.
			//if (initialized)
			//{
			//	CheckBox source = (CheckBox)e.OriginalSource;

			//	secondBox.IsChecked = false;
			//	secondBox = firstBox;
			//	firstBox = source;

			//	ConvertFromSemaphore();
			//}
			if (initialized)
			{
				ConvertFromSemaphore();
			}
		}

		private void ConvertFromSemaphore()
		{
			string s1 = "";
			string s2 = "";
			
			foreach(CheckBox cb in allCheckBoxes)
			{
				if((bool)cb.IsChecked)
				{
					if (s1.Equals(string.Empty))
						s1 = cb.Name.Replace("checkBox", string.Empty);
					else
						s2 = cb.Name.Replace("checkBox", string.Empty);
				}
			}

			string time1 = s1 + s2;
			string time2 = s2 + s1;

			string spaces = string.Empty;

			string flag = "?";
			if (flags.ContainsKey(time1))
			{
				flag = flags[time1];
			}
			else if (flags.ContainsKey(time2))
			{
				flag = flags[time2];
			}

			// Pad single letter responses so they are in the middle of the text box
			if (flag.Length <= 1)
			{
				spaces = c_fourSpaces;
			}

			convertedTextBlock.Text = spaces + flag;
		}

		private void referenceSheetButton_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/SemaphoreReferencePage.xaml", UriKind.Relative));
		}

		private void DisableAllCheckboxes()
		{
			foreach (CheckBox checkBox in allCheckBoxes)
			{
				checkBox.IsChecked = false;
			}
		}

		private void convertedTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			DisableAllCheckboxes();
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			DisableAllCheckboxes();
		}
	}
}
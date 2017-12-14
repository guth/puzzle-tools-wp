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
	public partial class FiveBitAlphabetPage : PhoneApplicationPage
	{
		private const string c_alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private List<CheckBox> allCheckBoxes;

		public FiveBitAlphabetPage()
		{
			InitializeComponent();
			InitializeObjects();
		}

		private void InitializeObjects()
		{
			allCheckBoxes = new List<CheckBox>();
			allCheckBoxes.Add(checkBox1);
			allCheckBoxes.Add(checkBox2);
			allCheckBoxes.Add(checkBox4);
			allCheckBoxes.Add(checkBox8);
			allCheckBoxes.Add(checkBox16);
		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			RecalculateValue();
		}

		private void checkBox_Unchecked(object sender, RoutedEventArgs e)
		{
			RecalculateValue();
		}

		private void RecalculateValue()
		{
			int value = 0;
			if ((bool)checkBox16.IsChecked)
			{
				value += 16;
			}
			if ((bool)checkBox8.IsChecked)
			{
				value += 8;
			}
			if ((bool)checkBox4.IsChecked)
			{
				value += 4;
			}
			if ((bool)checkBox2.IsChecked)
			{
				value += 2;
			}
			if ((bool)checkBox1.IsChecked)
			{
				value += 1;
			}

			string text = "Value: {0} = {1}";
			if (value == 0 || value > 26)
			{
				text = string.Format(text, value, "?");
			}
			else
			{
				string s = c_alphabet.Substring(value, 1);
				text = string.Format(text, value, s);
			}

			valueTextBlock.Text = text;
		}

		private void clearButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (CheckBox checkBox in allCheckBoxes)
			{
				checkBox.IsChecked = false;
			}
		}
	}
}
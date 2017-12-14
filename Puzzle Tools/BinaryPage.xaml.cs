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
	public partial class BinaryPage : PhoneApplicationPage
	{
		private const string c_ascii = "Ascii: ";
		private const string c_value = "Value: ";

		public BinaryPage()
		{
			InitializeComponent();

		}

		private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			AsciiOutputTextBlock.Text = c_ascii;
			IntegerOutputTextBlock.Text = c_value;

			string text = InputTextBox.Text;

			if (string.IsNullOrEmpty(text))
				return;

			string[] parts = text.Split(new char[]{' ', '\n'});

			for (int k = 0; k < parts.Length; k++)
			{
				int val = convertFromBinary(parts[k]);

				if (val >= 32 && val <= 126) // valid asci char
				{
					char c = (char)val;
					AsciiOutputTextBlock.Text += c + " ";
				}
				IntegerOutputTextBlock.Text += val + " ";
			}
		}

		private int convertFromBinary(string text)
		{
			int value = 0;
			char[] chars = text.ToCharArray();
			for (int k = 0; k < chars.Length; k++)
			{
				char c = chars[chars.Length - 1 - k];
				int val = c - '0'; // 0 or 1
				if (val == 1)
				{
					value += (int)Math.Pow(2, k);
				}
			}

			return value;
		}

		private void ZeroButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text += "0";
		}

		private void OneButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text += "1";
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text = InputTextBox.Text.Substring(0, InputTextBox.Text.Length - 1);
		}

		private void SpaceButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text += " ";
		}

		private void NewLineButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text += "\n";
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text = string.Empty;
		}
	}
}
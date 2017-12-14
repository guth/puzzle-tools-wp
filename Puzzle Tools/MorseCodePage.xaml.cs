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
	public partial class MorseCodePage : PhoneApplicationPage
	{
		private Dictionary<String, String> morseCodeDictionary;

		private bool newPageInstance = false;

		public MorseCodePage()
		{
			InitializeComponent();

			newPageInstance = true;

			morseCodeDictionary = new Dictionary<String, String>();
			morseCodeDictionary.Add(".-", "a");
			morseCodeDictionary.Add("-...", "b");
			morseCodeDictionary.Add("-.-.", "c");
			morseCodeDictionary.Add("-..", "d");
			morseCodeDictionary.Add(".", "e");
			morseCodeDictionary.Add("..-.", "f");
			morseCodeDictionary.Add("--.", "g");
			morseCodeDictionary.Add("....", "h");
			morseCodeDictionary.Add("..", "i");
			morseCodeDictionary.Add(".---", "j");
			morseCodeDictionary.Add("-.-", "k");
			morseCodeDictionary.Add(".-..", "l");
			morseCodeDictionary.Add("--", "m");
			morseCodeDictionary.Add("-.", "n");
			morseCodeDictionary.Add("---", "o");
			morseCodeDictionary.Add(".--.", "p");
			morseCodeDictionary.Add("--.-", "q");
			morseCodeDictionary.Add(".-.", "r");
			morseCodeDictionary.Add("...", "s");
			morseCodeDictionary.Add("-", "t");
			morseCodeDictionary.Add("..-", "u");
			morseCodeDictionary.Add("...-", "v");
			morseCodeDictionary.Add(".--", "w");
			morseCodeDictionary.Add("-..-", "x");
			morseCodeDictionary.Add("-.--", "y");
			morseCodeDictionary.Add("--..", "z");
			morseCodeDictionary.Add(".----", "1");
			morseCodeDictionary.Add("..---", "2");
			morseCodeDictionary.Add("...--", "3");
			morseCodeDictionary.Add("....-", "4");
			morseCodeDictionary.Add(".....", "5");
			morseCodeDictionary.Add("-....", "6");
			morseCodeDictionary.Add("--...", "7");
			morseCodeDictionary.Add("---..", "8");
			morseCodeDictionary.Add("----.", "9");
			morseCodeDictionary.Add("-----", "0");
		}

		private String convertFromMorseCode(String text)
		{
			String[] parts = text.Split(new String[1] { " / " }, StringSplitOptions.None);
			String convertedText = String.Empty;

			for (int k = 0; k < parts.Length; k++)
			{
				String morse = parts[k];
				if (morseCodeDictionary.ContainsKey(morse))
				{
					convertedText += morseCodeDictionary[morse];
				}
				else
				{
					convertedText += morse;
				}
			}

			return convertedText;
		}

		private void MorseCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			String text = MorseCodeTextBox.Text;
			String convertedText = convertFromMorseCode(text);
			ConvertedTextBox.Text = convertedText;
		}

		private void DashButton_Click(object sender, RoutedEventArgs e)
		{
			MorseCodeTextBox.Text += "-";
		}

		private void Dotbutton_Click(object sender, RoutedEventArgs e)
		{
			MorseCodeTextBox.Text += ".";
		}

		private void SpaceButton_Click(object sender, RoutedEventArgs e)
		{
			MorseCodeTextBox.Text += " / ";
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			String text = MorseCodeTextBox.Text;
			if(String.IsNullOrEmpty(text))
				return;
			MorseCodeTextBox.Text = text.Substring(0, text.Length - 1);
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			MorseCodeTextBox.Text = "";
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			if (State.ContainsKey("MorseTextBox") && newPageInstance)
			{
				MorseCodeTextBox.Text = (String)State["MorseTextBox"];
				ConvertedTextBox.Text = (String)State["ConvertedTextBox"];
			}
			base.OnNavigatedTo(e);
		}


		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			newPageInstance = false;

			State["MorseTextBox"] = MorseCodeTextBox.Text;
			State["ConvertedTextBox"] = ConvertedTextBox.Text;
		}
	}
}
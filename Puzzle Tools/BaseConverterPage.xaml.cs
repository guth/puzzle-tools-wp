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
	public partial class BaseConverterPage : PhoneApplicationPage
	{
		const int MIN_BASE = 2;
		const int MAX_BASE = 35;
		const String newBaseChars = "0123456789abcdefghijklmnopqrstuvwxyz";

		TextBlock[] outputTextBlocks;

		public BaseConverterPage()
		{
			InitializeComponent();
			
			outputTextBlocks = new TextBlock[MAX_BASE+1];

			for (int k = MIN_BASE; k <= MAX_BASE; k++)
			{
				outputTextBlocks[k] = new TextBlock();
				outputTextBlocks[k].Text = "Base " + k + ": ";

				outputStackPanel.Children.Add(outputTextBlocks[k]);
			}
		}

		/// <summary>
		/// Converts a number from one base to another. (i.e. Binary to Decimal, etc.)
		/// </summary>
		/// <param name="number">The number to be converted</param>
		/// <param name="fromBase">The number's current base representation</param>
		/// <param name="toBase">The base of the output</param>
		/// <returns>String format of <b>number</b> converted to base <b>newBase</b></returns>
		private String convertBase(String number, int fromBase, int toBase)
		{
			int decimalNumber = convertBaseToDecimal(number, fromBase);
			string newNumber = convertDecimalToBase(decimalNumber, toBase);
			return newNumber;
		}

		/// <summary>
		/// Converts a number in a given base in the range [2, 35] to base 10.
		/// </summary>
		/// <param name="number">The number to be converted</param>
		/// <param name="fromBase">The number's current base representation</param>
		/// <returns>Integer format of <b>number</b> converted to base 10</returns>
		private int convertBaseToDecimal(String number, int fromBase)
		{
			if (number.Length == 0)
				return 0;

			int decimalNumber = 0;
			for (int k = 0; k < number.Length; k++)
			{
				String letter = number.Substring(k, 1);
				int index = newBaseChars.IndexOf(letter);
				//decimalNumber += index * (int)Math.Pow(oldBase, (number.Length - k));
				decimalNumber += (int)Math.Pow(fromBase, number.Length - (k + 1)) * index;
			}

			return decimalNumber;
		}

		/// <summary>
		/// Converts a number from base 10 to the given base in the range [2, 35].
		/// </summary>
		/// <param name="number">The number to be converted</param>
		/// <param name="oldBase">The number's desired base representation</param>
		/// <returns>Integer format of <b>number</b> converted to base <b>newBase</b></returns>
		private String convertDecimalToBase(int number, int toBase)
		{
			if (number == 0)
				return "0";
			if (number == 1)
				return "1";

			int maxPower = 0;
			String newNumber = "";

			for (int k = 0; ; k++)
			{
				if ((int)Math.Pow(toBase, k) > number)
				{
					maxPower = k - 1;
					break;
				}
			}

			while (maxPower >= 0)
			{
				int baseToPower = (int)Math.Pow(toBase, maxPower);
				newNumber += newBaseChars[number / baseToPower];
				number = number % baseToPower;

				maxPower--;
			}
			return newNumber;
		}

		private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			String inputText = inputTextBox.Text.Trim();
			String baseText = inputBaseTextBox.Text.Trim();
			
			int fromBase;
			bool goodBaseFormat = Int32.TryParse(baseText, out fromBase);

			System.Diagnostics.Debug.WriteLine("fromBase: " + fromBase);

			goodBaseFormat = goodBaseFormat && (fromBase >= 2) && (fromBase <= 35);

			if (goodBaseFormat)
			{
				try
				{
					for (int k = MIN_BASE; k <= MAX_BASE; k++)
					{
						String output = convertBase(inputText, fromBase, k);
						outputTextBlocks[k].Text = "Base " + k + ": " + output;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred. Please make sure the input is valid.");
					System.Diagnostics.Debug.WriteLine(ex.StackTrace);
				}
			}
			else
			{
				MessageBox.Show("The input base is not recognized. Please make sure it is a value between 2 and 35.");
			}
		}

	}
}
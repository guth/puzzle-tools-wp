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
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			Console.WriteLine("MainPage's constructor called.");
			InitializeComponent();
		}

		private void MorseCodeTextBlock_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new Uri("/MorseCodePage.xaml", UriKind.Relative));
        }

		private void SemaphoreTextBlock_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/SemaphorePage.xaml", UriKind.Relative));
		}

		private void BrailleTextBlock_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/BraillePage.xaml", UriKind.Relative));
		}

		private void MaritimeFlagsTextBlock_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/MaritimeFlagsPage.xaml", UriKind.Relative));
		}

		private void BaseConverterTextBlock_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/BaseConverterPage.xaml", UriKind.Relative));
		}

		private void FiveBitAlphabetTextBlock_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/FiveBitAlphabetPage.xaml", UriKind.Relative));
		}

		private void BinaryTextBlock_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/BinaryPage.xaml", UriKind.Relative));
		}
	}
}
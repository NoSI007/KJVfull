using System;
using System.Windows;
using System.Windows.Controls;
using System.Speech.Synthesis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KJVfull
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer tts = new SpeechSynthesizer();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            KJVData.init();
            zBList.ItemsSource = KJVData.CBooks;
            NewTestement();
            HolyText.ItemsSource = KJVData.HolyText;
            
        }



        private void zBooks_Click(object sender, RoutedEventArgs e)
        {
            if (zBooks.Content.ToString().Equals("NEW"))
            {
                OldTestement();
            }
            else
            {
                NewTestement();
            }

        }

        private void NewTestement()
        {
            _ = KJVData.LoadAsync(false);
            zBooks.Content = "NEW";
        }

        private void OldTestement()
        {
            _ = KJVData.LoadAsync(true);
            zBooks.Content = "OLD";
        }

        private void zBList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (zBList.SelectedItem == null)
                return;
            string book = zBList.SelectedItem.ToString();
            KJVData.Load(book);
            LoadSection();
        }

        private void LoadSection()
        {
            KJVData.getSection();
            ShowLabel();
        }

        private void zPrevChapter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KJVData.PrevChapter();
                ShowLabel();
            }
            catch
            {
            }
        }

        private void zPrevSection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KJVData.PrevSection();
                ShowLabel();
            }
            catch { }

        }

        private void zNextSection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KJVData.NextSection();
                ShowLabel();
            }
            catch
            {
            }
        }

        private void zNextChapter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KJVData.NextChapter();
                ShowLabel();

            }
            catch
            {
            }
        }

        private void ShowLabel()
        {
            zHeading.Content = string.Format("Reading from {0} {1}:{2}", KJVData.ChosenBook, KJVData.Chapter, KJVData.Section);
            //zChapterNSect.Text = string.Format("{0} / {1}", KJVData.BookMatrix.Chapter, KJVData.BookMatrix.LastSection);
        }

        private void zGo_Click(object sender, RoutedEventArgs e)
        {
            KJVData.RequstChapter(zChapterNSect.Text);
            LoadSection();
        }

        private void zChapterNSect_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(zChapterNSect.Text.EndsWith(":") == true)
            {
                KJVData.RequstMatrix(zChapterNSect.Text);
                Rectify();
            }
        }

        private void Rectify()
        {
            zMaxCaS.Text = string.Format("{0} / {1}", KJVData.CurChapter, KJVData.CurMaxSection);
        }

        private void zSpeak_Click(object sender, RoutedEventArgs e)
        {
            string lineNoRem = null;

            foreach(string line in HolyText.Items)
            {
                lineNoRem = Regex.Replace(line, KJVData.cas, "");
                tts.Speak(lineNoRem);
            }
        }
    }
}

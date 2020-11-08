using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gecko;
using System.Windows.Forms.Integration;
using Gecko.Events;
using System.IO;

namespace Browser_Glora_1._0
{

    public partial class MainWindow : Window
    {
        GeckoWebBrowser browser = new GeckoWebBrowser();
        TextChanger t = new TextChanger();



        public MainWindow()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            GeckoBrowser.Child = browser;
            

        }
        Stream stream = new FileStream("history.txt", FileMode.Create);
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            browser.Navigate("https://developer.mozilla.org/en-US/docs/Mozilla");
        }
        

        private void B_Go_Click(object sender, RoutedEventArgs e)
        {
            Corecture(SerchBar.Text);
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Corecture(SerchBar.Text);
            }
            else
            {

            }
        }

        private void B_Home_Click(object sender, RoutedEventArgs e)
        {
            browser.Navigate("https://developer.mozilla.org/en-US/docs/Mozilla");
            SerchBar.Text = null;
        }

        private void B_Forward_Click(object sender, RoutedEventArgs e)
        {
            
            browser.GoBack();
        }

        private void B_Backward_Click(object sender, RoutedEventArgs e)
        {
            browser.GoForward();
        }

        private void GeckoBrowser_ChildChanged(object sender, ChildChangedEventArgs e)
        {

        }
        
        public void Corecture(string ulr)
        {
            browser.Navigate(t.TextChange(ulr));
        }

        private void B_Refresh_Click(object sender, RoutedEventArgs e)
        {
            browser.Refresh();
        }
    }

    public class IsLoaded
    {
        public string SearchText { get; set; }
        public bool SearchTestIsNull(string t)
        {
            if (t == null)
            {
                return false;
            }
            return true;
        }

        
    }
    public class TextChanger
    {
        public bool FullSearchBar(string text)
        {
            if (text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string TextChange(string text)
        {
            
            if (FullSearchBar(text))
            {

                if (text.Contains("https://www.")) //Not ready
                {
                    return text;
                    //using (StreamWriter sw = new StreamWriter(stream))
                    //{
                    //    sw.WriteLine(SerchBar.Text);
                    //    sw.Close();

                    //}

                }
                else if (text.Contains("www.")) //Not ready
                {
                    text = "https://" + text;
                    return text;
                    //using (StreamWriter sw = new StreamWriter(stream))
                    //{
                    //    sw.WriteLine(SerchBar.Text);
                    //    sw.Close();

                    //}

                }
                else //Not ready
                {
                    text = "https://" + "www." + text;
                    return text;
                    //using (StreamWriter sw = new StreamWriter(stream)) 
                    //{
                    //    sw.WriteLine(SerchBar.Text);
                    //    sw.Close();
                    //}


                }

            }
            return null;

        }
    }
}

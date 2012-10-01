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
using Hardcodet.Wpf.TaskbarNotification;

namespace Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Tray icon (book)
        /// </summary>
        private TaskbarIcon taskBarIcon = new TaskbarIcon();

        private Engine engine = new Engine();
        
        public MainWindow()
        {
            InitializeComponent();

            // Tray icon
            taskBarIcon.Icon = (System.Drawing.Icon)Properties.Resources.book;
            taskBarIcon.ToolTipText = "Enditu Reader";
            taskBarIcon.Visibility = System.Windows.Visibility.Collapsed;
            taskBarIcon.TrayLeftMouseUp += taskBarIcon_TrayLeftMouseUp;

            // TODO awaiting for activity


            // TODO reading methods choice

            // TODO reading methods
        }



        /// <summary>
        /// Tray icon clicked event
        /// </summary>
        void taskBarIcon_TrayLeftMouseUp(object sender, RoutedEventArgs e)
        {
            this.Show();
            this.WindowState = System.Windows.WindowState.Normal;
            taskBarIcon.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Change window state event
        /// </summary>
        private void Window_StateChanged_1(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case System.Windows.WindowState.Minimized:  // Minimalizowanie
                    taskBarIcon.Visibility = System.Windows.Visibility.Visible;
                    this.Hide();
                    break;
                case System.Windows.WindowState.Maximized:  // Maksymalizowanie
                case System.Windows.WindowState.Normal:     // Normalne okno
                    this.Show();
                    taskBarIcon.Visibility = System.Windows.Visibility.Collapsed;
                    break;
            }
        }
        
        /// <summary>
        /// Read button click event
        /// </summary>
        private void Read_Click(object sender, RoutedEventArgs e)
        {
            engine.Read(Clipboard.GetText(), TBRead);
        }

        private void SliderPerLetterDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.IsInitialized)
            {
                int temp = (int)Math.Round((double)e.NewValue, 0);
                LabelPerLetterDelay.Content = temp.ToString();
                engine.CharactersPerMinute = temp;
            }
        }
    }
}

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

namespace Lecture_Example___Date_Picker_and_DateTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           
            InitializeComponent();
        }

        private void btnDisplayTime_Click(object sender, RoutedEventArgs e)
        {
            rtbDisplay.Text = "";
           
            int month = 0;
            int day = 0;
            int year = 0;

            bool isMonth = int.TryParse(tbBdMonth.Text, out month);
            bool isDay = int.TryParse(tbBdDay.Text, out day);
            bool isYear = int.TryParse(tbBdYear.Text, out year);


            if (isMonth && isDay && isYear)
            {
                DateTime now = DateTime.Now;
                DateTime Bday = new DateTime(year, month, day);

                rtbDisplay.Text += $"Birthday Date: {Bday.ToShortDateString()}\n";

                TimeSpan ageIndays = now - Bday;
                int age = (int)(ageIndays.Days / 365.25);
                rtbDisplay.Text += $"Years old: {age}\n";
            }
            else if (!isMonth || !isDay || !isYear)
            {
                MessageBox.Show("Enter Number only for mm/dd/yy");
            } 
           
            bool isSelectedDpDate = dpDate.SelectedDate.HasValue;
            bool isSelectedCalDate = CalDate.SelectedDate.HasValue;

            if (isSelectedDpDate)
            {
                rtbDisplay.Text += $"Picker: {dpDate.SelectedDate.Value.ToShortDateString()}\n";
            }
            if (isSelectedCalDate)
            {
                rtbDisplay.Text += $"Calender: {CalDate.SelectedDate.Value.ToShortDateString()}\n";
            }
            if (isSelectedDpDate && isSelectedCalDate)
            {
                TimeSpan DatePickerAndCalender = CalDate.SelectedDate.Value - dpDate.SelectedDate.Value;
                rtbDisplay.Text += $"Date differences between Calendar and Picker: {DatePickerAndCalender.Days} Days ";
            }
            else
            {
                DateTime now = DateTime.Now;
                rtbDisplay.Text += $"{now}";
            }

            
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Finals
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

        private void UpdateBookingsList(DateTime selectedDate)
        {
            using (var db = new RestaurantData("OODExam_AdamBokobza")) 
            {
                var bookings = db.Bookings
                    .Where(b => DbFunctions.TruncateTime(b.BookingsDate) == DbFunctions.TruncateTime(selectedDate))
                    .Select(b => new
                    {
                        CustomerName = b.Customer.Name,
                        CustomerPhone = b.Customer.ContactNumber,
                        Participants = b.NumberOfParticipants
                    }).ToList();

                bookingsListBox.ItemsSource = bookings.Select(b => $"{b.CustomerName} ({b.CustomerPhone}) – Party of {b.Participants}");

                int totalParticipants = bookings.Sum(b => b.Participants);
                capacityTextBlock.Text = "Capacity: 40";
                bookingsTextBlock.Text = $"Bookings: {totalParticipants}";
                availableTextBlock.Text = $"Available: {40 - totalParticipants}";
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            if (datePicker.SelectedDate.HasValue)
            {
                UpdateBookingsList(datePicker.SelectedDate.Value);
            }
        }
    }
}

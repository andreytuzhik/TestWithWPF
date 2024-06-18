using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfApplication1.Infrastructure;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public int VipCustomerCount => Customers.Count(c => c.MembershipType == "VIP");
        public int ActiveCustomerCount => Customers.Count(c => c.IsActive);

        public ICommand ShowDebtCommand { get; }

        public MainViewModel()
        {
            Customers = new ObservableCollection<Customer>
            {
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", MembershipType = "Normal", IsActive = true, DebtAmount = 100.0m },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", MembershipType = "VIP", IsActive = true, DebtAmount = 200.0m },
                new Customer { Id = 3, FirstName = "Tom", LastName = "Brown", MembershipType = "Normal", IsActive = false, DebtAmount = 300.0m },
                new Customer { Id = 4, FirstName = "Alice", LastName = "Johnson", MembershipType = "Normal", IsActive = true, DebtAmount = 150.0m },
                new Customer { Id = 5, FirstName = "Bob", LastName = "Williams", MembershipType = "VIP", IsActive = false, DebtAmount = 250.0m },
                new Customer { Id = 6, FirstName = "Eva", LastName = "Miller", MembershipType = "Normal", IsActive = true, DebtAmount = 50.0m },
                new Customer { Id = 7, FirstName = "Michael", LastName = "Davis", MembershipType = "VIP", IsActive = true, DebtAmount = 180.0m },
                new Customer { Id = 8, FirstName = "Sophia", LastName = "Garcia", MembershipType = "Normal", IsActive = true, DebtAmount = 220.0m },
                new Customer { Id = 9, FirstName = "David", LastName = "Martinez", MembershipType = "Normal", IsActive = false, DebtAmount = 120.0m },
                new Customer { Id = 10, FirstName = "Olivia", LastName = "Lopez", MembershipType = "VIP", IsActive = true, DebtAmount = 300.0m }
            };


            foreach (var customer in Customers)
            {
                customer.PropertyChanged += Customer_PropertyChanged;
            }

            ShowDebtCommand = new DelegateCommand(ShowDebt);
            Customers.CollectionChanged += (s, e) => RaisePropertyChanged(nameof(VipCustomerCount));
            Customers.CollectionChanged += (s, e) => RaisePropertyChanged(nameof(ActiveCustomerCount));
        }

        private void Customer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Customer.IsActive))
            {
                RaisePropertyChanged(nameof(ActiveCustomerCount));
            }
        }

        private void ShowDebt(object parameter)
        {
            if (parameter is decimal debtAmount)
            {
                System.Windows.MessageBox.Show($"Debt Amount: {debtAmount:C}", "Debt Amount", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
        }
    }
}

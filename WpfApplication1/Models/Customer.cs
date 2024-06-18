using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApplication1.Models
{
    public class Customer : INotifyPropertyChanged
    {
        private bool _isActive;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MembershipType { get; set; }
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged();
                }
            }
        }
        public decimal DebtAmount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

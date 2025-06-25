using System;
using System.ComponentModel;

namespace ModulaLocal.Models
{
    public class BorrowTicket : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string QRCode { get; set; }
        public string AddressModula { get; set; }
        public int Status { get; set; }
        bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected == value) return;
                isSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
using ModulaLocal.Models;
using System.Collections.ObjectModel;

namespace ModulaLocal.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<BorrowTicket> Items { get; }

        public MainPageViewModel()
        {
            Items = new ObservableCollection<BorrowTicket>
            {
                new BorrowTicket {
                    Id=1,
                    ProductCode="C1",
                    ProductName = "Camera A",
                    AddressModula="Khay 1 - VT1"
                },
                new BorrowTicket {
                    Id=2,
                    ProductCode="B2",
                    ProductName = "Ballpoint pen B",
                    AddressModula="Khay 2 - VT2"
                },
                new BorrowTicket {
                    Id=3,
                    ProductCode="N3",
                    ProductName = "A5 Notebook C",
                    AddressModula="Khay 3 - VT3"
                },
            };
        }
    }
}
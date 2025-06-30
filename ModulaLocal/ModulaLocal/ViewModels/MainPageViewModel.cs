using ModulaLocal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ModulaLocal.ViewModels
{
    public class MainPageViewModel
    {
        #region Fields

        private List<BorrowTicket> items;
        private List<BorrowTicket> selectedItems;

        #endregion Fields

        #region Properties

        public List<BorrowTicket> Items
        {
            get => items;
            set { items = value; OnPropertyChanged(nameof(Items)); }
        }

        public List<BorrowTicket> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        #endregion Properties

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion INotifyPropertyChanged implementation

        public MainPageViewModel()
        {
            Items = new List<BorrowTicket>
            {
                new BorrowTicket
                {
                    TotalPage = 1,
                    ID = 82680,
                    Status = 7,
                    StatusNew = 7,
                    ProductRTCID = 1,
                    ProductRTCQRCodeID = 0,
                    DateBorrow = DateTime.Parse("2025-06-04T19:54:02.087"),
                    DateReturnExpected = DateTime.Parse("2025-06-04T00:00:00"),
                    PeopleID = 1181,
                    Project = "13",
                    DateReturn = null,
                    Note = "332",
                    NumberBorrow = null,
                    AdminConfirm = false,
                    BillExportTechnicalID = 0,
                    FullName = "NV076 - Lê Thế Anh",
                    ProductGroupRTCID = 75,
                    ProductCode = "VL-A01W-1-3P VD1",
                    ProductName = "AREA LIGHT",
                    Maker = "VST",
                    UnitCountID = 11,
                    Number = 0,
                    StatusProduct = false,
                    CreateDate = DateTime.Parse("2020-07-01T00:00:00"),
                    NumberInStore = 0,
                    Serial = "VD1",
                    SerialNumber = "VD1",
                    PartNumber = "VD1",
                    CreatedBy = "AdminTech",
                    LocationImg = "",
                    ProductCodeRTC = "Z00000001",
                    BorrowCustomer = true,
                    AddressBox = "K2-T3.3-K2-T3.3 VST LIGHT (Bar light)",
                    BillExportCode = "",
                    BillTypeText = "",
                    BillStatus = 0,
                    IsDelete = null,
                    DepartmentName = "Kỹ thuật",
                    ProductQRCode = null,
                    UnitCountName = "PCS",
                    UserZaloID = "",
                    ModulaLocationName = " - ",
                    ModulaLocationCode = "",
                    AxisX = 0,
                    AxisY = 0,
                    StatusText = "Đăng kí mượn",
                    RowNumber = 3,
                    DualDate = 0
                }
            };
        }
    }
}
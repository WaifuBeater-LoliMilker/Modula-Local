using ModulaLocal.Models;
using ModulaLocal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ModulaLocal.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<BorrowTicket> items;
        private List<BorrowTicket> selectedItems;
        private BorrowTicket focusedRow;

        #endregion Fields

        #region Properties

        public ObservableCollection<BorrowTicket> Items
        {
            get => items;
            set { items = value; OnPropertyChanged(nameof(Items)); }
        }

        public List<BorrowTicket> SelectedItems
        {
            get => selectedItems;
            set { selectedItems = value; }
        }

        public BorrowTicket FocusedRow
        {
            get => focusedRow;
            set { focusedRow = value; }
        }

        #endregion Properties

        #region Commands

        public ICommand LoadDataCommand => new Command(async () => await OnLoadData());
        public ICommand CallCommand => new Command(async () => await OnCall());
        public ICommand ReturnCommand => new Command(async () => await OnReturn());
        public ICommand DoneCommand => new Command(async () => await OnDone());

        #endregion Commands

        public MainPageViewModel()
        {
            Items = new ObservableCollection<BorrowTicket>();
        }

        private async Task OnLoadData()
        {
            var modulaStore = DependencyService.Get<ModulaStore>();
            try
            {
                var result = await modulaStore.GetAll();
                Items.Clear();
                foreach (var item in result)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", ex.Message, "OK");
            }
        }

        private async Task OnCall()
        {
            if (FocusedRow == null)
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng chọn sản phẩm trước khi gọi khay", "OK");
            }
            var modulaStore = DependencyService.Get<ModulaStore>();
            try
            {
                var data = new TrayInfo
                {
                    Code = FocusedRow.ModulaLocationCode,
                    Name = FocusedRow.ProductCode,
                    AxisX = FocusedRow.AxisX,
                    AxisY = FocusedRow.AxisY
                };
                var result = await modulaStore.CallTray(data);
                if (!result)
                    await App.Current.MainPage.DisplayAlert("Thông báo", "Thao tác không thành công, vui lòng thử lại", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", ex.Message, "OK");
            }
        }

        private async Task OnReturn()
        {
            if (FocusedRow == null)
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng chọn sản phẩm trước khi gọi khay", "OK");
            }
            var modulaStore = DependencyService.Get<ModulaStore>();
            try
            {
                var data = new TrayInfo
                {
                    Code = FocusedRow.ModulaLocationCode,
                    Name = FocusedRow.ProductCode,
                    AxisX = FocusedRow.AxisX,
                    AxisY = FocusedRow.AxisY
                };
                var result = await modulaStore.ReturnTray(data);
                if (!result)
                    await App.Current.MainPage.DisplayAlert("Thông báo", "Thao tác không thành công, vui lòng thử lại", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", ex.Message, "OK");
            }
        }

        private async Task OnDone()
        {
            var modulaStore = DependencyService.Get<ModulaStore>();
            try
            {
                var rows = new List<ModulaStatusUpdate>();
                foreach (var item in SelectedItems)
                {
                    var row = new ModulaStatusUpdate
                    {
                        ID = item.ID,
                        PeopleID = item.PeopleID,
                        StatusPerson = item.IsBorrow ? 1 : 2
                    };
                    rows.Add(row);
                }
                await modulaStore.Update(rows);
                var result = await modulaStore.GetAll();
                Items.Clear();
                foreach (var item in result)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", ex.Message, "OK");
            }
        }
    }
}
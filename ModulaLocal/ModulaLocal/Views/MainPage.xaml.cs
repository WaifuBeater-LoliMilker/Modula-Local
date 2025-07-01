using ModulaLocal.Models;
using ModulaLocal.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ModulaLocal.Views
{
    public partial class MainPage : ContentPage
    {
        private bool isCheckingAll = false;
        private bool _isSortAscending = true;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MainPageViewModel vm && vm.LoadDataCommand.CanExecute(null))
                vm.LoadDataCommand.Execute(null);
        }

        private void SelectAllCheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (BindingContext is MainPageViewModel vm)
            {
                isCheckingAll = true;
                foreach (var item in vm.Items)
                {
                    item.IsSelected = e.Value;
                }
                isCheckingAll = false;
            }
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (BindingContext is MainPageViewModel vm)
            {
                vm.SelectedItems = vm.Items.Where(m => m.IsSelected).ToList();

                if (isCheckingAll) return;
                SelectAllCheckbox.CheckedChanged -= SelectAllCheckbox_CheckedChanged;
                SelectAllCheckbox.IsChecked = vm.SelectedItems.Count >= vm.Items.Count;
                SelectAllCheckbox.CheckedChanged += SelectAllCheckbox_CheckedChanged;
            }
        }
        private void SortStatusGrid_Tapped(object sender, EventArgs e)
        {
            _isSortAscending = !_isSortAscending;
            SortStatusLabel.Text = _isSortAscending
                ? "▲"
                : "▼";

            if (BindingContext is MainPageViewModel vm)
            {
                var sorted = _isSortAscending
                ? vm.Items.OrderBy(x => x.StatusText).ToList()
                : vm.Items.OrderByDescending(x => x.StatusText).ToList();
                vm.Items.Clear();
                foreach (var item in sorted)
                    vm.Items.Add(item);
            }
        }

        private void RefreshBtn_Clicked(object sender, EventArgs e)
        {
            _isSortAscending = true;
            SortStatusLabel.Text = "";
        }
    }
}
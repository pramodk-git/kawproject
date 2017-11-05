﻿using System;

using Xamarin.Forms;

namespace KAWApp
{
    public partial class PicturesPage : ContentPage
    {
        ItemsViewModel viewModel;

        public PicturesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();

        }



        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}

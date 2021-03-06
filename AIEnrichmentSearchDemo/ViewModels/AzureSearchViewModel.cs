﻿using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using AIEnrichmentSearchDemo.Models;
using AIEnrichmentSearchDemo.Services;

using Xamarin.Forms;
using System.Windows.Input;

namespace AIEnrichmentSearchDemo.ViewModels
{
    public class AzureSearchViewModel : BaseViewModel
    {
        private ObservableCollection<Value> azureSearchResults;

        public ObservableCollection<Value> AzureSearchResults
        {
            get { return azureSearchResults; }
            set { azureSearchResults = value; OnPropertyChanged(); }
        }

        public Command<string> AzureSearchCommand { get; set; }

        public AzureSearchViewModel()
        {
            AzureSearchCommand = new Command<string>(async (x) => await AzureSearch(x));
        }

        public async Task AzureSearch(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
            {
                var results = await AzureSearchService.Search(term);
                AzureSearchResults = new ObservableCollection<Value>(results.Value);
            }
            else
            {
                AzureSearchResults = new ObservableCollection<Value>();
            }
        }
    }
}

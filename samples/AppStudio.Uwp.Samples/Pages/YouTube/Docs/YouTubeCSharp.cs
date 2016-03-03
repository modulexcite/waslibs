﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

using AppStudio.DataProviders.YouTube;

namespace AppStudio.Uwp.Samples
{
    public sealed partial class YouTubeSample : Page
    {
        public YouTubeSample()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public ObservableCollection<object> Items
        {
            get { return (ObservableCollection<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty = DependencyProperty
            .Register("Items", typeof(ObservableCollection<object>), typeof(VariableSizedGridSample), new PropertyMetadata(null));

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {           
            GetItems();
        }

        public void GetItems()
        {
            string apiKey = "YourApiKey";
            string queryParam = @"MicrosoftLumia";
            YouTubeQueryType queryType = YouTubeQueryType.Channels;
            int maxRecordsParam = 20;

            this.Items = new ObservableCollection<object>();
            var _youTubeDataProvider = new YouTubeDataProvider(new YouTubeOAuthTokens { ApiKey = apiKey });
            var config = new YouTubeDataConfig
            {
                Query = queryParam,
                QueryType = queryType
            };

            var items = await _youTubeDataProvider.LoadDataAsync(config, maxRecordsParam);
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}

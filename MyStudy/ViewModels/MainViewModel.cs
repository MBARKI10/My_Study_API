﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MyStudy.Resources;
using System.Net;
using Newtonsoft.Json;
using MyStudy.Models;

namespace MyStudy.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        const string apiUrl = @"http://localhost:50296/api/Posts";

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        //private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        //public string SampleProperty
        //{
        //    get
        //    {
        //        return _sampleProperty;
        //    }
        //    set
        //    {
        //        if (value != _sampleProperty)
        //        {
        //            _sampleProperty = value;
        //            NotifyPropertyChanged("SampleProperty");
        //        }
        //    }
        //}

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        //public string LocalizedSampleProperty
        //{
        //    get
        //    {
        //        return AppResources.SampleProperty;
        //    }
        //}

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            //this.Items.Add(new ItemViewModel() { ID = "0", LineOne = "runtime one", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            //this.Items.Add(new ItemViewModel() { ID = "1", LineOne = "runtime two", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            //this.Items.Add(new ItemViewModel() { ID = "2", LineOne = "runtime three", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            //this.Items.Add(new ItemViewModel() { ID = "3", LineOne = "runtime four", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            //this.Items.Add(new ItemViewModel() { ID = "4", LineOne = "runtime five", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            //this.Items.Add(new ItemViewModel() { ID = "5", LineOne = "runtime six", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            //this.Items.Add(new ItemViewModel() { ID = "6", LineOne = "runtime seven", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            //this.Items.Add(new ItemViewModel() { ID = "7", LineOne = "runtime eight", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
            //this.Items.Add(new ItemViewModel() { ID = "8", LineOne = "runtime nine", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            //this.Items.Add(new ItemViewModel() { ID = "9", LineOne = "runtime ten", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            //this.Items.Add(new ItemViewModel() { ID = "10", LineOne = "runtime eleven", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            //this.Items.Add(new ItemViewModel() { ID = "11", LineOne = "runtime twelve", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            //this.Items.Add(new ItemViewModel() { ID = "12", LineOne = "runtime thirteen", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            //this.Items.Add(new ItemViewModel() { ID = "13", LineOne = "runtime fourteen", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            //this.Items.Add(new ItemViewModel() { ID = "14", LineOne = "runtime fifteen", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            //this.Items.Add(new ItemViewModel() { ID = "15", LineOne = "runtime sixteen", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });

            if (this.IsDataLoaded == false)
            {
                this.Items.Clear();
                this.Items.Add(new ItemViewModel() { ID = "0", LineOne = "Please Wait...", LineTwo = "Please wait while the posts is downloaded from the server.", LineThree = null });
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadPostCompleted);
                webClient.DownloadStringAsync(new Uri(apiUrl));
            }

            //this.IsDataLoaded = true;
        }

        private void webClient_DownloadPostCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.Items.Clear();
                if (e.Result != null)
                {
                    var posts = JsonConvert.DeserializeObject<Post[]>(e.Result);
                    int id = 0;
                    foreach (Post post in posts)
                    {
                        this.Items.Add(new ItemViewModel()
                        {
                            ID = (id++).ToString(),
                            LineOne = post.Title,
                            LineTwo = post.Author,
                            LineThree = post.Description.Replace("\n", " ")
                        });
                    }
                    this.IsDataLoaded = true;
                }
            }
            catch (Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    LineOne = "An Error Occurred",
                    LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
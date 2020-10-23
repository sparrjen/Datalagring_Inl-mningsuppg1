﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Uppgift1UWP.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Uppgift1UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public FileContentList fileContentList = new FileContentList();

        private async void btnPickFile_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".xml");
            picker.FileTypeFilter.Add(".csv");
            picker.FileTypeFilter.Add(".json");
      
            StorageFile file = await picker.PickSingleFileAsync();



            if (file != null)
            {

                if
                    (file.ContentType == "application/json")
                {
                    
                    string text = await FileIO.ReadTextAsync(file);
                    var jasonobject = JsonConvert.DeserializeObject<dynamic>(text);
                    

                    try
                    {
                        fileContentList.Add(new FileContent($"This is the content of the file:\n {jasonobject.FirstName} {jasonobject.LastName} {jasonobject.City}"));
                    }
                    catch { }
                    
                }

                else if (file.ContentType == "text/xml")
                {
                    string text = await FileIO.ReadTextAsync(file);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(text);


                    foreach (XmlNode node in xmlDoc.DocumentElement)
                    {
                        string textout = node.InnerText; 
                        try
                        {
                            fileContentList.Add(new FileContent($"\nThe persons name and home town is:\n {textout} "));
                        }
                        catch { }
                    }
                }

                else if
                    (file.ContentType == "application/vnd.ms-excel")
                {
                    string text = await FileIO.ReadTextAsync(file);
                    text = text.Replace(";",  " ");


                    try
                    {
                        fileContentList.Add(new FileContent($"This is the content of file:\n{text}"));
                    }
                    catch { }
                }
            }
            else
            {
               
            }


        }

    }
}


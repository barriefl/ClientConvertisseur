using ClientConvertisseurV1.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Devise> devises;
        private double montant;
        private double resultat;

        public ObservableCollection<Devise> Devises
        {
            get
            {
                return this.devises;
            }

            set
            {
                this.devises = value;
                OnPropertyChanged("Devises");
            }
        }

        public double Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
                OnPropertyChanged("Montant");
            }
        }

        public double Resultat
        {
            get
            {
                return this.resultat;
            }

            set
            {
                this.resultat = value;
                OnPropertyChanged("Resultat");
            }
        }

        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7057/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
            {
                MessageAsync("API non disponible !", "Erreur");
            }
            else 
            {
                Devises = new ObservableCollection<Devise>(result);
            }
        }

        private async void MessageAsync(string content, string title)
        {
            ContentDialog errorMessage = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };

            errorMessage.XamlRoot = this.Content.XamlRoot;
            ContentDialogResult result = await errorMessage.ShowAsync();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void ButtonConvertir_Click(object sender, RoutedEventArgs e)
        {
            Devise devise = (Devise)ComboBoxDevises.SelectedItem;
            if (devise == null)
            {
                MessageAsync("Vous devez sélectionner une devise !", "Erreur");
            }
            else 
            {
                this.Resultat = this.Montant * devise.Taux;
            }         
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ClientConvertisseurV2.Models;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.Input;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel: ObservableObject
    {
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        public IRelayCommand ButtonSetConversion { get; }

        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();

            ButtonSetConversion = new RelayCommand(ActionSetConversion);
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

            errorMessage.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await errorMessage.ShowAsync();
        }

        private void ActionSetConversion()
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

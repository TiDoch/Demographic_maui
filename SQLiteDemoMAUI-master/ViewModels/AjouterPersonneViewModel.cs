using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MardocheDespagne_MAUI_demo.Models;
using MardocheDespagne_MAUI_demo.Services;
using MardocheDespagne_MAUI_demo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardocheDespagne_MAUI_demo.ViewModels
{
    [QueryProperty(nameof(Persone), "Persone")]
    public partial class AjouterPersonneViewModel : ObservableObject
    {
        [ObservableProperty]
        private Personne _persone = new Personne();

        private readonly IPersonneService _personneService;
        public AjouterPersonneViewModel(IPersonneService personneService)
        {
            _personneService = personneService;
        }

        [RelayCommand]
        public async void AddUpdatePersonne()
        {
            int response = -1;
            if (Persone.Id > 0)
            {
                response = await _personneService.UpdatePerson(Persone);
            }
            else
            {
                response = await _personneService.AddPerson(new Models.Personne
                {
                    Email = Persone.Email,
                    FirstName = Persone.FirstName,
                    LastName = Persone.LastName,
                    Ddn = Persone.Ddn,
                    Nunero = Persone.Nunero,
                    Photo = Persone.Photo,

                });
            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Succès", "Informations Sauvegardées", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Attention", "Erreur dans la sauvegarde des informations", "OK");
            }

        }

        [RelayCommand]
        public async void ReturnToMainPage()
        {
            
            await Shell.Current.DisplayAlert("Attention", "Si Les informations n'ont pas été ajoutées, elles ne seront pas sauvegardées.", "OK");

            await Shell.Current.Navigation.PopAsync();
        }


        [RelayCommand]
        private async Task TakePicture()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        Persone.Photo = photo.FullPath;
                    }
                }
               
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Erreur lors de la capture de la photo : {ex.Message}");
            }
        }


    }
}

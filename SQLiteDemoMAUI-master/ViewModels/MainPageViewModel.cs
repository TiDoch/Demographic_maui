using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MardocheDespagne_MAUI_demo.Models;
using MardocheDespagne_MAUI_demo.Services;
using MardocheDespagne_MAUI_demo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardocheDespagne_MAUI_demo.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public static List<Personne> PersonneList { get; private set; } = new List<Personne>();
        public ObservableCollection<Personne> Personnes { get; set; } = new ObservableCollection<Personne>();

        private readonly IPersonneService _personService;
        public MainPageViewModel(IPersonneService personService)
        {
            _personService = personService;
        }



        [RelayCommand]
        public async void GetPersonList()
        {
            Personnes.Clear();
            var personneList = await _personService.GetPersonList();
            if (personneList?.Count > 0)
            {
                personneList = personneList.OrderBy(f => f.FullName).ToList();
                foreach (var p in personneList)
                {
                    Personnes.Add(p);
                }
                PersonneList.Clear();
                PersonneList.AddRange(personneList);
            }
        }


        [RelayCommand]
        public async void AddUpdatePerson()
        {
            await AppShell.Current.GoToAsync(nameof(AjouterPersonne));
        }

        [RelayCommand]
        public async void EditPerson(Personne personne)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("Persone", personne);
            await AppShell.Current.GoToAsync(nameof(AjouterPersonne), navParam);
        }

        [RelayCommand]
        public async void DeletePerson(Personne personne)
        {
            var delResponse = await _personService.DeletePerson(personne);
            if (delResponse > 0)
            {
                GetPersonList();
            }
        }


        [RelayCommand]
        public async void Action(Personne personne)
        {
            var response = await AppShell.Current.DisplayActionSheet("->", "OK", null, "Editer", "Effacer");
            if (response == "Editer")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("Persone", personne);
                await AppShell.Current.GoToAsync(nameof(AjouterPersonne), navParam);
            }
            else if (response == "Effacer")
            {
                var delResponse = await _personService.DeletePerson(personne);
                if (delResponse > 0)
                {
                    GetPersonList();
                }
            }
        }
    }
}

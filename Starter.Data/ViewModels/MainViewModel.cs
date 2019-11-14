using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Starter.Data.Entities;
using Starter.Data.Interfaces;
using Starter.Data.Interfaces.Repositories;

namespace Starter.Data.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public Visibility IsDeleteVisible
        //{
        //    get => _isDeleteVisible;

        //    set
        //    {
        //        _isDeleteVisible = value;
        //        OnPropertyChanged(nameof(IsDeleteVisible));
        //    }
        //}

        //public Visibility IsSaveVisible
        //{
        //    get => _isSaveVisible;

        //    set
        //    {
        //        _isSaveVisible = value;
        //        OnPropertyChanged(nameof(IsSaveVisible));
        //    }
        //}

        public Cat SelectedItem
        {
            get => _selectedItem;

            set
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));

                //IsDeleteVisible = _selectedItem.Id != Guid.Empty ? Visibility.Visible : Visibility.Hidden;

                //IsSaveVisible = !string.IsNullOrEmpty(_selectedItem.Name) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        public ObservableCollection<IEntity> Cats
        {
            get => _cats;

            set
            {
                _cats = value;

                OnPropertyChanged(nameof(Cats));
            }
        }

        public ObservableCollection<object> Abilities
        {
            get => _abilities;

            set
            {
                _abilities = value;

                OnPropertyChanged(nameof(Abilities));
            }
        }

        public MainViewModel(ICatRepository repository)
        {
            _repository = repository;

            //IsDeleteVisible = Visibility.Hidden;
            //IsSaveVisible = Visibility.Hidden;

            ResetSelected();
            LoadData();
        }

        private async void LoadData()
        {
            Cats = new ObservableCollection<IEntity>(await _repository.GetAllAsync());
            Abilities = new ObservableCollection<object>(GetEnum<Ability>());
        }

        public void ResetSelected()
        {
            SelectedItem = new Cat();
        }

        public async void Save()
        {
            await _repository.AddAsync(SelectedItem);

            SelectedItem = new Cat();
            Cats = new ObservableCollection<IEntity>(await _repository.GetAllAsync());
        }

        public async void Delete()
        {
            await _repository.DeleteAsync(SelectedItem);

            SelectedItem = new Cat();
            Cats = new ObservableCollection<IEntity>(await _repository.GetAllAsync());
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static IEnumerable<object> GetEnum<T>()
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);
            var pairs =
                Enumerable.Range(0, names.Length)
                    .Select(i => new
                    {
                        Name = (string)names.GetValue(i),
                        Value = (int)values.GetValue(i)
                    });

            pairs.Append(new
            {
                Name = string.Empty,
                Value = -1
            });

            return pairs.OrderBy(pair => pair.Name);
        }

        private readonly ICatRepository _repository;

        private ObservableCollection<IEntity> _cats;

        private ObservableCollection<object> _abilities;

        private Cat _selectedItem;

        //private Visibility _isDeleteVisible;

        //private Visibility _isSaveVisible;
    }
}
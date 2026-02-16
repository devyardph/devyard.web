using DYS.Devyard.Web.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MvvmBlazor.ViewModel;

namespace DYS.Devyard.Web.Shared.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public readonly NavigationManager _navigationManager;
        public readonly IJSRuntime _jsRuntime;

        #region PROPERTIES
        public bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set => Set(ref _isReadOnly, value, nameof(IsReadOnly));
        }

        public bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value, nameof(IsBusy));
        }

        public bool _isSaving = false;
        public bool IsSaving
        {
            get => _isSaving;
            set => Set(ref _isSaving, value, nameof(IsSaving));
        }

        public bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value, nameof(IsLoading));
        }

        public string _action = "";
        public string Action
        {
            get => _action;
            set => Set(ref _action, value, nameof(Action));
        }



        public NotificationDto _notification = new NotificationDto();
        public NotificationDto Notification
        {
            get => _notification;
            set => Set(ref _notification, value);
        }

        public string _header;
        public string Header
        {
            get => _header;
            set => Set(ref _header, value, nameof(Header));
        }

        public string _subHeader;
        public string SubHeader
        {
            get => _subHeader;
            set => Set(ref _subHeader, value, nameof(SubHeader));
        }

        public List<ErrorDto> _errors = new List<ErrorDto>();
        public List<ErrorDto> Errors
        {
            get => _errors;
            set => Set(ref _errors, value, nameof(Errors));
        }

        public string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        #endregion

        public BaseViewModel(NavigationManager navigationManager,
                             IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
        }

        public void NavigationToPath(string path)
        {
            StateHasChanged();
            _navigationManager.NavigateTo(path);

        }
    }
}

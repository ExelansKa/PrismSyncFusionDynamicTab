using Prism.Navigation.Regions;
using PrismTabApp.Core.Mvvm;
using PrismTabApp.Services.Interfaces;

namespace PrismTabApp.Modules.TabContent.ViewModels
{
    public class TabContentViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IMessageService _messageService;
        private string _message = "Test Message...";

        public TabContentViewModel(IRegionManager regionManager, IMessageService messageService) : base(regionManager)
        {
            this._regionManager = regionManager;
            this._messageService = messageService;
            Message = this._messageService.GetMessage();
        }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

    }
}

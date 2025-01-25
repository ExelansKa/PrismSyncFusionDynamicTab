using Prism.Commands;
using Prism.Events;
using Prism.Navigation.Regions;
using PrismTabApp.Core.Mvvm;
using PrismTabApp.Modules.ModuleName.Model;
using PrismTabApp.Modules.TabContent.Views;
using PrismTabApp.Services.Interfaces;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace PrismTabApp.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private ObservableCollection<TabModel> _tabModels;
        public ObservableCollection<TabModel> TabModels
        {
            get { return _tabModels; }
            set { SetProperty(ref _tabModels, value); }
        }

        private TabModel _selectedTab;
        public TabModel SelectedTab
        {
            get { return _selectedTab; }
            set { SetProperty(ref _selectedTab, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand AddTabCommand { get; }
        public IRegionManager _regionManager { get; }

        private readonly IEventAggregator _eventAggregator;

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService, IEventAggregator eventAggregator) : base(regionManager)
        {
            TabModels = new ObservableCollection<TabModel>();

            Message = messageService.GetMessage();
            
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            AddTabCommand = new DelegateCommand(OnAddTab);
        }

        private void AddTab(string header)
        {
            var tab = new TabModel { Header = header, RegionName = $"Region{Guid.NewGuid()}" };
            TabModels.Add(tab);
            _regionManager.RegisterViewWithRegion(tab.RegionName, typeof(TabContentView)); // TabView, her tab'ın içeriği için kullanılacak view
        }

        private void OnAddTab()
        {
            int newTabNumber = TabModels.Count + 1;
            AddTab($"Tab {newTabNumber}");
        }

        private void AddTab()
        {
            var tabItem = new TabItemExt
            {
                Header = "Yeni Sekme",
                Content = new ContentControl()
            };

            _eventAggregator.GetEvent<Events.TabAddedEvent>().Publish(new Events.TabAddedEvent.Model { Name = tabItem.Name});

            // Region'ı oluştur ve view'ı ekle
            var region = _regionManager.RegisterViewWithRegion<TabContentView>("TabRegion");
            //region..Add(tabItem);

            // View'ı tab içerisine ekle
            _regionManager.RequestNavigate("TabRegion", "TabContentView");
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}

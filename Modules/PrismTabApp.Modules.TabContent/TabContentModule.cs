using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using PrismTabApp.Events;
using PrismTabApp.Modules.TabContent.Views;
using System;

namespace PrismTabApp.Modules.TabContent
{
    public class TabContentModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        public TabContentModule(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _eventAggregator.GetEvent<Events.TabAddedEvent>().Subscribe(ShowView, true);
        }

        private void ShowView(TabAddedEvent.Model model)
        {
            // Event geldiğinde view'ı belirli bir region'a yerleştir
            _regionManager.RequestNavigate("MainRegion", "TabContentView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // View'ı kaydedin
            containerRegistry.RegisterForNavigation<TabContentView>("TabContentView");
        }
    }
}
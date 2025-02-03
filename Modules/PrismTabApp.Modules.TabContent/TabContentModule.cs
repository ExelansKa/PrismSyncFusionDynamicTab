using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using PrismTabApp.Events;
using PrismTabApp.Modules.TabContent.ViewModels;
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
            //_regionManager.RequestNavigate("MainRegion", "TabContentView");

            //_regionManager.RequestNavigate(model.Name, "TabContentView", navigationResult =>
            //{
            //    if (navigationResult.Success != true)
            //    {
            //        // Hata veya başarısız navigasyon durumu
            //        var error = navigationResult.Exception;
            //        // Hata mesajını günlüğe kaydet veya kullanıcıya göster
            //    }
            //});

            // Eğer TabContentView transient ise, her çağrıda yeni instance:
            _regionManager.RegisterViewWithRegion(model.Name, (container) =>
                {
                    var view = container.Resolve<TabContentView>();

                    return view;
                });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TabContentView>("TabContentView");
            //containerRegistry.RegisterForNavigation<TabContentView, TabContentViewModel>();
            //containerRegistry.RegisterForNavigation<TabContentView>();
            //containerRegistry.RegisterForNavigation<TabContentView>("TabContentView-1");
            //containerRegistry.RegisterForNavigation<TabContentView>("TabContentView-2");
            //containerRegistry.Register<TabContentView>();
        }
    }
}
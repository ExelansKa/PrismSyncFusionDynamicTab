using Prism.Mvvm;

namespace PrismTabApp.Modules.ModuleName.Model
{
    public class TabModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _header;
        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }
        // Her tab'ın benzersiz bir bölge adına ihtiyacı var
        public string RegionName { get; set; }
    }
}

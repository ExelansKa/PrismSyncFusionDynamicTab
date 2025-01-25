namespace PrismTabApp.Events
{
    public class TabAddedEvent : PubSubEvent<TabAddedEvent.Model>
    {
        public class Model : BindableBase
        {           
            private string _name;
            private string _path;

            public Model()
            {
            }

            public Model(string path)
            {
                _path = path;
            }
            

            public string Name
            {
                get => _name;
                set => SetProperty(ref _name, value);
            }

            public string Path
            {
                get => _path;
                set => SetProperty(ref _path, value);
            }
        }
    }
}

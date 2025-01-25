using Moq;
using Prism.Events;
using Prism.Navigation.Regions;
using PrismTabApp.Modules.ModuleName.ViewModels;
using PrismTabApp.Services.Interfaces;
using Xunit;

namespace PrismTabApp.Modules.ModuleName.Tests.ViewModels
{
    public class ViewAViewModelFixture
    {
        Mock<IMessageService> _messageServiceMock;
        Mock<IRegionManager> _regionManagerMock;
        Mock<IEventAggregator> _eventaggregatorMock;
        const string MessageServiceDefaultMessage = "Some Value";

        public ViewAViewModelFixture()
        {
            var messageService = new Mock<IMessageService>();
            messageService.Setup(x => x.GetMessage()).Returns(MessageServiceDefaultMessage);
            _messageServiceMock = messageService;

            _regionManagerMock = new Mock<IRegionManager>();

            _eventaggregatorMock = new Mock<IEventAggregator>();
        }

        [Fact]
        public void MessagePropertyValueUpdated()
        {
            var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object, _eventaggregatorMock.Object);

            _messageServiceMock.Verify(x => x.GetMessage(), Times.Once);

            Assert.Equal(MessageServiceDefaultMessage, vm.Message);
        }

        [Fact]
        public void MessageINotifyPropertyChangedCalled()
        {
            var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object, _eventaggregatorMock.Object);
            Assert.PropertyChanged(vm, nameof(vm.Message), () => vm.Message = "Changed");
        }
    }
}

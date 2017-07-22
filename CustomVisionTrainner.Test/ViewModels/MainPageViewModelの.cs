using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomVisionTrainner.ViewModels;
using CustomVisionTrainner.Service;
using Moq;

namespace CustomVisionTrainner.Test.ViewModels
{
    [TestFixture]
    public class MainPageViewModelの
    {
        [Test]
        public void CustomVisionServiceのkeyが入力されていないときはポップアップするテスト()
        {
            var popupServiceMock = new Mock<IPopupService>();
            
            var mainWindowViewModel = new MainWindowViewModel(popupServiceMock.Object);

            mainWindowViewModel.StartLearningCommand.Execute();

            popupServiceMock.Verify(popupservice => popupservice.Popup("Input Custom Vison Service Key"), Times.Once);
        }

        [Test]
        public void BingImageSearchのkeyが入力されていないときはポップアップするテスト()
        {
            var popupServiceMock = new Mock<IPopupService>();

            var mainWindowViewModel = new MainWindowViewModel(popupServiceMock.Object);

            mainWindowViewModel.StartLearningCommand.Execute();

            popupServiceMock.Verify(popupservice => popupservice.Popup("Input Bing Search Service Key"), Times.Once);
        }

        [Test]
        public void EmotionAPIのkeyが入力されていないときはポップアップするテスト()
        {
            var popupServiceMock = new Mock<IPopupService>();

            var mainWindowViewModel = new MainWindowViewModel(popupServiceMock.Object);

            mainWindowViewModel.StartLearningCommand.Execute();

            popupServiceMock.Verify(popupservice => popupservice.Popup("Input Emotion API Service Key"), Times.Once);
        }
    }
}

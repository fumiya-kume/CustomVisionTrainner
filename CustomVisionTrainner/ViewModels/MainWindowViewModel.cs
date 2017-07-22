using CustomVisionTrainner.Service;
using CustomVisionTrainner.Usecase;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Reactive.Linq;

namespace CustomVisionTrainner.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IPopupService _popupservice;

        public ReactiveProperty<string> CustomVisionKey { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> BingImageSearchKey { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> EmotionAPIKey { get; set; } = new ReactiveProperty<string>();
        public ReactiveCommand StartLearningCommand { get; set; } = new ReactiveCommand();

        public MainWindowViewModel(IPopupService popupService)
        {
            _popupservice = popupService;

            StartLearningCommand
                .Where(_ => string.IsNullOrWhiteSpace(CustomVisionKey.Value))
                .Subscribe(_ => popupService.Popup("Input Custom Vison Service Key"));

            StartLearningCommand
                .Where(_ => string.IsNullOrWhiteSpace(BingImageSearchKey.Value))
                .Subscribe(_ => popupService.Popup("Input Bing Search Service Key"));

            StartLearningCommand
                .Where(_ => string.IsNullOrWhiteSpace(EmotionAPIKey.Value))
                .Subscribe(_ => popupService.Popup("Input Emotion API Service Key"));
        }
    }
}

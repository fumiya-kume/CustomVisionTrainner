using Prism.Mvvm;
using Reactive.Bindings;

namespace CustomVisionTrainner.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> CustomVisionKey { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> BingImageSearchKey { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> EmotionAPIKey { get; set; } = new ReactiveProperty<string>();
        public ReactiveCommand StartLearningCommand { get; set; } = new ReactiveCommand();

        public MainWindowViewModel()
        {

        }
    }
}

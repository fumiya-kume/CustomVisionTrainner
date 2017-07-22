using Reactive.Bindings;
using System.Threading.Tasks;

namespace CustomVisionTrainner.Usecase
{
    public interface IMemberInfoRepositry
    {
        ReactiveProperty<bool> IsLoadError { get; set; }
        ReactiveCollection<string> MemberNameList { get; set; }

        void LoadKeyakiInfomatin();
    }
}
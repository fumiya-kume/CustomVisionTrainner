using CustomVisionTrainner.Entity;
using Reactive.Bindings;

namespace CustomVisionTrainner.Repositry
{
    public interface IBingImageSearchRepositry
    {
        ReactiveCollection<MemberImageData> ImageURLList { get; set; }

        void GetImage();
    }
}
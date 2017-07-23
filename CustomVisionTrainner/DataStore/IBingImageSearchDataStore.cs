using CustomVisionTrainner.Entity;
using Reactive.Bindings;

namespace CustomVisionTrainner.DataStore
{
    public interface IBingImageSearchDataStore
    {
        ReactiveCollection<MemberImageData> ImageURLList { get; set; }

        void getImageList(string searchText, int count);
    }
}
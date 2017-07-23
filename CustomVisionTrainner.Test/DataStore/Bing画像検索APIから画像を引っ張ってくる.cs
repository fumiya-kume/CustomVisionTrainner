using NUnit.Framework;

namespace CustomVisionTrainner.DataStore.Tests
{
    [TestFixture()]
    public class Bing画像検索APIから画像を引っ張ってくる
    {
        private BingImageSearchDataStoreFromAPI _bingImageSearchDataStoreFromAPI => new BingImageSearchDataStoreFromAPI();

        [TestCase("長濱ねる", 10)]
        public void 正常に画像検索できたテスト(string searchText, int count)
        {
            _bingImageSearchDataStoreFromAPI.PropertyChanged += (o, s) =>
            {
                if (s.PropertyName == "ImageURLList")
                {
                    _bingImageSearchDataStoreFromAPI.ImageURLList.Count.IsNot(0);
                }
            };

            _bingImageSearchDataStoreFromAPI.getImageList(searchText, count);
        }

    }
}
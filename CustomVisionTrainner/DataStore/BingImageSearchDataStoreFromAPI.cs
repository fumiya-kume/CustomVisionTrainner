using CustomVisionTrainner.Entity;
using Newtonsoft.Json;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomVisionTrainner.DataStore
{
    public class BingImageSearchDataStoreFromAPI : BindableBase, IBingImageSearchDataStore
    {
        private readonly string BingAPIKey = "04c9e3e8fa4747dd9787c21bc80f1854";
        private readonly string BaseURL = $"https://api.cognitive.microsoft.com/bing/v5.0/images/search?";

        public ReactiveCollection<MemberImageData> ImageURLList { get; set; } = new ReactiveCollection<MemberImageData>();
        public async void getImageList(string searchText, int count)
        {
            var json = await SendBingRequest(searchText, count);
            ImageURLList = (ReactiveCollection<MemberImageData>)new ObservableCollection<MemberImageData>(AnalyzeBingResponse(searchText, json).Cast<MemberImageData>());
        }

        private string GenerateRequestQuery(string memberName, int count) => $"{BaseURL}?q={memberName}&count={count}";

        /// <summary>
        /// Send to Bing Image Search API 
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="count"></param>
        /// <returns>Json</returns>
        private async Task<string> SendBingRequest(string memberName, int count)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", BingAPIKey);
                var result = await client.GetAsync(GenerateRequestQuery(memberName, count));
                return await result.Content.ReadAsStringAsync();
            }
        }

        private IEnumerable<MemberImageData> AnalyzeBingResponse(string memberName, string json)
            => JsonConvert.DeserializeObject<BingImageSearchResponse>(json).value
                .Select(value => value.contentUrl)
                .Select(image => new MemberImageData() { MemberName = memberName, ImageURL = image });
    }
}

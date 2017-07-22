using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomVisionTrainner.DataStore
{
    public class MemberInfoDataStoreFromInternet : IMemberInfoDataStore
    {
        private readonly string WebsiteURL = "http://www.keyakizaka46.com/s/k46o/search/artist?ima=0000";
        private string html;
        

        public async Task<IEnumerable<string>> GetKeyakiMemberInfo()
        {
            html = await LoadHTML();
            return await Node2String();
        }

        private async Task<string> LoadHTML()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(WebsiteURL);
                return await result.Content.ReadAsStringAsync();
            }
        }

        private async Task<IHtmlDocument> ParseHtmlelementAsync() => await new HtmlParser().ParseAsync(html);

        private async Task<IHtmlCollection<IElement>> AnalyzeKANJIMemberNodeCollection()
            => (await ParseHtmlelementAsync()).QuerySelectorAll(
                "body > div > div > div > div.l-inner > div.sorteted-wrp.js-member-change > div.sorted.sort-default.current > div:nth-child(1) > ul > div > ul > li");

        private async Task<IHtmlCollection<IElement>> AnalyzeHIRAGANAMemberNodeCollection()
            => (await ParseHtmlelementAsync()).QuerySelectorAll(
                "body > div > div > div > div.l-inner > div.sorteted-wrp.js-member-change > div.sorted.sort-default.current > div:nth-child(2) > ul > div > ul > li");

        private async Task<IEnumerable<string>> Node2String() 
            => (await AnalyzeKANJIMemberNodeCollection()).Concat(await AnalyzeHIRAGANAMemberNodeCollection()).Select(node => node.QuerySelector(" a > p.name").InnerHtml);
    }
}

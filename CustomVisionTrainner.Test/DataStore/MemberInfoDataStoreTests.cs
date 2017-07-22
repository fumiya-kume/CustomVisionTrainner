using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace CustomVisionTrainner.DataStore.Tests
{
    [TestFixture()]
    public class KeyakiMemberInfoFromWebsiteTests
    {
        private MemberInfoDataStoreFromInternet _keyakiMemberInfoFromWebsite = new MemberInfoDataStoreFromInternet();

        [Test()]
        public async Task データを取得するテスト()
        {
            var memberlist = await _keyakiMemberInfoFromWebsite.GetKeyakiMemberInfo();
            memberlist.Count().IsNot(0);
            var list = memberlist.ToList();
        }

        [Test()]
        public void WebSiteからHTMLを取得できるかテスト()
        {
            _keyakiMemberInfoFromWebsite.AsDynamic().LoadHTML();
            (_keyakiMemberInfoFromWebsite.AsDynamic().html as string).IsNot("");
        }

        [Test]
        public async Task 漢字メンバー情報のノードを取得するテスト()
        {
            await _keyakiMemberInfoFromWebsite.GetKeyakiMemberInfo();

            var NodeCollection = (await _keyakiMemberInfoFromWebsite.AsDynamic().AnalyzeKANJIMemberNodeCollection() as IHtmlCollection<IElement>);
            NodeCollection.Count().IsNot(0);
        }

        [Test]
        public async Task ひらがなメンバー情報のノードを取得するテスト()
        {
            await _keyakiMemberInfoFromWebsite.GetKeyakiMemberInfo();

            var NodeCollection = (await _keyakiMemberInfoFromWebsite.AsDynamic().AnalyzeHIRAGANAMemberNodeCollection() as IHtmlCollection<IElement>);
            NodeCollection.Count().IsNot(0);
        }
    }
}
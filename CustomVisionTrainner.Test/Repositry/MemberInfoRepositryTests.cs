using NUnit.Framework;
using CustomVisionTrainner.Usecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomVisionTrainner.DataStore;
using Moq;

namespace CustomVisionTrainner.Usecase.Tests
{
    [TestFixture()]
    public static class MemberInfoRespositryTests
    {
        public static class LoadKeyakiInfomatinoTest
        {
            [Test]
            public static void 正常に読み込まれるテスト()
            {
                var MemberInfoDataStoreMock = new Mock<IMemberInfoDataStore>();
                MemberInfoDataStoreMock.Setup(obj
                    => obj.GetKeyakiMemberInfo()).ReturnsAsync(new List<string>() { "長濱ねる", "hoge" });

                var MemberInfoUsecase = new MemberInfoRespositry(MemberInfoDataStoreMock.Object);

                MemberInfoUsecase.LoadKeyakiInfomatin();

                MemberInfoUsecase.MemberNameList.Count.IsNot(0);

                MemberInfoDataStoreMock.Verify(obj => obj.GetKeyakiMemberInfo(), Times.Once);
            }
        }
    }
}
using CustomVisionTrainner.DataStore;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomVisionTrainner.Usecase
{
    public class MemberInfoRespositry : IMemberInfoRepositry
    {
        private readonly IMemberInfoDataStore _keyakiMemberInfomationWebsite;
        public ReactiveProperty<bool> IsLoadError { get; set; } = new ReactiveProperty<bool>(false);
        public ReactiveCollection<string> MemberNameList { get; set; } = new ReactiveCollection<string>();

        public MemberInfoRespositry(IMemberInfoDataStore keyakiMemberInfomationFromWebsite)
        {
            _keyakiMemberInfomationWebsite = keyakiMemberInfomationFromWebsite;
        }

        public async void LoadKeyakiInfomatin()
        {
            IEnumerable<string> memberList;

            try
            {
                memberList = await _keyakiMemberInfomationWebsite.GetKeyakiMemberInfo();
            }
            catch (Exception)
            {
                IsLoadError.Value = true;
                return;
            }
            if (memberList.Count() == 0) IsLoadError.Value = true;

            MemberNameList.Clear();

            foreach (var item in memberList.ToArray())
            {
                MemberNameList.Add(item);
            }
        }
    }
}

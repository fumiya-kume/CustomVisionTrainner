using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVisionTrainner.DataStore
{
    public interface IMemberInfoDataStore
    {
        Task<IEnumerable<string>> GetKeyakiMemberInfo();
    }
}
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi
{
    public interface IDataService
    {        
        NumGroup.NumSingleResult PostNumber(string text); // 回傳所有資料        
    }
}

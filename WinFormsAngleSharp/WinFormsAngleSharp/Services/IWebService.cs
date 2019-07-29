using System.Threading.Tasks;
using WinFormsAngleSharp.Models;

namespace WinFormsAngleSharp.Services
{
    interface IWebService
    {
        Task<WikiInfo> GetWikiPageAsync(string address);
    }
}

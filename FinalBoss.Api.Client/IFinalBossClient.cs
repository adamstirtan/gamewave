using FinalBoss.Api.Dto;

using System.Threading.Tasks;

namespace FinalBoss.Api.Client
{
    public interface IFinalBossClient
    {
        Task<T> GetAsync<T>(string requestUri);

        Task<T> PostAsync<T>(string requestUri, T dto) where T : BaseDto;

        Task<T> PutAsync<T>(string requestUri, T dto) where T : BaseDto;

        Task<bool> DeleteAsync<T>(string requestUri);
    }
}
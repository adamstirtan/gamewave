using GameWave.ObjectModel;

namespace GameWave.API.Contracts
{
    public interface ICompanyService : IService<Company>, IServiceAsync<Company>
    { }
}
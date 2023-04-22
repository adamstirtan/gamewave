using GameWave.API.Contracts;
using GameWave.API.Search.Queries;
using GameWave.ObjectModel;

namespace GameWave.API.Search
{
    public sealed class CompanySearch : BaseSearch<Company>
    {
        public override IQueryObject<Company> ToQueryObject()
        {
            CompanySearchQuery query = new();

            return Id.HasValue ? query.ById(Id.Value) : query.ByCriteria(this);
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
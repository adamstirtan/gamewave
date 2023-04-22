using GameWave.ObjectModel;

namespace GameWave.API.Search.Queries
{
    public sealed class CompanySearchQuery : QueryObject<Company>
    {
        public CompanySearchQuery ById(long id)
        {
            And(x => x.Id == id);

            return this;
        }

        public CompanySearchQuery ByCriteria(CompanySearch criteria)
        {
            if (!string.IsNullOrEmpty(criteria.Name))
            {
                And(x => x.Name.Contains(criteria.Name));
            }

            if (!string.IsNullOrEmpty(criteria.Description))
            {
                And(x => x.Description.Contains(criteria.Description));
            }

            return this;
        }
    }
}
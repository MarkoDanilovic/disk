using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class TracksSpecification : BaseSpecification<Track>
{
    public TracksSpecification(TrackSpecParams trackParams) 
        : base(x =>
            ((string.IsNullOrEmpty(trackParams.Search) || (x.TrackName.ToLower().Contains(trackParams.Search))) ||
            (string.IsNullOrEmpty(trackParams.Search) || (x.Producer.ArtistName.ToLower().Contains(trackParams.Search)))) &&
            (!trackParams.GenreId.HasValue || x.GenreId == trackParams.GenreId) &&
            (!trackParams.MediumId.HasValue || x.MediumId == trackParams.MediumId)
            )
    {
        AddInclude(x => x.Genre);
        AddInclude(x => x.Producer);
        AddInclude(x => x.Label);
        AddInclude(x => x.Medium);
        AddOrderBy(x => x.TrackName);
        ApplyPaging(trackParams.PageSize * (trackParams.PageIndex-1), trackParams.PageSize);

        if (!string.IsNullOrEmpty(trackParams.Sort))
        {
            switch (trackParams.Sort)
            {
                case "priceAsc": 
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc" : 
                    AddOrderByDescending(p => p.Price);
                    break;
                case "nameAsc":
                    AddOrderBy(p => p.TrackName);
                    break;
                case "nameDesc":
                    AddOrderByDescending(p => p.TrackName);
                    break;
                default: AddOrderBy(n => n.TrackName);
                    break;
            }
        }
        
    }

    public TracksSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Genre);
        AddInclude(x => x.Producer);
        AddInclude(x => x.Label);
        AddInclude(x => x.Medium);
        
        
    }
}
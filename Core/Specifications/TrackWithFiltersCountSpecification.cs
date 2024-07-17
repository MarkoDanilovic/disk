using Core.Entities;

namespace Core.Specifications;

public class TrackWithFiltersCountSpecification : BaseSpecification<Track>
{
    public TrackWithFiltersCountSpecification(TrackSpecParams trackParams) : 
        base(x =>
            (string.IsNullOrEmpty(trackParams.Search) || (x.TrackName.ToLower().Contains(trackParams.Search))) &&
            (!trackParams.GenreId.HasValue || x.GenreId == trackParams.GenreId) &&
            (!trackParams.MediumId.HasValue || x.MediumId == trackParams.MediumId)
    )
    {
    }
}
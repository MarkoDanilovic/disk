﻿namespace Core.Specifications;

public class TrackSpecParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;

    private int _pageSize = 4 ;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public int? GenreId { get; set; }
    public int? MediumId { get; set; }
    public string? Sort { get; set; }

    private string? _search;

    public string? Search
    {
        get => _search;
        set => _search = value.ToLower();
    }
}
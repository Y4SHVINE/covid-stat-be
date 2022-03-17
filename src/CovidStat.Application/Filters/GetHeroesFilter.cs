﻿using CovidStat.Domain.Entities.Enums;

namespace CovidStat.Application.Filters
{
    public class GetHeroesFilter : PaginationInfoFilter
    {
        public string Name { get; set; }
        public string Nickname { get; set; }

        public int? Age { get; set; }

        public string Individuality { get; set; }
        public HeroType? HeroType { get; set; }

        public string Team { get; set; }
    }
}

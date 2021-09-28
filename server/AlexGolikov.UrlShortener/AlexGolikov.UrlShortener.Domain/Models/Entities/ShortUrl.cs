﻿using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlexGolikov.UrlShortener.Domain.Models.Entities
{
    [Index(nameof(Url), IsUnique = true)]
    public class ShortUrl : BaseEntity
    {
        [Url]
        public string Url { get; set; }

        public Guid OriginalUrlId { get; set; }

        public OriginalUrl OriginalUrl { get; set; }
    }
}

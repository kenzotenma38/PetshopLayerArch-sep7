using System;

namespace Petshop.DAL.DataContext.Entities;

public class FooterInfo : TimeStample
{
    public string NewsletterText { get; set; } = null!;

    public string FacebookUrl { get; set; } = null!;

    public string TwitterUrl { get; set; } = null!;

    public string PinterestUrl { get; set; } = null!;

    public string InstagramUrl { get; set; } = null!;

    public string YoutubeUrl { get; set; } = null!;

    public string CopyrightText { get; set; } = null!;
}



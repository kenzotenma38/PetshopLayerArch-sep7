using Microsoft.EntityFrameworkCore;
using Petshop.BLL.Services.Contracts;
using Petshop.BLL.ViewModels;
using Petshop.DAL.DataContext;
using Petshop.DAL.DataContext.Entities;

namespace Petshop.BLL.Services;

public class HeaderManager : IHeaderService
{
    private readonly AppDbContext _dbContext;

    public HeaderManager(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HeaderViewModel?> GetHeaderViewModelAsync()
    {
        var info = await _dbContext.HeaderInfos.AsNoTracking().FirstOrDefaultAsync(x => !x.IsDeleted);
        if (info == null) return null;

        return new HeaderViewModel
        {
            LogoPath = info.LogoPath,
            Phone = info.Phone,
            Email = info.Email
        };
    }
}

public class FooterManager : IFooterService
{
    private readonly AppDbContext _dbContext;

    public FooterManager(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FooterViewModel?> GetFooterViewModelAsync()
    {
        var info = await _dbContext.FooterInfos.AsNoTracking().FirstOrDefaultAsync(x => !x.IsDeleted);
        if (info == null) return null;

        return new FooterViewModel
        {
            NewsletterText = info.NewsletterText,
            FacebookUrl = info.FacebookUrl,
            TwitterUrl = info.TwitterUrl,
            PinterestUrl = info.PinterestUrl,
            InstagramUrl = info.InstagramUrl,
            YoutubeUrl = info.YoutubeUrl,
            CopyrightText = info.CopyrightText
        };
    }
}



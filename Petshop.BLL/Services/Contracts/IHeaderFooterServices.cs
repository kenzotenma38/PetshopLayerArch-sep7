using Petshop.BLL.ViewModels;

namespace Petshop.BLL.Services.Contracts;

public interface IHeaderService
{
    Task<HeaderViewModel?> GetHeaderViewModelAsync();
}

public interface IFooterService
{
    Task<FooterViewModel?> GetFooterViewModelAsync();
}



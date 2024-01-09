using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Components;

public class CategoriesListViewComponent:ViewComponent
{
    private IStoreRepository _storeRepository;
    public CategoriesListViewComponent(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;   
    }
    public IViewComponentResult Invoke()
    {
        return View(_storeRepository.Categories.Select(c => new CategoryViewModel{
            Id = c.Id,
            Name = c.Name,
            Url =  c.Url
        }).ToList());
    }
}
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Implementation;
using Models.ViewModel;

namespace OnlineFastFoodDelivery.ViewComponents
{
    public class FoodViewComponent:ViewComponent
    {
        HomePageDAO DAL = new HomePageDao();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomePageViewModel _viewModel = new HomePageViewModel();
            _viewModel.Food = await DAL.GetAllFoods();
            return View(_viewModel);
        }
        //public async Task<IViewComponentResult> InvokeAsync(List<int>? listCat, List<int>? listSubCat, List<int>? listFoodType)
        //{
        //    HomePageViewModel _viewModel= new HomePageViewModel();
        //    if (listCat == null && listSubCat == null && listFoodType == null)
        //    {
        //        _viewModel.Food = await DAL.GetAllFoods();
        //    }
        //    else
        //    {
        //        _viewModel.Food = await DAL.GetAllFoods_Filter(listCat, listSubCat, listFoodType);
        //    }
           
        //    return View(_viewModel);
        //}
    }
}

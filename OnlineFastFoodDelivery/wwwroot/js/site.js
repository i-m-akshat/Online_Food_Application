// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let apiURL = "https://forkify-api.herokuapp.com/api/v2/recipes";
let apiKey = "2dccf2bc-00e9-4dc8-a8c6-f43a43bb0bcd";
async function GetRecipe(recipeName,id,isAllShow    ) {
    let resp = await fetch(`${apiURL}?search=${recipeName}&key=${apiKey}`);
    let result = await resp.json();
    console.log(result);
    let Recipes = isAllShow ? result.data.recipes : result.data.recipes.slice(0, 6);
    showRecipes(Recipes, id);
}
function showRecipes(recipes, id) {
    $.ajax({
        contentType: "application/json;charset=utf-8",
        datatype: 'html',
        type: 'Post',
        url: '/Recipe/GetRecipeCard',
        data: JSON.stringify(recipes),
        success: function (htmlResult) {
            $('#' + id).html(htmlResult);
        }
      })
}
//var carouselWidth = $('.carousel-inner').scrollWidth;
//var cardWidth = $('.carousel-item').width();
//var scrollPosition = 0;
//$('.carousel-control-next').on('click', function () {
//    console.log('next');
//    scrollPosition = scrollPosition + cardWidth;
//    $('.carousel-inner').animate({ scrollleft: scrollPosition },600)
//})
//scrollPosition = scrollPosition + cardWidth

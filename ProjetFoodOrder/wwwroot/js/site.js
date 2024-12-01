// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let apiUrl = "https://forkify-api.herokuapp.com/api/v2/recipes";
let apiKey = "692033ed-0988-45fa-bbf1-12d93bb184ff";
async function GetRecipes(recipName,id,isAllShow) {

    let resp = await fetch(`${apiUrl}?search=${recipName}&Key=${apiKey}`);
    let result = await resp.json();
    console.log(result);
    let Recipes = isAllShow ? result.data.recipes : result.data.recipes.slice(1, 7);
    showRecipes(Recipes,id)
}

function showRecipes(recipes, id) {
    $.ajax({
        contentType: "application/json;charset=utf-8",
        dataType: 'html',
        type: 'POST',
        url: '/Recipe/GetRecipeCard',
        data: JSON.stringify(recipes),
        success: function (htmlResult) {
            $('#' + id).html(htmlResult);
        }
    });
}
async function getOrderRecipe(id, showId) {
   
    let resp = await fetch(`${apiUrl}/${id}?key=${apiKey}`);
    let result = await resp.json();
    console.log(result);
    let recipe = result.data.recipe;
    showOrderRecipeDetails(recipe, showId);

}
function showOrderRecipeDetails(orderRecipeDetails, showId) {
    
    $.ajax({
      
        dataType: 'html',
        type: 'POST',
        url: '/Recipe/ShowOrder',
        data: orderRecipeDetails ,
        success: function (htmlResult) {
            $('#' + showId).html(htmlResult);
        }
    });
}
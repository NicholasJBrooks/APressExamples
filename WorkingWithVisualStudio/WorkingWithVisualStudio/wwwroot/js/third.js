document.addEventListener("DOMContentLoaded", function ()
{
    var element = document.createElement("p");
    element.textContent = "This isthe element from the (Modified) third.js file";
    document.querySelector("body").appendChild(element);
});

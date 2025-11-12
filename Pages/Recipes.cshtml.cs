using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DreamRecipeSite.Pages
{
    // This PageModel handles displaying the recipe form
    // and processing form submissions using model binding.
    public class RecipesModel : PageModel
    {
        // Property that stores the recipe submitted from the form
        // BindProperty allows Razor Pages to automatically map form fields
        [BindProperty]
        public Recipe Recipe { get; set; }

        // Runs on GET request - loads the empty form
        public void OnGet()
        {
        }

        // Runs when the user submits the form (POST request)
        // Validates input and shows a message if successful
        public IActionResult OnPost()
        {
            // Check if form values pass Data Annotation validation rules
            if (!ModelState.IsValid)
            {
                return Page(); // redisplays the form with validation messages
            }

            // Normally you could save to a database here
            // For this challenge, a success message is enough
            TempData["Message"] = $"Recipe '{Recipe.Name}' added successfully!";

            // Redirect to clear the form and show the message
            return RedirectToPage();
        }
    }

    // This class represents the Recipe model used by the form
    // It includes Data Annotations for validation
    public class Recipe
    {
        public int Id { get; set; } // Not required but included for structure

        [Required(ErrorMessage = "Please enter a recipe name.")]
        public string? Name { get; set; }
         
        [Display(Name = "Main Ingredient")]
        [Required(ErrorMessage = "Please enter the main ingredient.")]
        public string? MainIngredient { get; set; }

        [Required(ErrorMessage = "Please enter instructions.")]
        [StringLength(1000, ErrorMessage = "Instructions must be under 1000 characters.")]
        public string? Instructions { get; set; }

        [Range(1, 10, ErrorMessage = "Servings must be between 1 and 10.")]
        public int? Servings { get; set; }
       
        [Display(Name = "Cook Time Minutes")]
        [Range(1, 300, ErrorMessage = "Cook time must be between 1 and 300 minutes.")]
        public int? CookTimeMinutes { get; set; }
    }
}

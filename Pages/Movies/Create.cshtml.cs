using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment_3.Data;
using Assignment_3.Models;
using Assignment_3.Utilities;

namespace Assignment_3.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Assignment_3.Data.Assignment_3Context _context;

        private readonly IWebHostEnvironment _env;



        public CreateModel(Assignment_3.Data.Assignment_3Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //process Image
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                Movie.Image = PictureHelper.UploadNewImage(_env,
                    HttpContext.Request.Form.Files[0]);
            }

          
            

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

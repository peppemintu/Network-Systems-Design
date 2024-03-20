using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace SpaceTourismWebApp.Pages
{
    public class BookingModel : PageModel
    {
        private readonly IConfiguration Configuration;

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public DateTime Date { get; set; }

        public BookingModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            BookTicket(Name, Email, Date);
            TempData["SuccessMessage"] = "Ticket booked successfully!";
            return Page();
        }

        private void BookTicket(string name, string email, DateTime date)
        {
            string connectionString = Configuration.GetConnectionString("DbConnection");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO public.\"Tickets\" (\"CustomerName\", \"Email\", \"BookingDate\") VALUES (@Name, @Email, @Date)";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Date", date);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

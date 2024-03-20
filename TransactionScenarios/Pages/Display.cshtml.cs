using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace SpaceTourismWebApp.Pages
{
	public class DisplayModel : PageModel
    {
        private readonly IConfiguration Configuration;

        public DataTable Tickets { get; private set; }

        public DisplayModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void OnGet()
        {
            Tickets = GetAllBookedTickets();
        }

        private DataTable GetAllBookedTickets()
        {
            DataTable data = new DataTable();

            string connectionString = Configuration.GetConnectionString("DbConnection");

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM public.\"Tickets\"";

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                {
                    adapter.Fill(data);
                }

                return data;
            }
        }
    }
}

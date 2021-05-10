using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient; 
using Microsoft.Extensions.Configuration; 
using System.Data;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FBwynik FBwynik { get; set; }

        public string Result = "";

        public IConfiguration _configuration { get; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (FBwynik.Number % 3 == 0)
                    Result += "Fizz";
                if (FBwynik.Number % 5 == 0)
                    Result += "Buzz";
                if ((FBwynik.Number % 5 != 0) && (FBwynik.Number % 3 != 0))
                    Result += "Liczba " + FBwynik.Number + " nie spełnia kryteriów Fizz/Buzz";
                HttpContext.Session.SetString("SesjaWyniki", JsonConvert.SerializeObject(FBwynik));
                HttpContext.Session.SetString("Result", Result);

                string FBDB_connection_string = _configuration.GetConnectionString("FBDB");
                SqlConnection con = new SqlConnection(FBDB_connection_string);
                SqlCommand cmd = new SqlCommand("FBAdd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter number_SqlParam = new SqlParameter("@Number", SqlDbType.Int);
                number_SqlParam.Value = FBwynik.Number;
                cmd.Parameters.Add(number_SqlParam);

                SqlParameter wynik_SqlParam = new SqlParameter("@Wynik", SqlDbType.VarChar, 50);
                wynik_SqlParam.Value = Result;
                cmd.Parameters.Add(wynik_SqlParam);

                SqlParameter data_SqlParam = new SqlParameter("@Data", SqlDbType.DateTime);
                data_SqlParam.Value = FBwynik.thisDay;
                cmd.Parameters.Add(data_SqlParam);

                SqlParameter Id_SqlParam = new SqlParameter("@Id", SqlDbType.Int); 
                Id_SqlParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Id_SqlParam);
                con.Open();
                int numAff = cmd.ExecuteNonQuery();
                con.Close();

                return Page();
            }
            return Page();
        }
    }
}
using System;
using Newtonsoft.Json;

namespace Vinyl.Web.Models
{
    public class WorkerModel
    {
        [JsonProperty("id")]
        public Int64 Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("month_salary")]
        public decimal MonthSalary { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}

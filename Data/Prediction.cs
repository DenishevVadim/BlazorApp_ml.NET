using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorAppML.Data
{
    public class Prediction
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public float Probability { get; set; }
        public string Class { get; set; }
        public string UserPrediction { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
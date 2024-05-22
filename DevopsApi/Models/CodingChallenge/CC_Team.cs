using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CCapi.Models.CodingChallenge
{
    public class CC_Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(40)]
        public string DisplayName { get; set; }

        [StringLength(100)]
        public string? Avatar { get; set; }

        public int Rank { get; set; }

        public bool StillInGame { get; set; } = true;
    }
}

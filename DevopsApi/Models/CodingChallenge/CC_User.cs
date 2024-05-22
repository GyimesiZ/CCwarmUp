using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CCapi.Models.CodingChallenge
{
    public class CC_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(40)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        [StringLength(100)]
        public string? Avatar { get; set; }

        public int Score { get; set; }

        public int Stake { get; set; }

        public bool Admin { get; set; } = false;
        public bool InGame { get; set; } = true;

        public virtual ICollection<CC_Bet>? Bets { get; set; }
        public virtual ICollection<CC_Message>? Messages { get; set; }
    }
}

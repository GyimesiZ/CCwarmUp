
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCapi.Models.CodingChallenge
{
    public enum BetState { Active, Cancelled, Expired }
    public class CC_Bet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public BetState State { get; set; } = BetState.Active;

        public bool Risk { get; set; }
        public int Winner { get; set; }
        public bool Shootout { get; set; }
        public int HomeGoals { get; set; } = 0;
        public int AwayGoals { get; set; } = 0;
        public int Score { get; set; } = 0;

        [ForeignKey("MatchId")]
        public virtual CC_Match Match { get; set; }
        public int MatchId { get; set; }

        [ForeignKey("BetMakerId")]
        public virtual CC_User BetMaker { get; set; }
        public int BetMakerId { get; set; }
    }
}

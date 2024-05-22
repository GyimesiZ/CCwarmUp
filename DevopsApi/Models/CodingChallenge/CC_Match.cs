using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCapi.Models.CodingChallenge
{
    public enum MatchState { Planned, InProgress, Completed, Cancelled}
    public class CC_Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public MatchState State { get; set; }
        public bool Playoff { get; set; }
        public int Winner { get; set; }
        public bool Shootout { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        public virtual ICollection<CC_Bet>? Bets { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }
    }

}

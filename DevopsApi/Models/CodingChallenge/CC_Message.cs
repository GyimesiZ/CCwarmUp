using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCapi.Models.CodingChallenge
{
    public class CC_Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Unreaded { get; set; } = true;

        [ForeignKey("RecipientId")]
        public virtual CC_User Recipient { get; set; }
        public int RecipientId { get; set; }
    }
}

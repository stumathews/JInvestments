using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinInvestmentTracker.Models.DEL.Interfaces
{
    /// <summary>
    /// All our entity classes will have an ID that is auto generated.
    /// </summary>
    public interface IDbInvestmentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        int ID { get; set; }
    }
}
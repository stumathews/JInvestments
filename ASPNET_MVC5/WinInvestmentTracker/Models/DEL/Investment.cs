using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models
{
    /// <summary>
    /// Represents an investment
    /// </summary>
    public class Investment : IDbInvestmentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public String Description { get; set; }
        public String Symbol { get; set; }

        [Display(Name = "Value Proposition")]
        public String ValueProposition { get; set; }

        [Display(Name ="Deseriabliity statement")]
        public String DesirabilityStatement { get; set; }

        [Display(Name = "Initial Investment")]
        [DataType(DataType.Currency)]
        public float InitialInvestment { get; set; }

        [Required]      
        [Display(Name ="Investment Name")]
        public String Name { get; set; }

        [DataType(DataType.Currency)]
        public float Value { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<InvestmentRisk> Risks { get; set; }
        public virtual ICollection<InvestmentGroup> Groups { get; set; }
        public virtual ICollection<InvestmentInfluenceFactor> Factors { get; set; }
        /*
     @GraphId
protected Long id;

@RelatedTo(type = "REGIONS", direction = Direction.OUTGOING)
@Fetch private Set<AssetRegion> regions = new HashSet<>();  

@RelatedTo(type = "RISKS", direction = Direction.OUTGOING)
@Fetch private Set<Risk> risks = new HashSet<>();

@RelatedTo(type = "GROUPS", direction = Direction.OUTGOING)
@Fetch private Set<InvestmentGroup> groups = new HashSet<>();    

@RelatedTo(type = "FACTORS", direction = Direction.OUTGOING)
@Fetch private Set<InfluenceFactor> influenceFactors = new HashSet<>();
     */

    }
}
package investments.db.del;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Objects;
import java.util.Set;
import org.neo4j.graphdb.Direction;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;
import org.springframework.data.neo4j.annotation.RelatedTo;

/***
 * Represents a single investment
 * @author Stuart
 */

@NodeEntity
public class Investment implements Serializable
{    
    @GraphId
    protected Long id;
    
    @RelatedTo(type = "IS_IN_REGIONS", direction = Direction.OUTGOING)
    @Fetch private Set<AssetRegion> regions = new HashSet<>();  
    
    @Fetch private Set<Risk> risks = new HashSet<>();
    
    @Fetch private Set<InvestmentGroup> groups = new HashSet<>();
    private String description;
    private String symbol;
    public String valueProposition;
    public String desirabilityStatement;
    public float initialInvestment;
    public String name;
    @RelatedTo(type = "FACTORS", direction = Direction.OUTGOING)
    @Fetch protected Set<InfluenceFactor> influenceFactors = new HashSet<InfluenceFactor>(0);
    public float value;

    @Override
    public int hashCode()
    {   
        int hash = 7;
        hash = 53 * hash + Objects.hashCode(this.id);
        hash = 53 * hash + Objects.hashCode(this.name);
        hash = 53 * hash + Objects.hashCode(this.regions);
        hash = 53 * hash + Objects.hashCode(this.risks);
        hash = 53 * hash + Objects.hashCode(this.groups);
        hash = 53 * hash + Objects.hashCode(this.description);
        hash = 53 * hash + Objects.hashCode(this.symbol);
        return hash;
    }

    @Override
    public boolean equals(Object obj)
    {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Investment other = (Investment) obj;
        if (!Objects.equals(this.id, other.id)) {
            return false;
        }
         if (!Objects.equals(this.name, other.name)) {
            return false;
        }
        if (!Objects.equals(this.regions, other.regions)) {
            return false;
        }
        if (!Objects.equals(this.risks, other.risks)) {
            return false;
        }
        if (!Objects.equals(this.groups, other.groups)) {
            return false;
        }
        if (!Objects.equals(this.description, other.description)) {
            return false;
        }
        return Objects.equals(this.symbol, other.symbol);
    }
   
    public Investment() 
    {
        
    } 

     public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }
    
    
    public Set<InvestmentGroup> getGroups()
    {
        return groups;
    }

    public void setGroups(Set<InvestmentGroup> groups)
    {
        this.groups = groups;
    }
       
    public Long getId()
    {
        return id;
    }

    public void setId(Long id)
    {
        this.id = id;
    }

    /**
     * Regions that this investment is in
     * @return 
     */
    public Set getRegions()
    {
        return regions;
    }

    public void setRegions(Set<AssetRegion> regions)
    {
        this.regions = regions;
    }

    /**
     * Get symbol that represents this investment (on the stock market)
     * @return 
     */
    public String getSymbol()
    {
        return symbol;
    }

    public void setSymbol(String symbol)
    {
        this.symbol = symbol;
    }

    /**
     * The risks that this company has (either specific or systemic)
     * @return
     */
    public Set getRisks()
    {
        return risks;
    }

    public void addRisk(Risk risk)
    {
        risks.add(risk);        
    }
    public void setRisks(Set<Risk> risks)
    {
        this.risks = risks;
    }

    public void addGroup(InvestmentGroup group)
    {
        groups.add(group);
    }

    public void addRegion(AssetRegion region)
    {
        regions.add(region);
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    /**
     * What makes this desirable?
     * @return
     */
    public String getDesirabilityStatement()
    {
        return desirabilityStatement;
    }

    /**
     * Why is this valuable?
     * @return
     */
    public String getValueProposition()
    {
        return valueProposition;
    }

    public void setDesirabilityStatement(String desirabilityStatement)
    {
        this.desirabilityStatement = desirabilityStatement;
    }

    public void setValueProposition(String valueProposition)
    {
        this.valueProposition = valueProposition;
    }

    /**
     * The initial amount
     * @return
     */
    public float getInitialInvestment()
    {
        return initialInvestment;
    }

    public void setInitialInvestment(float initialInvestment)
    {
        this.initialInvestment = initialInvestment;
    }

    public void addFactor(InfluenceFactor factor)
    {
        influenceFactors.add(factor);
    }

    public void disassociateFactor(InfluenceFactor factor)
    {
        influenceFactors.remove(factor);
    }

    /**
     * Influences that impact this investment
     * @return
     */
    public Set<InfluenceFactor> getInfluenceFactors()
    {
        return influenceFactors;
    }

    public void setInfluenceFactors(Set<InfluenceFactor> influenceFactors)
    {
        this.influenceFactors = influenceFactors;
    }

    /**
     * Current value
     * @return
     */
    public float getValue()
    {
        return value;
    }

    public void setValue(float value)
    {
        this.value = value;
    }
}
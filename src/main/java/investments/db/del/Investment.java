package investments.db.del;


import java.util.HashSet;
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
public class Investment
{    
    @GraphId
    protected Long id;
    
    @RelatedTo(type = "IS_IN_REGIONS", direction = Direction.OUTGOING)
    @Fetch
    private Set<AssetRegion> regions;  
    
    @RelatedTo(type = "FACTORS", direction = Direction.OUTGOING)
    @Fetch
    private Set<Factor> factors = new HashSet<>();

    public String name;
    public String whyReasonStatement;
    public float initialInvestment;
    
    public void addFactor(Factor factor)
    {
        factors.add(factor);
    }
    
    public Set<Factor> getFactors()
    {
        return factors;
    }

    public void setFactors(Set<Factor> factors)
    {
        this.factors = factors;
    }

    public float getInitialInvestment() {
        return initialInvestment;
    }

    public void setInitialInvestment(float initialInvestment) {
        this.initialInvestment = initialInvestment;
    }


    
    public Investment() {
    
    } 
    

    public String getWhyReasonStatement()
    {
        return whyReasonStatement;
    }

    public void setWhyReasonStatement(String whyReasonStatement)
    {
        this.whyReasonStatement = whyReasonStatement;
    }
    
      

    public String getName()
    {
        return name;
    }   

    public void setName(String name)
    {
        this.name = name;
    }
    
    public Long getId()
    {
        return id;
    }

    public void setId(Long id)
    {
        this.id = id;
    }

    public Set getRegions()
    {
        return regions;
    }

    public void setRegions(Set<AssetRegion> regions)
    {
        this.regions = regions;
    }

}
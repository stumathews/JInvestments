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
public class Investment extends ValueProvider
{    
    @GraphId
    protected Long id;
    
    @RelatedTo(type = "IS_IN_REGIONS", direction = Direction.OUTGOING)
    @Fetch
    private Set<AssetRegion> regions = new HashSet<>();  
    
    @Fetch
    protected Set<Risk> risks = new HashSet<>();
    
    @Fetch
    protected Set<InvestmentGroup> groups = new HashSet<>();
    protected String description;
    private String symbol;

   
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
}
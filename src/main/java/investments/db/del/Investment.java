package investments.db.del;

import investments.InvestmentBase;
import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;


import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;



/***
 * Represents a single investment
 * @author Stuart
 */
@NodeEntity
public class Investment extends InvestmentBase
{    
    @GraphId
    protected Long id;
    
    @Fetch
    private Set<AssetRegion> regions;
   
    
    public Investment() {} 
    
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
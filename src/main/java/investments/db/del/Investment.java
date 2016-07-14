package investments.db.del;

import investments.db.del.AssetRegion;
import investments.InvestmentBase;
import java.util.LinkedHashSet;
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
public class Investment extends InvestmentBase
{    
    @GraphId
    protected Long id;
    
    @RelatedTo(type = "HAS_REGIONS", direction = Direction.BOTH)
    @Fetch
    public Set<AssetRegion> regions = new LinkedHashSet<AssetRegion>();
    
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
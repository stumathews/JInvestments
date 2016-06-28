package investments.BOLO;

import investments.DEL.AssetRegion;
import investments.InvestmentBase;
import java.util.LinkedHashSet;
import java.util.Set;
import org.neo4j.graphdb.Direction;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.RelatedTo;

public class InvestmentForm extends InvestmentBase
{    
    private Long regionId;    

    public Long getRegionId()
    {
        return regionId;
    }

    public void setRegionId(Long regionId)
    {
        this.regionId = regionId;
    }
}

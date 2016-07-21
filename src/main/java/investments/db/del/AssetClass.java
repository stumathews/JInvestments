package investments.db.del;

import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;

@NodeEntity
public class AssetClass
{
    public AssetClass(){}
    
    @GraphId
    Long id;
    String name;
}

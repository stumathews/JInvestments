package investments;

import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;

/***
 * Represents a single investment
 * @author Stuart
 */
@NodeEntity
public class Investment 
{
    @GraphId
    private Long id;
    private String name;    
    
    public Investment() {}

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

}
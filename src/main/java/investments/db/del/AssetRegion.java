package investments.db.del;

import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;

@NodeEntity
public class AssetRegion
{
    @GraphId
    Long id;
   
    @Fetch
    private Set<Investment> investments;


    public Set<Investment> getInvestments()
    {
        return investments;
    }

    public void setInvestments(Set<Investment> investments)
    {
        this.investments = investments;
    }
    
    public Long getId()
    {
        return id;
    }

    public void setId(Long id)
    {
        this.id = id;
    }

    public String getName()
    {
        return Name;
    }

    public void setName(String Name)
    {
        this.Name = Name;
    }
    String Name;
    
    public AssetRegion(){}
    public AssetRegion(Long id)
    {
        this.id = id;
    }
    public AssetRegion(Long id, String name )
    {
        this(id);
        this.Name = name;
    }
    public AssetRegion(String name)
    {
        this.Name = name;
    }
    
}

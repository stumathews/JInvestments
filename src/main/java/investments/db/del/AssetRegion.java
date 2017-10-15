package investments.db.del;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Objects;
import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;

@NodeEntity
public class AssetRegion implements Serializable
{   
    @GraphId
    Long id;
    String name;
    @Fetch
    private Set<Investment> investments = new HashSet<>();

    public String getDescription() {
        return description;
    }

    private String description;

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
        return name;
    }

    public void setName(String Name)
    {
        this.name = Name;
    }
        
    public AssetRegion()
    {
    
    }
    
    public AssetRegion(Long id)
    {
        this.id = id;
    }
    
    public AssetRegion(Long id, String name )
    {
        this(id);
        this.name = name;
    }
    
    public AssetRegion(String name)
    {
        this.name = name;
    }

    public void addInvestment(Investment localInvestment)
    {
        investments.add(localInvestment);
    }  
     @Override
    public int hashCode()
    {
        int hash = 7;
        hash = 89 * hash + Objects.hashCode(this.id);
        hash = 89 * hash + Objects.hashCode(this.name);
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
        final AssetRegion other = (AssetRegion) obj;
        if (!Objects.equals(this.id, other.id)) {
            return false;
        }
        return Objects.equals(this.name, other.name);
    }

    public void setDescription(String description) {
        this.description = description;
    }
}

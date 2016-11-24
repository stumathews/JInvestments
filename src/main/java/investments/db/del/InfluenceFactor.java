/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Objects;
import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;

/**
 * A factor influences an investment. 
 * @author Stuart
 */
@NodeEntity
public class InfluenceFactor implements Serializable
{   
    @GraphId
    protected Long id;    
    @Fetch
    private Set<Investment> investments;    
    private String name;
    private String description;
    private String influence;
    
    public InfluenceFactor()
    {
        investments = new HashSet<>();
    }
    
    public InfluenceFactor(String name, String desc)
    {
        super();
        investments = new HashSet<>();
        this.name = name;
        this.description = desc;
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
     * The investments that are influenced by this factor
     * @return 
     */
    public Set<Investment> getInvestments()
    {
        return investments;
    }

    public void setInvestments(Set<Investment> investments)
    {
        this.investments = investments;
    }
    
    public void addInvestment(Investment investment)
    {
        investments.add(investment);
    }

    /**
     * Name of this influence
     * @return 
     */
    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    /**
     * Description of this influence
     * @return 
     */
    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }    

    @Override
    public int hashCode()
    {
        int hash = 3;
        hash = 37 * hash + Objects.hashCode(this.id);
        hash = 37 * hash + Objects.hashCode(this.name);
        hash = 37 * hash + Objects.hashCode(this.description);
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
        final InfluenceFactor other = (InfluenceFactor) obj;
        if (!Objects.equals(this.id, other.id)) {
            return false;
        }
        if (!Objects.equals(this.name, other.name)) {
            return false;
        }
        if (!Objects.equals(this.description, other.description)) {
            return false;
        }
        return true;
    }

    /**
     * How this influences
     * @return 
     */
    public String getInfluence()
    {
        return influence;
    }

    public void setInfluence(String influence)
    {
        this.influence = influence;
    }
}

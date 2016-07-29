/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;

/**
 * A factor influences an investment
 * @author Stuart
 */
@NodeEntity
public class Factor
{
    @GraphId
    protected Long id;    
    @Fetch
    private Set<Investment> investments;    
    public String name;
    public String description;
    
    public Factor(){}
    
    public Factor(String name, String desc){
        super();
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

    public Set<Investment> getInvestments()
    {
        return investments;
    }

    public void setInvestments(Set<Investment> investments)
    {
        this.investments = investments;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;

/**
 * Describes a basic group that contains investments
 * @author Stuart
 */
@NodeEntity
public class InvestmentGroup implements Serializable
{
    @GraphId
    private Long id;
    private String name;
    private String description;
    @Fetch
    private Set<Investment> investments = new HashSet<>();

    public Set<Investment> getInvestments()
    {
        return investments;
    }

    public void setInvestments(Set<Investment> investments)
    {
        this.investments = investments;
    }

    public InvestmentGroup()
    {
        
    }
    public InvestmentGroup(String name, String description)
    {
        this.name = name;
        this.description = description;
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

    public void addInvestment(Investment investment)
    {
        investments.add(investment);
    }
}

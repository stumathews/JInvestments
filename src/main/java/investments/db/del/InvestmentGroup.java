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
    /***
     * A way to distinguish one group from another
     */
    private String type;

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }
    private InvestmentGroup parent;
    private Set<InvestmentGroup> children = new HashSet<>();

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
    
    public InvestmentGroup getParent() {
        return parent;
    }

    public void setParent(InvestmentGroup parent) {
        this.parent = parent;
    }
    
    public Set<InvestmentGroup> getChildren() {
        return children;
    }

    public void setChildren(Set<InvestmentGroup> children) {
        this.children = children;
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

    @Override
    public int hashCode()
    {
        int hash = 3;
        hash = 53 * hash + Objects.hashCode(this.id);
        hash = 53 * hash + Objects.hashCode(this.name);
        hash = 53 * hash + Objects.hashCode(this.description);
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
        final InvestmentGroup other = (InvestmentGroup) obj;
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
    
    
}

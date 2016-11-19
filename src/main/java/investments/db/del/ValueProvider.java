/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

import java.util.HashSet;
import java.util.List;
import java.util.Set;
import org.neo4j.graphdb.Direction;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.RelatedTo;

/**
 * Something that has a potential or inherrent value to consumers
 * @author Stuart
 */
class ValueProvider
{
    /**
     * What value does this product provide to consumers. what is its use
     */
    protected String valueProposition;
    protected String desirabilityStatement;
    protected float initialInvestment;
    protected float value;    
    protected String name;
    @RelatedTo(type = "FACTORS", direction = Direction.OUTGOING)
    @Fetch
    protected Set<InfluenceFactor> influenceFactors = new HashSet<>();

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }
    

    /**
     * What makes this desirable?
     * @return 
     */
    public String getDesirabilityStatement()
    {
        return desirabilityStatement;
    }

    /**
     * Why is this valuable?
     * @return 
     */
    public String getValueProposition()
    {
        return valueProposition;
    }

    public void setDesirabilityStatement(String desirabilityStatement)
    {
        this.desirabilityStatement = desirabilityStatement;
    }

    public void setValueProposition(String valueProposition)
    {
        this.valueProposition = valueProposition;
    }

    /**
     * The initial amount
     * @return
     */
    public float getInitialInvestment()
    {
        return initialInvestment;
    }

    public void setInitialInvestment(float initialInvestment)
    {
        this.initialInvestment = initialInvestment;
    }

    /**
     * Current value
     * @return 
     */
    public float getValue()
    {
        return value;
    }

    public void setValue(float value)
    {
        this.value = value;
    }   

    public void addFactor(InfluenceFactor factor)
    {
        influenceFactors.add(factor);
    }

    public void disassociateFactor(InfluenceFactor factor)
    {
        influenceFactors.remove(factor);
    }
    

    /**
     * Influences that impact this investment
     * @return 
     */
    public Set<InfluenceFactor> getInfluenceFactors()
    {
        return influenceFactors;
    }

    public void setInfluenceFactors(Set<InfluenceFactor> influenceFactors)
    {
        this.influenceFactors = influenceFactors;
    }
    


}

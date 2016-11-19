/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

import java.util.List;
import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;

/**
 * Models a product that a company offers/sells for profit
 * @author Stuart
 */
class Product extends ValueProvider
{
    private Investment producer;
    private List<Investment> consumers; // possibly allow us to see who is impacted by changes in this product
    private List<InfluenceFactor> influences;
    @Fetch
    protected Set<Risk> risks;
    
    /**
     * Who produces this - is the manufacturer
     * @return 
     */
    public Investment getProducer()
    {
        return producer;
    }

    public void setProducer(Investment producer)
    {
        this.producer = producer;
    }

    /**
     * Who uses this product
     * @return 
     */
    public List<Investment> getConsumers()
    {
        return consumers;
    }

    public void setConsumers(List<Investment> consumers)
    {
        this.consumers = consumers;
    }

    /**
     * The risks that this company has (either specific or systemic)
     * @return
     */
    public Set getRisks()
    {
        return risks;
    }

    public void setRisks(Set<Risk> risks)
    {
        this.risks = risks;
    }
   
}

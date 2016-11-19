/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

import java.util.Set;
import org.springframework.data.neo4j.annotation.Fetch;

/**
 * Model a service(procedure, longer term commitment) that is offered by a Company
 * @author Stuart
 */
class Service extends ValueProvider
{
    private String name;
    @Fetch
    protected Set<Risk> risks;

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

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.BOLO;

import investments.db.del.InvestmentGroup;
import java.io.Serializable;

/**
 *
 * @author Stuart
 */
public class NewChildGroupForm extends InvestmentGroup implements Serializable
{
    private Long parentId;

    public Long getParentId()
    {
        return parentId;
    }

    public void setParentId(Long parentId)
    {
        this.parentId = parentId;
        
    }
    
}

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
public class GroupAndInvestmentForm extends InvestmentGroup implements Serializable
{
    private Long investmentId;

    public Long getInvestmentId()
    {
        return investmentId;
    }

    public void setInvestmentId(Long investmentId)
    {
        this.investmentId = investmentId;
    }
}

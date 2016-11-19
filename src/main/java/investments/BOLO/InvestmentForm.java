package investments.BOLO;

import investments.db.del.Investment;

/**
 * POJO that represents a investment form.
 * @author Stuart
 */
public class InvestmentForm extends Investment
{    
    public Long regionId;        
    private String symbol;

    public Long getRegionId()
    {
        return regionId;
    }

    public void setRegionId(Long regionId)
    {
        this.regionId = regionId;
    }
   
 }

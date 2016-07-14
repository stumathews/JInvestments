package investments.BOLO;

import investments.InvestmentBase;

/**
 * POJO that represents a investment form.
 * @author Stuart
 */
public class InvestmentForm extends InvestmentBase
{    
    private Long regionId;    

    public Long getRegionId()
    {
        return regionId;
    }

    public void setRegionId(Long regionId)
    {
        this.regionId = regionId;
    }
}

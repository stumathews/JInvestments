package investments.BOLO;



/**
 * POJO that represents a investment form.
 * @author Stuart
 */
public class InvestmentForm
{    
    public Long regionId; 
    public String name;
    public String whyReasonStatement;   

    public String getWhyReasonStatement()
    {
        return whyReasonStatement;
    }

    public void setWhyReasonStatement(String whyReasonStatement)
    {
        this.whyReasonStatement = whyReasonStatement;
    }
    

    public Long getRegionId()
    {
        return regionId;
    }

    public void setRegionId(Long regionId)
    {
        this.regionId = regionId;
    }
    
    public String getName()
    {
        return name;
    }   

    public void setName(String name)
    {
        this.name = name;
    }
    
}

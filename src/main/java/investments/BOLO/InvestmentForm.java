package investments.BOLO;



/**
 * POJO that represents a investment form.
 * @author Stuart
 */
public class InvestmentForm
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
    
    protected String name;

    public String getName()
    {
        return name;
    }   

    public void setName(String name)
    {
        this.name = name;
    }
}

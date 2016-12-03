package investments.BOLO;

/**
 *
 * @author Stuart
 */
public class FactorForm
{
    private Long id;
    private Long investmentId;    
    private String name;
    private String description;

    public Long getInvestmentId()
    {
        return investmentId;
    }

    public void setInvestmentId(Long investmentId)
    {
        this.investmentId = investmentId;
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
    
}

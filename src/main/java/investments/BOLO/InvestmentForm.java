package investments.BOLO;

import investments.db.del.AssetRegion;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import investments.db.del.Risk;
import java.io.Serializable;
import java.util.List;
import org.springframework.util.AutoPopulatingList;

/**
 * POJO that represents a investment form.
 * @author Stuart
 */
public class InvestmentForm extends Investment implements Serializable
{    
    public Long regionId;        
    
    private List<InfluenceFactor> influenceFactorsList =  new AutoPopulatingList<>(InfluenceFactor.class);
    private List<Risk> risksList = new AutoPopulatingList<>(Risk.class);
    private List<AssetRegion> regionsList = new AutoPopulatingList<>(AssetRegion.class);
    private List<InvestmentGroup> groupsList = new AutoPopulatingList<>(InvestmentGroup.class);

    public List<AssetRegion> getRegionsList()
    {
        return regionsList;
    }

    public void setRegionsList(List<AssetRegion> regionsList)
    {
        this.regionsList = regionsList;
    }

    public List<InvestmentGroup> getGroupsList()
    {
        return groupsList;
    }

    public void setGroupsList(List<InvestmentGroup> groupsList)
    {
        this.groupsList = groupsList;
    }

    public List<Risk> getRisksList()
    {
        return risksList;
    }

    public void setRisksList(List<Risk> risksList)
    {
        this.risksList = risksList;
    }
    
    public List<InfluenceFactor> getInfluenceFactorsList()
    {
        return influenceFactorsList;
    }

    public void setInfluenceFactorsList(List<InfluenceFactor> influenceFactorsList)
    {
        this.influenceFactorsList = influenceFactorsList;
    }
    
    public InvestmentForm()
    {       
        
    }

    public Long getRegionId()
    {
        return regionId;
    }

    public void setRegionId(Long regionId)
    {
        this.regionId = regionId;
    }
   
 }

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
    /*
    * The following will be populated on-the-fly when the user selects factors, risks,regions and groups associated
    * with this investment
    * */
    private List<InfluenceFactor> selectedFactors =  new AutoPopulatingList<>(InfluenceFactor.class);
    private List<Risk> selectedRisks = new AutoPopulatingList<>(Risk.class);
    private List<AssetRegion> selectedRegions = new AutoPopulatingList<>(AssetRegion.class);
    private List<InvestmentGroup> selectedGroupIDs = new AutoPopulatingList<>(InvestmentGroup.class);

    public List<InfluenceFactor> getSelectedFactors() {
        return selectedFactors;
    }

    public void setSelectedFactors(List<InfluenceFactor> selectedFactors) {
        this.selectedFactors = selectedFactors;
    }

    public List<Risk> getSelectedRisks() {
        return selectedRisks;
    }

    public void setSelectedRisks(List<Risk> selectedRisks) {
        this.selectedRisks = selectedRisks;
    }

    public List<AssetRegion> getSelectedRegions() {
        return selectedRegions;
    }

    public void setSelectedRegions(List<AssetRegion> selectedRegions) {
        this.selectedRegions = selectedRegions;
    }

    public List<InvestmentGroup> getSelectedGroups() {
        return selectedGroupIDs;
    }

    public void setSelectedGroups(List<InvestmentGroup> selectedGroups) {
        this.selectedGroupIDs = selectedGroups;
    }

    public InvestmentForm()
    {

    }
 }

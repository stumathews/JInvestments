package investments.services;

import investments.BOLO.InvestmentForm;
import investments.db.DataAccess;
import investments.db.del.AssetRegion;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import investments.db.del.Risk;
import javax.servlet.http.HttpServletRequest;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.webflow.execution.RequestContext;
import java.util.ArrayList;
import java.util.List;

@Service
public class InvestmentService
{
    private final DataAccess dataAccess;
    public static Logger logger;
            
    @Autowired
    public InvestmentService(DataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
        logger = LoggerFactory.getLogger(this.getClass());
    }
    
    public void saveInvestmentFormFlow(InvestmentForm investmentForm)
    {        
        logger.info("Saving investment form from flow...");
        Investment investment = new Investment();

        investmentForm.getSelectedFactors().stream().filter((factor) -> ( factor != null)).forEach((factor) -> {
            InfluenceFactor fromDb = dataAccess.getFactorById(factor.getId());
            investment.addFactor(fromDb);
        }); 
        
        investmentForm.getSelectedRegions().stream().filter((region) -> (region != null)).forEach((region) -> {
            AssetRegion fromDb = dataAccess.getRegionById(region.getId());
            investment.addRegion(fromDb);
        });
        
        investmentForm.getSelectedGroups().stream().filter((group) -> (group != null)).forEach((group) -> {
            InvestmentGroup fromDb = dataAccess.getGroupById(group.getId());
            investment.addGroup(fromDb);
        });
        
        investmentForm.getSelectedRisks().stream().filter((risk) -> (risk != null)).forEach((risk) -> {
            Risk fromDb = dataAccess.getRiskById(risk.getId());
            investment.addRisk(fromDb);
        });

        investment.setDescription(investmentForm.getDescription());
        investment.setDesirabilityStatement(investmentForm.getDesirabilityStatement());
        investment.setInitialInvestment(investmentForm.getInitialInvestment());
        investment.setName(investmentForm.getName());
        investment.setSymbol(investmentForm.getSymbol());
        investment.setValue(investmentForm.getValue());
        investment.setValueProposition(investmentForm.getValueProposition());
        Investment savedInvestment = dataAccess.saveInvestment(investment);
        
        // update

        investmentForm.getSelectedFactors().stream().filter((factor) -> ( factor != null)).forEach((factor) -> {
            InfluenceFactor db = dataAccess.getFactorById(factor.getId());
            savedInvestment.addFactor(db);
            db.addInvestment(savedInvestment);
            dataAccess.addFactor(db);
        }); 
        
        investmentForm.getSelectedRegions().stream().filter((region) -> (region != null)).forEach((region) -> {
            AssetRegion db = dataAccess.getRegionById(region.getId());
            db.addInvestment(savedInvestment);
            savedInvestment.addRegion(db);
            dataAccess.saveRegion(db);
        });
        
        investmentForm.getSelectedGroups().stream().filter((group) -> (group != null)).forEach((group) -> {
            InvestmentGroup db = dataAccess.getGroupById(group.getId());
            db.addInvestment(savedInvestment);
            savedInvestment.addGroup(db);
            dataAccess.addGroup(db);
        });
        
        investmentForm.getSelectedRisks().stream().filter((risk) -> (risk != null)).forEach((risk) -> {
            Risk db = dataAccess.getRiskById(risk.getId());
            db.addInvestment(savedInvestment);
            savedInvestment.addRisk(db);
            dataAccess.addRisk(db);
        });
        
        dataAccess.updateInvestment(savedInvestment);

        logger.info("Saving investment form from flow...done");
    }

    public InvestmentGroup GetGroupById(long id)
    {
       return dataAccess.getGroupById(id);
    }

    public InvestmentForm FinalizeInvestmentForm(investments.BOLO.InvestmentForm investmentForm)
    {
        List<InfluenceFactor> realFactors = new ArrayList<>();
        List<Risk> realRisks = new ArrayList<>();
        List<InvestmentGroup> realGroups = new ArrayList<>();
        List<AssetRegion> realRegions = new ArrayList<>();
        // Cull out the missing data
        for( InfluenceFactor factor : investmentForm.getSelectedFactors())
        {
            Long id = factor.getId();
            if(id != null) {
                factor = dataAccess.getFactorById(id);
                realFactors.add(factor);
            }
        }
        for( Risk risk : investmentForm.getSelectedRisks())
        {
            Long id = risk.getId();
            if(id != null) {
                risk = dataAccess.getRiskById(id);
                realRisks.add(risk);
            }
        }
        for( AssetRegion region : investmentForm.getSelectedRegions())
        {
            Long id = region.getId();
            if(id != null) {
                region = dataAccess.getRegionById(id);
                realRegions.add(region);
            }
        }
        for( InvestmentGroup group : investmentForm.getSelectedGroups())
        {
            Long id = group.getId();
            if(id != null) {
                group = dataAccess.getGroupById(id);
                realGroups.add(group);
            }
        }
        investmentForm.setSelectedFactors(realFactors);
        investmentForm.setSelectedRisks(realRisks);
        investmentForm.setSelectedRegions(realRegions);
        investmentForm.setSelectedGroups(realGroups);

        return investmentForm;
    }
        
    public InvestmentForm GetInvestmentFormFromFlowRequestContext(RequestContext requestContext)
    {
        HttpServletRequest httpRequest = (HttpServletRequest) requestContext.getExternalContext().getNativeRequest();
        return new InvestmentForm();
    }
    

}

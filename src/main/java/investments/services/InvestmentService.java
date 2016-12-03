/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.services;

import investments.BOLO.InvestmentForm;
import investments.db.DataAccess;
import investments.db.del.AssetRegion;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import investments.db.del.Risk;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

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
    
    
    public void saveInvestmentFlow(InvestmentForm investmentForm)
    {        
        logger.info("Saving investment form from flow...");
        Investment investment = new Investment();
        
        investmentForm.getInfluenceFactorsList().stream().filter((factor) -> ( factor.getId() != null)).forEach((factor) -> {
            InfluenceFactor fromDb = dataAccess.getFactorById(factor.getId());            
            investment.addFactor(fromDb);
        }); 
        
        investmentForm.getRegionsList().stream().filter((region) -> (region.getId() != null)).forEach((region) -> {
            AssetRegion fromDb = dataAccess.getRegionById(region.getId());            
            investment.addRegion(fromDb);
        });
        
        investmentForm.getGroupsList().stream().filter((group) -> (group.getId() != null)).forEach((group) -> {
            InvestmentGroup fromDb = dataAccess.getGroupById(group.getId());            
            investment.addGroup(fromDb);
        });
        
        investmentForm.getRisksList().stream().filter((risk) -> (risk.getId() != null)).forEach((risk) -> {
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
        
        investmentForm.getInfluenceFactorsList().stream().filter((factor) -> ( factor.getId() != null)).forEach((factor) -> {
            InfluenceFactor db = dataAccess.getFactorById(factor.getId());
            savedInvestment.addFactor(factor);
            db.addInvestment(savedInvestment);
            dataAccess.addFactor(db);
        }); 
        
        investmentForm.getRegionsList().stream().filter((region) -> (region.getId() != null)).forEach((region) -> {
            AssetRegion db = dataAccess.getRegionById(region.getId());                        
            db.addInvestment(savedInvestment);
            savedInvestment.addRegion(db);
            dataAccess.saveRegion(db);
        });
        
        investmentForm.getGroupsList().stream().filter((group) -> (group.getId() != null)).forEach((group) -> {
            InvestmentGroup db = dataAccess.getGroupById(group.getId());            
            db.addInvestment(savedInvestment);
            savedInvestment.addGroup(db);
            dataAccess.addGroup(db);
        });
        
        investmentForm.getRisksList().stream().filter((risk) -> (risk.getId() != null)).forEach((risk) -> {
            Risk db = dataAccess.getRiskById(risk.getId());
            db.addInvestment(savedInvestment);
            savedInvestment.addRisk(db);
            dataAccess.addRisk(db);
        });
        
        dataAccess.updateInvestment(savedInvestment);
        
        logger.info("Saving investment form from flow...done");
    }
    

}

package investments.controllers;
import investments.BOLO.InvestmentForm;
import static investments.controllers.BaseController.logger;
import investments.db.del.AssetRegion;
import investments.db.DataAccess;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import investments.db.del.Risk;
import investments.db.del.RiskType;
import java.io.IOException;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Random;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.Part;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestPart;
import org.springframework.webflow.execution.RequestContext;


@Controller
@RequestMapping("/investments")
public class InvestmentController extends BaseController
{
    @Autowired
    DataAccess dataAccess;

    public InvestmentController()
    {}    
    
    @RequestMapping(value="/{id}/view")
    public String showInvestment(Map<String, Object> model, @PathVariable Long id)
    {
        logger.info("Viewing investment: " + id);
        Investment investment = dataAccess.getInvestmentById(id);
        model.put("investment", investment);        
        return "/viewInvestment";
    }

    @RequestMapping(value="/{id}/delete", method = RequestMethod.GET)
    public String deleteInvestment(@PathVariable Long id)
    {
        logger.info("Deleting investment: " + id);
        dataAccess.deleteInvestmentbyId(id);
        return "redirect:/";
    }
   
    
    @RequestMapping(value="/populateDummyData", method = RequestMethod.GET)
    public String populateDummyData(Map<String, Object> model)
    {
        List<Investment> investments = dataAccess.getAllInvestments();
        List<AssetRegion> regions = dataAccess.getAllRegions();
        List<Risk> risks = dataAccess.getAllRisks();
        List<InvestmentGroup> groups = dataAccess.getAllGroups();
        List<InfluenceFactor> factors = dataAccess.getAllFactors();   
        
        Random r = new Random();
             
        // create dummy investments
        if(investments.isEmpty()){
            logger.info("no investments found, creating new data...");
            int investmentCount=10;
            for(int i = 0; i < investmentCount ;i++){
                Investment localInvestment = new Investment();
                localInvestment.setDesirabilityStatement("Desirability statment");
                localInvestment.setInitialInvestment(r.nextFloat());
                localInvestment.setName("Investment Name"+i);
                localInvestment.setDescription("Description of investment");
                localInvestment.setSymbol("Symbol");
                localInvestment.setValue(r.nextFloat());
                localInvestment.setValueProposition("Value Proposition statment");                
                
                                
                // Create dummy risks
                if(risks.isEmpty())
                {
                    risks.add(new Risk("Director dismissal", "Financial officer fired due to corruption", RiskType.Company));
                    risks.add(new Risk("Competition", "Competition from other companies", RiskType.Market));        
                    risks.add(new Risk("Fashion", "Fashion of the comodity", RiskType.Market));        
                    risks.add(new Risk("Earnings report", "Investor perception based on earnings", RiskType.Company));   
                    
                    risks.add(new Risk("", "", RiskType.Company));   
                }               
                
                // Create dummy groups
                if( groups.isEmpty()){
                    groups.add(new InvestmentGroup("Value Investments","High current p/e with potential to maintain."));
                    groups.add(new InvestmentGroup("Growth Investments","Low p/e with potential to grow"));
                    groups.add(new InvestmentGroup("Momentum Investments","Fashionalble trends"));
                    groups.add(new InvestmentGroup("Hybrid Investments","Bit of everything"));                        
                    
                    groups.add(new InvestmentGroup("Tactical",""));        
                    groups.add(new InvestmentGroup("Strategic",""));        
                    groups.add(new InvestmentGroup("Shares",""));        
                    groups.add(new InvestmentGroup("Gold",""));        
                    groups.add(new InvestmentGroup("Emerging markets",""));        
                    
                }
                
                // Create dummy factors
                if(factors.isEmpty()){
                    InfluenceFactor factor1 = new InfluenceFactor("Weather","The climate will affect the investment.");
                    factor1.setInfluence("Sunny weather helps, rainy weather doesn't");
                    
                    InfluenceFactor factor2 = new InfluenceFactor("Competiion","The competition dictates te supply and demand");
                    factor2.setInfluence("The more cometition the less buiness you get if the competition or on par to you");
                       
                    String[] samples = new String[] { "Transport", 
                        "Travel/Tourism", 
                        "Utilities",
                        "Telecommunications",
                        "Professional Services/Consulting",
                        "Pharmaceutical/Medical Product",
                        "Oil/Gas",
                        "Mining/Metals",
                        "Manufacturing",
                        "IT (Hardware/Software/Services)",
                        "Investment Banking","Food and Beverage","Consumer Goods","Agriculture"};
                    
                    for( String each : samples)          
                    {
                        InfluenceFactor f = new InfluenceFactor(each,"");
                        f.setInfluence("influenced by " + each);                        
                        factors.add(f);
                    }                   
                }
                
                Investment savedInvestment = dataAccess.saveInvestment(localInvestment);
                investments.add(savedInvestment);
                logger.info("Created investment name="+ localInvestment.getName());
                
                int gmax = 0;
                while(gmax == 0){
                    gmax = r.nextInt(groups.size());
                }
                for(int g = 0; g < gmax;g++){
                    InvestmentGroup group = groups.get(g);
                    group.addInvestment(savedInvestment);
                    savedInvestment.addGroup(group);
                }
                
                int fmax = 0;
                while(fmax == 0){
                    fmax = r.nextInt(factors.size());
                }                
                for(int f = 0; f < fmax;f++){
                    InfluenceFactor factor = factors.get(f);
                    factor.addInvestment(savedInvestment);                
                    savedInvestment.addFactor(factor);
                }
                
                int rmax = 0;
                while(rmax == 0){
                    rmax = r.nextInt(risks.size());
                }
                for( int rsk = 0; rsk < rmax;rsk++){
                    Risk risk = risks.get(rsk);
                    risk.addInvestment(savedInvestment);                
                    savedInvestment.addRisk(risk);         
                } 
                
                int regionMax = 0;
                while(regionMax == 0){ regionMax = r.nextInt(regions.size());}
                for( int reg = 0; reg < regionMax;reg++){
                    AssetRegion region = regions.get(reg);
                    region.addInvestment(localInvestment);
                    savedInvestment.addRegion(region);
                     dataAccess.saveRegion(region);
                }   
            }
        }

        //update investments with add groups, factors, risks etc.
        investments.stream().forEach((investment) -> {
            dataAccess.updateInvestment(investment);
        });
        
        model.put("investments", investments);         
        return "investments";
    }
    
    @RequestMapping(value="/", method=RequestMethod.GET)
    public String home(Map<String, Object> model)
    {
        List<Investment> investments = dataAccess.getAllInvestments();
        
        
        model.put("investments", investments);         
        return "investments";
    }

    @RequestMapping(method = RequestMethod.POST)
    public String submit(InvestmentForm investmentForm)
    {  
        Investment del = new Investment();
        HashSet<AssetRegion> regions = new HashSet<>();
        AssetRegion region = dataAccess.getRegionById(investmentForm.getRegionId());
            
        regions.add(region);
        
        del.setName(investmentForm.getName());
        del.setRegions(regions);        
        del.setInitialInvestment(investmentForm.getInitialInvestment());
        del.setValueProposition(investmentForm.getValueProposition());        
        del.setDesirabilityStatement(investmentForm.getDesirabilityStatement());
        del.setSymbol(investmentForm.getSymbol());
        
        dataAccess.saveInvestment(del);    
        
        logger.info("Creating investment: " + investmentForm.getName());
        logger.info("Selected region was " + region.getName());
        return "redirect:/investments/";
    }   
    
    @RequestMapping(value = "/ShowAddInvestmentPage",method = RequestMethod.GET)
    public String addInvestmentPage(Map<String, Object> model)
    {        
        model.put("investment", new Investment());
        model.put("regions", dataAccess.getAllRegions());
        return "addinvestment";
    }
        
    @RequestMapping(value = "/EditInvestment/{id}",method = RequestMethod.GET)
    public String addInvestmentPage(@PathVariable Long id, HttpServletRequest request, Map<String, Object> model)
    {        
        
        Investment investment = dataAccess.getInvestmentById(id);
        InvestmentForm form = new InvestmentForm(investment);
                
        request.setAttribute("investment", form);
        
        return "forward:/NewInvestment";
    } 
  
}

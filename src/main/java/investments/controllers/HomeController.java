package investments.controllers;

import investments.db.AssetRegionRepository;
import investments.db.DataAccess;
import investments.db.FactorRepository;
import investments.db.InvestmentRepository;
import investments.db.del.AssetRegion;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import investments.db.del.Risk;
import java.util.List;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/")
public class HomeController extends BaseController {
    
    @Autowired
    DataAccess dataAccess;
    
    public HomeController() 
    {
        
    }

    @RequestMapping(method = RequestMethod.GET)
    public String home(Map<String, Object> model) 
    {     
        List<Investment> investments = dataAccess.getAllInvestments();
        List<AssetRegion> assetRegions = dataAccess.getAllRegions();
        List<InfluenceFactor> factors = dataAccess.getAllFactors();  
        List<InvestmentGroup> groups = dataAccess.getAllGroups();
        List<Risk> risks = dataAccess.getAllRisks();
        model.put("investments", investments);
        model.put("regions", assetRegions);
        model.put("factors", factors);
        model.put("groups", groups);
        model.put("risks", risks);
        
        model.put("title", "Investement Tracker");
        
        return "home";
    }

    @RequestMapping(method = RequestMethod.POST)
    public String submit(Investment investment) 
    {
       
        return "redirect:/";
    }

    
}

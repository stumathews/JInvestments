package investments.controllers;

import investments.db.AssetRegionRepository;
import investments.db.DataAccess;
import investments.db.FactorRepository;
import investments.db.InvestmentRepository;
import investments.db.del.AssetRegion;
import investments.db.del.Factor;
import investments.db.del.Investment;
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
        List<Factor> factors = dataAccess.getAllFactors();        
        model.put("investments", investments);
        model.put("regions", assetRegions);
        model.put("factors", factors);
        
        model.put("title", "Investement Tracker");
        
        return "home";
    }

    @RequestMapping(method = RequestMethod.POST)
    public String submit(Investment investment) 
    {
       
        return "redirect:/";
    }

    
}

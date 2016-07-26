package investments.controllers;
import investments.BOLO.InvestmentForm;
import investments.db.del.AssetRegion;
import investments.db.DataAccess;
import investments.db.del.Investment;
import java.util.HashSet;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/investments")
public class InvestmentController extends BaseController
{
    @Autowired
    DataAccess dataAccess;

    public InvestmentController(){}
    
  
    @RequestMapping(value="/{id}/view")
    public String showInvestment(@PathVariable Long id)
    {
        log.info("Viewing investment: " + id);
        
        return "/viewInvestment";
    }
    
    @RequestMapping(value="/{id}/delete", method = RequestMethod.GET)
    public String deleteInvestment(@PathVariable Long id)
    {
        log.info("Deleting investment: " + id);
        dataAccess.deleteInvestmentbyId(id);
        return "redirect:/";
    }
    
    @RequestMapping(value="/", method=RequestMethod.GET)
    public String home(Map<String, Object> model)
    {
        model.put("investments", dataAccess.getAllInvestments());         
        return "showAllInvestments";
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
        del.setWhyReasonStatement(investmentForm.getWhyReasonStatement());
        
        dataAccess.save(del);    
        
        log.info("Creating investment: " + investmentForm.getName());
        log.info("Selected region was " + region.getName());
        return "redirect:/investments/";
    }   
    
    @RequestMapping(value = "/ShowAddInvestmentPage",method = RequestMethod.GET)
    public String addInvestmentPage(Map<String, Object> model)
    {        
        model.put("investment", new Investment());
        model.put("regions", dataAccess.getAllRegions());
        return "addinvestment";
    }    
    
    @RequestMapping(value="/showEditInvestmentPage", method= RequestMethod.GET)
    public String editInvestment(Map<String, Object> model)
    {        
        return "editinvestment";
    }
}

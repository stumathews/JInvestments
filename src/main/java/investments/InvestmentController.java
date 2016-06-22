package investments;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/investments")
public class InvestmentController extends BaseController
{
    @Autowired
    DataAccess dataAccess;
    
    public InvestmentController(){}
    
    @RequestMapping(value="/", method=RequestMethod.GET)
    public String home(Map<String, Object> model)
    {
        model.put("investments", dataAccess.getAllInvestments());           
        return "showAllInvestments";
    }
    
    @RequestMapping(method = RequestMethod.POST)
    public String submit(Investment investment)
    {
        log.info("Creating investment: " + investment.getName());
        dataAccess.save(investment);    
        return "redirect:/investments/";
    }   
    
    @RequestMapping(value = "/ShowAddInvestmentPage",method = RequestMethod.GET)
    public String addInvestmentPage(Map<String, Object> model)
    {        
        model.put("investment", new Investment());
        return "addinvestment";
    }    
    
    @RequestMapping(value="/showEditInvestmentPage", method= RequestMethod.GET)
    public String editInvestment(Map<String, Object> model)
    {        
        return "editinvestment";
    }
}

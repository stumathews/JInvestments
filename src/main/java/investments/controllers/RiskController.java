package investments.controllers;

import investments.BOLO.RiskAndInvestmentForm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import investments.db.DataAccess;
import investments.db.del.Investment;
import investments.db.del.Risk;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import javax.servlet.http.HttpServletRequest;

@Controller
@RequestMapping("/risk")
public class RiskController extends BaseController
{
    @Autowired
    DataAccess dataAccess;
    
    @RequestMapping(method=RequestMethod.GET)
    public String getRisks(Map<String, Object> model)
    {        
        List<Risk> risks = dataAccess.getAllRisks();
        
        model.put("risks", risks);
        return "risks";
    }
    
    @RequestMapping(value="/saveRiskWithInvestment",method=RequestMethod.POST)
    public String newRisk(RiskAndInvestmentForm riskAndInvestment, Map<String, Object> model)
    {
        Investment investment = dataAccess.getInvestmentById(riskAndInvestment.getInvestmentId());
        Risk newRisk = new Risk();
        newRisk.setDescription(riskAndInvestment.getDescription());
        
        newRisk.setName(riskAndInvestment.getName());
        newRisk.setType(riskAndInvestment.getType());
        Set<Investment> linkedInvestments = new HashSet<>();
        linkedInvestments.add(investment);
        newRisk.setInvestments(linkedInvestments);
        Risk savedRisk = dataAccess.addRisk(newRisk);
        investment.addRisk(savedRisk);
        dataAccess.updateInvestment(investment);
        return "redirect:/investments/"+investment.getId()+"/view";
        
    }
        
    @RequestMapping(value="/newToInvestment", method=RequestMethod.GET)
    public String showAddRiskToInvestmentView(Map<String, Object> model, Long investmentId )
    {
        Investment investment = dataAccess.getInvestmentById(investmentId);
        model.put("investment", investment);
        model.put("riskForm", new RiskAndInvestmentForm());
        return "addRisk";
    }
            
    @RequestMapping(value="/{id}/delete", method = RequestMethod.GET)
    public String deleteRisk(@PathVariable int riskId, Map<String, Object> model)
    {
        return getRisks(model);
    }  
    
    @RequestMapping(value="/{id}", method = RequestMethod.GET)
    public String viewRisk(@PathVariable Long id, Map<String, Object> model)
    {
        Risk risk = dataAccess.getRiskById(id);
        model.put("risk", risk);
        return "viewRisk";
    }  
    
    @RequestMapping(value="/disassociate/{iid}/{rid}", method = RequestMethod.GET)
    public String disassociate(HttpServletRequest request, @PathVariable Long iid, @PathVariable Long rid)
    {        
        Investment investment = dataAccess.getInvestmentById(iid);
        Risk risk = dataAccess.getRiskById(rid);
        logger.info(String.format("Dissasociate risk %s from investment %s", risk.getName(), investment.getName()));
        investment.disassociateRisk(risk);
        dataAccess.updateInvestment(investment);
        
        String referer = request.getHeader("Referer");
        return "redirect:"+ referer;
        
    }

    @RequestMapping(value = "/update", method = RequestMethod.POST)
    public @ResponseBody
    String update(@RequestParam(value = "name") String name, @RequestParam(value = "value") String value, @RequestParam(value = "pk") String pk, HttpServletRequest request) {
        Risk r = dataAccess.getRiskById(Long.parseLong(pk));
        switch(name){
            case "name":
                r.setName(value);
                break;
            case "description":
                r.setDescription(value);
                break;
        }
        dataAccess.updateRisk(r);
        return "";
    }
}


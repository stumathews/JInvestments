/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import investments.BOLO.FactorForm;
import investments.db.DataAccess;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;
import java.util.List;
import java.util.Map;
import javax.servlet.http.HttpServletRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/factors")
public class FactorController extends BaseController
{    
    @Autowired
    DataAccess dataAccess;
    
    @RequestMapping(method=RequestMethod.GET)
    public String showFactors(Map<String, Object> model)
    {
        List<InfluenceFactor> factors = dataAccess.getAllFactors();
        
        model.put("factors", factors);
        return "factors";
    }
   
    @RequestMapping(method=RequestMethod.POST)
    public String addFactor(FactorForm factorForm, Map<String, Object> model)
    {        
        Investment investment = dataAccess.getInvestmentById(factorForm.getInvestmentId());
        InfluenceFactor factor = new InfluenceFactor(factorForm.getName(), factorForm.getDescription());
        factor.addInvestment(investment);        
        investment.addFactor(factor);
        
        dataAccess.updateInvestment(investment);
        return "redirect:/investments/"+investment.getId().toString()+"/view";
    }
    
    @RequestMapping(value="/disassociate/{iid}/{fid}", method = RequestMethod.GET)
    public String disassociate(HttpServletRequest request, @PathVariable Long iid, @PathVariable Long fid)
    {        
        Investment investment = dataAccess.getInvestmentById(iid);
        InfluenceFactor factor = dataAccess.getFactorById(fid);
        logger.info(String.format("Dissasociate factor %s from investment %s", factor.getName(), investment.getName()));
        investment.disassociateFactor(factor);
        dataAccess.updateInvestment(investment);
        
        String referer = request.getHeader("Referer");
        return "redirect:"+ referer;
        
    }
    
    @RequestMapping(value="/{id}/delete", method = RequestMethod.GET)
    public String deleteFactor(@PathVariable Long id)
    {
        logger.info("Deleting investment: " + id);
        dataAccess.deleteFactorBy(id);
        return "redirect:/";
    }
    
    @RequestMapping(value="/{id}", method = RequestMethod.GET)
    public String viewFactor(@PathVariable Long id, Map<String, Object> model)
    {        
        InfluenceFactor factor = dataAccess.getFactorById(id);
        model.put("factor", factor);
        return "viewfactor";
    }

    @RequestMapping(value="/newToInvestment", method=RequestMethod.GET)
    public String showAddFactorView(Map<String, Object> model, Long investmentId )
    {
        Investment investment = dataAccess.getInvestmentById(investmentId);
        model.put("factorForm", new FactorForm());
        model.put("investment", investment);
        return "addFactor";
    }  
    
}

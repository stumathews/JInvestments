/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import investments.db.DataAccess;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import investments.db.del.Risk;
import investments.db.del.RiskType;
import java.util.List;
import java.util.Map;
import javax.servlet.http.HttpServletRequest;
import org.springframework.web.bind.support.SessionStatus;

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
    
    @RequestMapping(value="/new", method=RequestMethod.GET)
    public String addRiskWithInvestment(HttpServletRequest request, Map<String, Object> model, Long investmentId )
    {
        return getRisks(model);
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
}


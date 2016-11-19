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
    
    @RequestMapping(method=RequestMethod.POST)
    public String newRisk(Risk risk, Map<String, Object> model)
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
}


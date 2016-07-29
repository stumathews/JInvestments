/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import investments.BOLO.FactorForm;
import investments.BOLO.InvestmentForm;
import investments.db.DataAccess;
import investments.db.del.Factor;
import investments.db.del.Investment;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/factors")
public class FactorController
{
    
    @Autowired
    DataAccess dataAccess;
    
    @RequestMapping(method=RequestMethod.POST)
    public String addFactor(FactorForm factorForm)
    {
        Investment investment = dataAccess.getInvestmentById(factorForm.getInvestmentId());
        investment.addFactor(new Factor(factorForm.getName(), factorForm.getDescription()));
        dataAccess.updateInvestment(investment);
        return "redirect:/";
    }
    
    @RequestMapping(value="/new", method=RequestMethod.GET)
    public String showAddFactorView(Map<String, Object> model, Long id )
    {
        Investment investment = dataAccess.getInvestmentById(id);
        model.put("investment", investment);
        return "addFactor";
    }  
    
}

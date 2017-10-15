/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import investments.BOLO.RegionAndInvestmentForm;
import static investments.controllers.BaseController.logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import investments.db.DataAccess;
import investments.db.del.AssetRegion;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;

import java.util.HashSet;

import java.util.List;
import java.util.Map;
import java.util.Set;
import javax.servlet.http.HttpServletRequest;

@Controller
@RequestMapping("/region")
public class RegionController extends BaseController
{
    @Autowired
    DataAccess dataAccess;
    
    @RequestMapping(method=RequestMethod.GET)
    public String getRegions(Map<String, Object> model)
    {        
        List<AssetRegion> regions = dataAccess.getAllRegions();
        
        model.put("regions", regions);
        return "regions";
    }
    
    @RequestMapping(value="/saveRegionWithInvestment",method=RequestMethod.POST)
    public String newGroup(RegionAndInvestmentForm RegionAndInvestment, Map<String, Object> model)
    {
        Investment investment = dataAccess.getInvestmentById(RegionAndInvestment.getInvestmentId());
        AssetRegion newRegion = new AssetRegion(RegionAndInvestment.getName());
        Set<Investment> linkedInvestments = new HashSet<>();
        linkedInvestments.add(investment);
        newRegion.setInvestments(linkedInvestments);
        AssetRegion savedRegion = dataAccess.saveRegion(newRegion);
        investment.addRegion(savedRegion);
        dataAccess.updateInvestment(investment);
        return "redirect:/investments/"+investment.getId()+"/view";
        
    }
        
    @RequestMapping(value="/newToInvestment", method=RequestMethod.GET)
    public String showAddRegionToInvestmentView(Map<String, Object> model, Long investmentId )
    {
        Investment investment = dataAccess.getInvestmentById(investmentId);
        model.put("investment", investment);
        model.put("regionForm", new RegionAndInvestmentForm());
        return "addRegion";
    }
                
    @RequestMapping(value="/{id}/delete", method = RequestMethod.GET)
    public String deleteRegion(@PathVariable int id, Map<String, Object> model)
    {
        return getRegions(model);
    }  
    
    @RequestMapping(value="/{id}", method = RequestMethod.GET)
    public String viewRegion(@PathVariable Long id, Map<String, Object> model)
    {
        AssetRegion region = dataAccess.getRegionById(id);
        model.put("region", region);
        return "viewRegion";
    }  
    
    @RequestMapping(value="/disassociate/{iid}/{rid}", method = RequestMethod.GET)
    public String disassociate(HttpServletRequest request, @PathVariable Long iid, @PathVariable Long rid)
    {        
        Investment investment = dataAccess.getInvestmentById(iid);
        AssetRegion region = dataAccess.getRegionById(rid);
        logger.info(String.format("Dissasociate region %s from investment %s", region.getName(), investment.getName()));
        investment.disassociateRegion(region);        
        dataAccess.updateInvestment(investment);
        
        String referer = request.getHeader("Referer");
        return "redirect:"+ referer;
        
    }

    @RequestMapping(value = "/update", method = RequestMethod.POST)
    public @ResponseBody
    String update(@RequestParam(value = "name") String name, @RequestParam(value = "value") String value, @RequestParam(value = "pk") String pk, HttpServletRequest request) {
        AssetRegion r = dataAccess.getRegionById(Long.parseLong(pk));
        switch(name){
            case "name":
                r.setName(value);
                break;
            case "description":
                r.setDescription(value);
        }
        dataAccess.updateRegion(r);
        return "";
    }
}


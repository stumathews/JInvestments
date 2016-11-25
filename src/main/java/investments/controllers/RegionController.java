/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import static investments.controllers.BaseController.logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import investments.db.DataAccess;
import investments.db.del.AssetRegion;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;

import java.util.List;
import java.util.Map;
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
    
    @RequestMapping(method=RequestMethod.POST)
    public String newRegion(AssetRegion region, Map<String, Object> model)
    {
        AssetRegion result = dataAccess.saveRegion(region);
        return getRegions(model);
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
}


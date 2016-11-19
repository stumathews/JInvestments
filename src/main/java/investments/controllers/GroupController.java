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
import java.util.List;
import java.util.Map;

@Controller
@RequestMapping("/group")
public class GroupController extends BaseController
{
    @Autowired
    DataAccess dataAccess;
    
    @RequestMapping(method=RequestMethod.GET)
    public String getGroups(Map<String, Object> model)
    {        
        List<InvestmentGroup> groups = dataAccess.getAllGroups();
        
        model.put("groups", groups);
        return "groups";
    }
    
    @RequestMapping(value="/{id}", method = RequestMethod.GET)
    public String viewGroup(@PathVariable Long id, Map<String, Object> model)
    {
        InvestmentGroup group = dataAccess.getGroupById(id);
        model.put("group", group);
        return "viewGroup";
    } 
    
    @RequestMapping(method=RequestMethod.POST)
    public String newGroup(InvestmentGroup group, Map<String, Object> model)
    {
        return getGroups(model);
    }
        
    @RequestMapping(value="/{id}/delete", method = RequestMethod.GET)
    public String deleteGroup(@PathVariable int groupId, Map<String, Object> model)
    {
        return getGroups(model);
    }    
}


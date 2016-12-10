/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import investments.BOLO.GroupAndInvestmentForm;
import investments.BOLO.NewChildGroupForm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import investments.db.DataAccess;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import javax.servlet.http.HttpServletRequest;

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
    
    @RequestMapping(value="/saveGroupWithInvestment",method=RequestMethod.POST)
    public String newGroup(GroupAndInvestmentForm groupAndInvestment, Map<String, Object> model)
    {
        Investment investment = dataAccess.getInvestmentById(groupAndInvestment.getInvestmentId());
        InvestmentGroup newGroup = new InvestmentGroup(groupAndInvestment.getName(), groupAndInvestment.getDescription());
        Set<Investment> linkedInvestments = new HashSet<>();
        linkedInvestments.add(investment);
        newGroup.setInvestments(linkedInvestments);
        InvestmentGroup savedGroup = dataAccess.addGroup(newGroup);
        investment.addGroup(savedGroup);
        dataAccess.updateInvestment(investment);
        
        return "redirect:/investments/"+investment.getId()+"/view";
        
    }
        
    @RequestMapping(value="/newToInvestment", method=RequestMethod.GET)
    public String showAddGroupToInvestmentView(Map<String, Object> model, Long investmentId )
    {
        Investment investment = dataAccess.getInvestmentById(investmentId);
        model.put("investment", investment);
        model.put("groupForm", new GroupAndInvestmentForm());
        return "addGroup";
    }  
        
    @RequestMapping(value="/{id}/delete", method = RequestMethod.GET)
    public String deleteGroup(@PathVariable Long groupId, Map<String, Object> model)
    {
        InvestmentGroup group = dataAccess.getGroupById(groupId);
        dataAccess.deleteGroup(group);
        return getGroups(model);
    }   
    
    @RequestMapping(value="/disassociate/{iid}/{gid}", method = RequestMethod.GET)
    public String disassociate(HttpServletRequest request, @PathVariable Long iid, @PathVariable Long gid)
    {        
        Investment investment = dataAccess.getInvestmentById(iid);
        InvestmentGroup group = dataAccess.getGroupById(gid);
        logger.info(String.format("Dissasociate group %s from investment %s", group.getName(), investment.getName()));
        investment.disassociateGroup(group);
        dataAccess.updateInvestment(investment);
        
        String referer = request.getHeader("Referer");
        return "redirect:"+ referer;
        
    }
    
    @RequestMapping(value="/newChildGroup/parent/{pid}", method = RequestMethod.GET)
    public String showNewChildForm(@PathVariable Long pid, Map<String, Object> model)
    {
        InvestmentGroup parent = dataAccess.getGroupById(pid);
        model.put("NewChildGroupForm", new NewChildGroupForm());
        model.put("parent", parent);
        return "newChildGroup";
    }
    @RequestMapping(value="/newChildGroup", method = RequestMethod.POST)
    public String submitNewChildGroupForm(NewChildGroupForm form, HttpServletRequest request, Map<String, Object> model)
    {
        InvestmentGroup parent = dataAccess.getGroupById(form.getParentId());
        InvestmentGroup child = new InvestmentGroup(form.getName(), form.getDescription());
        child.setType(form.getType());
        
        child.setName(form.getName());  
        child.setDescription(form.getDescription());
        child.setType(form.getType()); 
        InvestmentGroup savedChild = dataAccess.addGroup(child); 
                
        dataAccess.AddChildToGroup(savedChild, parent);        
                        
        model.put("group", parent);
        return "viewGroup";
    }
}


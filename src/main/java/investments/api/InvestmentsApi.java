package investments.api;

import investments.db.DataAccess;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

/***
 * REST interface for the application to provide access to javascript
 * @author Stuart
 */
@ComponentScan
@RestController
public class InvestmentsApi
{
    private final DataAccess dataAccess;
    public static Logger logger;
       
    @Autowired
    public InvestmentsApi(DataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
        logger = LoggerFactory.getLogger(this.getClass());
    }
    
    @RequestMapping("/api/InvestmentRegions")
    public Map<String, Object> investmentRegions(@RequestParam(value = "limit",required = false) Integer limit) {
        return getGraphData(limit == null ? 100 : limit, "region");
    }
    
    @RequestMapping("/api/InvestmentFactors")
    public Map<String, Object> investmentFactors(@RequestParam(value = "limit",required = false) Integer limit) {
        return getGraphData(limit == null ? 100 : limit,"factor");
    }
    
    @RequestMapping("/api/InvestmentRisks")
    public Map<String, Object> investmentRisks(@RequestParam(value = "limit",required = false) Integer limit) {
        return getGraphData(limit == null ? 100 : limit,"risk");
    }
    
    @RequestMapping("/api/InvestmentGroups")
    public Map<String, Object> investmentGroups(@RequestParam(value = "limit",required = false) Integer limit) {
        return getGraphData(limit == null ? 100 : limit, "group");
    }
    
    private Map<String, Object> getGraphData(int limit, String by) 
    {
        List<Map<String, Object>> result = new ArrayList<>();
        
        switch (by) {
            case "region":
                result = dataAccess.GetInvestmentRegionsGraph(limit);
                break;
            case "factor":
                result = dataAccess.GetInvestmentFactorsGraph(limit);
                break;
            case "risk":
                result = dataAccess.GetInvestmentRisksGraph(limit);
                break;
            case "group":
                result = dataAccess.GetInvestmentGroupsGraph(limit);
                break;
        }
        
        return graphDataToD3Format(result.iterator(),by);
    }
    
    private Map<String, Object> graphDataToD3Format(Iterator<Map<String, Object>> result, String by) {
        List<Map<String,Object>> nodes = new ArrayList<>();
        List<Map<String,Object>> rels= new ArrayList<>();
        int i=0;
        while (result.hasNext()) {
            Map<String, Object> row = result.next();
            nodes.add(map("name",row.get("investment"),"label","investment"));
            int target=i;
            i++;
            for (Object name : (Collection) row.get(by)) {
                Map<String, Object> actor = map("name", name,"label",by);
                int source = nodes.indexOf(actor);
                if (source == -1) {
                    nodes.add(actor);
                    source = i++;
                }
                rels.add(map("source",source,"target",target));
            }
        }
        return map("nodes", nodes, "links", rels);
    }

    private Map<String, Object> map(String key1, Object value1, String key2, Object value2) {
        Map<String, Object> result = new HashMap<>(2);
        result.put(key1,value1);
        result.put(key2,value2);
        return result;
    }
    
}

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
    public Map<String, Object> graph(@RequestParam(value = "limit",required = false) Integer limit) {
        return makeGraph(limit == null ? 100 : limit);
    }
    private Map<String, Object> makeGraph(int limit) {
        Iterator<Map<String, Object>> result = dataAccess.GetInvestmentRegionsGraph(limit).iterator();
        return toD3Format(result);
    }
    
    private Map<String, Object> toD3Format(Iterator<Map<String, Object>> result) {
        List<Map<String,Object>> nodes = new ArrayList<>();
        List<Map<String,Object>> rels= new ArrayList<>();
        int i=0;
        while (result.hasNext()) {
            Map<String, Object> row = result.next();
            nodes.add(map("name",row.get("investment"),"label","investment"));
            int target=i;
            i++;
            for (Object name : (Collection) row.get("region")) {
                Map<String, Object> actor = map("name", name,"label","region");
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

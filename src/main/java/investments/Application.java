package investments;

import investments.db.InvestmentRepository;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.boot.context.web.SpringBootServletInitializer;
import org.springframework.context.annotation.ComponentScan;
import java.io.File;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import org.neo4j.io.fs.FileUtils;
import org.springframework.beans.factory.annotation.Autowired;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@ComponentScan
@EnableAutoConfiguration
@SpringBootApplication
@RestController("/")
public class Application extends SpringBootServletInitializer 
{    
    @Autowired
    InvestmentRepository springData;
    
    @Override
    protected SpringApplicationBuilder configure(SpringApplicationBuilder application) {
        return application.sources(Application.class);        
    }
    
        
    public static void main(String[] args) throws Exception {
        FileUtils.deleteRecursively(new File("our.db"));        
        SpringApplication.run(Application.class, args);
    }
            
    @RequestMapping("/graph")
    public Map<String, Object> graph(@RequestParam(value = "limit",required = false) Integer limit) {
        return makeGraph(limit == null ? 100 : limit);
    }
    private Map<String, Object> makeGraph(int limit) {
        Iterator<Map<String, Object>> result = springData.graph(limit).iterator();
        return toD3Format(result);
    }
    
    private Map<String, Object> toD3Format(Iterator<Map<String, Object>> result) {
        List<Map<String,Object>> nodes = new ArrayList<Map<String,Object>>();
        List<Map<String,Object>> rels= new ArrayList<Map<String,Object>>();
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
        Map<String, Object> result = new HashMap<String,Object>(2);
        result.put(key1,value1);
        result.put(key2,value2);
        return result;
    }

    
}

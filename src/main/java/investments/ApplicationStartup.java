package investments;

import investments.db.del.AssetRegion;
import org.neo4j.graphdb.Transaction;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.ApplicationListener;
import org.springframework.data.neo4j.core.GraphDatabase;
import org.springframework.data.neo4j.template.Neo4jOperations;
import org.springframework.stereotype.Component;

@Component
public class ApplicationStartup 
implements ApplicationListener<ApplicationReadyEvent> {

    protected static Logger log = LoggerFactory.getLogger(ApplicationStartup.class);
    
    @Autowired
    private Neo4jOperations neo4jdb;
    
    @Autowired
    GraphDatabase graphDatabase;
    
  /**
   * This event is executed as late as conceivably possible to indicate that 
   * the application is ready to service requests.
     * @param event
   */
  @Override
  public void onApplicationEvent(final ApplicationReadyEvent event) {
 
     if(neo4jdb.count(AssetRegion.class) == 0 )
     {
        AssetRegion assetRegions[] = new AssetRegion[] 
        {
            new AssetRegion("JAPAN"), 
            new AssetRegion("JAPANESE SMALLER COMPANIES"),
            new AssetRegion("ASIA PACIFIC EXCLUDING JAPAN"),
            new AssetRegion("CHINA / GREATER CHINA SECTOR"),
            new AssetRegion("NORTH AMERICA"),
            new AssetRegion("NORTH AMERICAN SMALLER COMPANIES"),
            new AssetRegion("EUROPE INCLUDING UK"),
            new AssetRegion("EUROPE EXCLUDING UK"),
            new AssetRegion("EUROPEAN SMALLER COMPANIES"),
            new AssetRegion("GLOBAL"),
            new AssetRegion("GLOBAL EMERGING MARKETS") 
        };
          
        for(AssetRegion region : assetRegions) {
            try (Transaction tx = graphDatabase.beginTx()) {
                log.info("Saving region: " + region.getName());
                neo4jdb.save(region);
                tx.success();
            }
        } 
     }
  } 
}
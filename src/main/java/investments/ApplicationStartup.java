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
            new AssetRegion("UK ALL COMPANIES (Fund Sector)"), 
            new AssetRegion("UK SMALLER COMPANIES (Fund Sector)"),
            new AssetRegion("JAPAN (Fund Sector)"), 
            new AssetRegion("JAPANESE SMALLER COMPANIES (Fund Sector)"),
            new AssetRegion("ASIA PACIFIC EXCLUDING JAPAN (Fund Sector)"),
            new AssetRegion("CHINA / GREATER CHINA SECTOR (Fund Sector)"),
            new AssetRegion("NORTH AMERICA (Fund Sector)"),
            new AssetRegion("NORTH AMERICAN SMALLER COMPANIES (Fund Sector)"),
            new AssetRegion("EUROPE INCLUDING UK (Fund Sector)"),
            new AssetRegion("EUROPE EXCLUDING UK (Fund Sector)"),
            new AssetRegion("EUROPEAN SMALLER COMPANIES (Fund Sector)"),
            new AssetRegion("GLOBAL (Fund Sector)"),
            new AssetRegion("GLOBAL EMERGING MARKETS (Fund Sector)") 
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
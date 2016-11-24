package investments;

import org.neo4j.graphdb.GraphDatabaseService;
import org.neo4j.graphdb.factory.GraphDatabaseFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.neo4j.config.EnableNeo4jRepositories;
import org.springframework.data.neo4j.config.Neo4jConfiguration;
import org.springframework.transaction.annotation.EnableTransactionManagement;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

@Configuration
@EnableTransactionManagement 
@EnableNeo4jRepositories     
class ApplicationConfig extends Neo4jConfiguration 
{
    public ApplicationConfig() 
    {
        setBasePackage("investments");            
    }
        
    @Bean
    GraphDatabaseService graphDatabaseService() 
    {                
        return new GraphDatabaseFactory().newEmbeddedDatabase("our.db");
    }
    
    @Bean 
    Logger logger()
    {
        return LoggerFactory.getLogger(this.getClass());
    }
   
}
package investments;

import org.springframework.data.neo4j.repository.GraphRepository;

/**
 * Uses Spring Data to derive queries from the database
 * @author Stuart
 */
public interface SpringDataNeo4jRepository extends GraphRepository<Investment>
{
    Investment findByName(String name);    
}

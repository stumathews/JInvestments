package investments.db;

import investments.db.del.Investment;
import org.springframework.data.neo4j.repository.GraphRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

/**
 * Uses Spring Data to derive queries from the database
 * @author Stuart
 */
@RepositoryRestResource(collectionResourceRel = "investment", path = "investment")
public interface SpringDataNeo4jRepository extends GraphRepository<Investment>
{
    Investment findByName(String name);       
}

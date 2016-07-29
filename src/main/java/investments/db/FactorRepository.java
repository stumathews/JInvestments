package investments.db;

import investments.db.del.Factor;
import org.springframework.data.neo4j.repository.GraphRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

/**
 * Uses Spring Data to derive queries from the database
 * @author Stuart
 */
@RepositoryRestResource(collectionResourceRel = "factor", path = "factor")
public interface FactorRepository extends GraphRepository<Factor>
{    
    Factor findByName(@Param("name") String name);    
}
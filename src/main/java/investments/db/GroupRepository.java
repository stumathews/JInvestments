package investments.db;

import investments.db.del.InfluenceFactor;
import investments.db.del.InvestmentGroup;
import org.springframework.data.neo4j.repository.GraphRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

/**
 * Uses Spring Data to derive queries from the database
 * @author Stuart
 */
@RepositoryRestResource(collectionResourceRel = "group", path = "group")
public interface GroupRepository extends GraphRepository<InvestmentGroup>
{    
    InfluenceFactor findByName(@Param("name") String name);    
}
package investments.db;

import investments.db.del.Investment;
import java.util.List;
import java.util.Map;
import org.springframework.data.neo4j.annotation.Query;
import org.springframework.data.neo4j.repository.GraphRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

/**
 * Uses Spring Data to derive queries from the database
 * @author Stuart
 */
@RepositoryRestResource(collectionResourceRel = "investment", path = "investment")
public interface SpringDataNeo4jRepository extends GraphRepository<Investment>
{    
    Investment findByName(@Param("name") String name);
    @Query("MATCH (m:Investment)-[:HAS_REGIONS]-(a:AssetRegion) RETURN m.name, collect(a.name) as cast LIMIT {limit}")    
    List<Map<String,Object>> graph(@Param("limit") int limit);
}

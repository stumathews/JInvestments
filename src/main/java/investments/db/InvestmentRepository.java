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
public interface InvestmentRepository extends GraphRepository<Investment>
{    
    Investment findByName(@Param("name") String name);
    
    @Query("MATCH (m:Investment)-[:REGIONS]->(a:AssetRegion) RETURN m.name as investment, collect(a.name) as region LIMIT {limit}")    
    List<Map<String,Object>> GetInvestmentRegionsGraph(@Param("limit") int limit);
    
    @Query("MATCH (m:Investment)-[:FACTORS]->(f:InfluenceFactor) RETURN m.name as investment, collect(f.name) as factor LIMIT {limit}")    
    List<Map<String,Object>> GetInvestmentFactorsGraph(@Param("limit") int limit);
    
    @Query("MATCH (m:Investment)-[:RISKS]->(r:Risk) RETURN m.name as investment, collect(r.name) as risk LIMIT {limit}")    
    List<Map<String,Object>> GetInvestmentRisksGraph(@Param("limit") int limit);
    
    @Query("MATCH (m:Investment)-[:GROUPS]->(g:InvestmentGroup) RETURN m.name as investment, collect(g.name) as group LIMIT {limit}")    
    List<Map<String,Object>> GetInvestmentGroupsGraph(@Param("limit") int limit);
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db;

import investments.db.del.InfluenceFactor;
import investments.db.del.Risk;

import org.springframework.data.neo4j.repository.GraphRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;


@RepositoryRestResource(collectionResourceRel = "risk", path = "risk")
public interface RiskRepository extends GraphRepository<Risk>
{    
    Risk findByName(@Param("name") String name);    
}
package investments.db;

import investments.db.del.AssetRegion;
import org.springframework.data.neo4j.repository.GraphRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

/***
 * Provides access to Saving and retrieving AssetRegions
 * @author Stuart
 */
@RepositoryRestResource(path="assetregions")
public interface AssetRegionSpringDataRepository extends GraphRepository<AssetRegion> { }

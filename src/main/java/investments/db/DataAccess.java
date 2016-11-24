package investments.db;

import investments.db.InvestmentRepository;
import investments.db.del.AssetRegion;
import investments.db.del.InfluenceFactor;
import investments.db.del.Investment;
import investments.db.del.InvestmentGroup;
import investments.db.del.Risk;
import java.util.ArrayList;
import java.util.List;
import org.neo4j.graphdb.NotFoundException;
import org.slf4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.neo4j.conversion.Result;
import org.springframework.data.neo4j.core.GraphDatabase;
import org.springframework.data.neo4j.template.Neo4jOperations;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

/***
 * This is the data access layer of the application.
 * All access to the database to piped through this layer.
 * This layer contains access code to the neo4jdb databases and spring data interfaces 
 * @author Stuart
 */
@Repository
public class DataAccess
{
    @Autowired
    InvestmentRepository investmentRepository;
    
    @Autowired 
    AssetRegionRepository assetRegionRepository;
    
    @Autowired 
    FactorRepository factorRepository;
    
    @Autowired 
    GroupRepository groupRepository;
    
    @Autowired
    RiskRepository riskRepository;
    
    @Autowired
    private Neo4jOperations neo4jdb;
    
    @Autowired
    GraphDatabase graphDatabase;
    
    @Autowired
    Logger logger;
        
    @Transactional 
    public void deleteInvestmentbyId(Long id)
    {
        investmentRepository.delete(id);
    }
    
    @Transactional
    public List<Investment> getAllInvestments()
    {        
        Result<Investment> investments = investmentRepository.findAll();
        List<Investment> all = new ArrayList<>();
        for( Investment i : investments) {            
            all.add(i);
        }
        return all;
    }

    @Transactional
    public Investment saveInvestment(Investment investment)
    {        
        logger.warn("Persisting investment, name="+investment.getName());
        Investment result = investmentRepository.save(investment);
        logger.info("Successfully persisted investment, name = "+ result.getName());
        logger.info("risk count="+result.getRisks().size());
        return result;
    }
    
    @Transactional
    public AssetRegion saveRegion(AssetRegion region)
    {
        return neo4jdb.save(region);                
    }
    
    @Transactional
    public List<AssetRegion> getAllRegions()
    {
        Result<AssetRegion> results = neo4jdb.findAll(AssetRegion.class);        
        List<AssetRegion> regions = new ArrayList<>();
        
        for( AssetRegion region : results)
        {
            regions.add(region);
        }
        
        return regions;
    }

    @Transactional
    public AssetRegion getRegionById(Long regionId)
    {
        return assetRegionRepository.findOne(regionId);
    }

    @Transactional
    public Investment getInvestmentById(Long id) throws NotFoundException
    {
        Investment investement = investmentRepository.findOne(id);
        
        if( investement == null){
            String message = String.format("Investment(id=%f found not be found", id);
            logger.info(message);
            throw new NotFoundException(message);
        }
        return investement;
    }

    @Transactional
    public void updateInvestment(Investment investment)
    {        
        investmentRepository.save(investment);
    }

    @Transactional
    public InfluenceFactor getFactorById(Long fid)
    {
        return factorRepository.findOne(fid);
    }

    @Transactional
    public List<InfluenceFactor> getAllFactors()
    {
        logger.info("Getting all factors...");
        ArrayList<InfluenceFactor> factors = new ArrayList<>();
        for( InfluenceFactor factor : factorRepository.findAll()){
            factors.add(factor);
        }
        return factors;
    }

    @Transactional
    public void deleteFactorBy(Long id)
    {
        factorRepository.delete(id);
    }

    @Transactional
    public List<InvestmentGroup> getAllGroups()
    {
        ArrayList<InvestmentGroup> groups = new ArrayList<>();
        for( InvestmentGroup group : groupRepository.findAll())
        {
            groups.add(group);
        }
        return groups;
    }
    
    @Transactional
    public InvestmentGroup addGroup(InvestmentGroup group)
    {
        return groupRepository.save(group);
    }
    
    @Transactional
    public Risk addRisk(Risk risk)
    {
        return riskRepository.save(risk);
    }
    
    @Transactional
    public List<Risk> getAllRisks()
    {
        List<Risk> risks = new ArrayList<>();
        for( Risk r : riskRepository.findAll()){
            logger.info("Found risk=",r.getName());
            risks.add(r);
        }
        return risks;
    }

    @Transactional
    public InvestmentGroup getGroupById(Long groupId)
    {
        return groupRepository.findOne(groupId);
    }

    @Transactional
    public Risk getRiskById(Long id)
    {
        return riskRepository.findOne(id);
    }
    
    @Transactional
    public void addFactor(InfluenceFactor factor)
    {
        factorRepository.save(factor);
    }
    
}

package investments;

import java.util.ArrayList;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.neo4j.conversion.Result;
import org.springframework.data.neo4j.core.GraphDatabase;
import org.springframework.data.neo4j.template.Neo4jOperations;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

@Repository
public class DataAccess
{
    @Autowired
    SpringDataNeo4jRepository springData;
    
    @Autowired
    private Neo4jOperations neo4jdb;
    
    @Autowired
    GraphDatabase graphDatabase;
    
    @Transactional
    public List<Investment> getAllInvestments()
    {
        Result<Investment> investments = neo4jdb.findAll(Investment.class);
        List<Investment> all = new ArrayList<Investment>();
        for( Investment i : investments)
        {
            all.add(i);
        }
        return all;
    }

    @Transactional
    public void save(Investment investment)
    {
        neo4jdb.save(investment);
    }
    
}

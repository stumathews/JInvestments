package investments.services;

import investments.db.DataAccess;
import investments.db.del.InvestmentGroup;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * Services that act on group objects.
 * @author Stuart
 */
@Service
public class GroupService
{
    private final DataAccess dataAccess;
    public static Logger logger;
            
    @Autowired
    public GroupService(DataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
        logger = LoggerFactory.getLogger(this.getClass());
    }
    
    public void saveOrUpdate(InvestmentGroup group)
    {
        dataAccess.addGroup(group);
    }
}

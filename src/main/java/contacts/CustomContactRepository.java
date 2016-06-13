package contacts;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import org.neo4j.graphdb.Transaction;
import org.neo4j.helpers.collection.IteratorUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.neo4j.conversion.Result;
import org.springframework.data.neo4j.core.GraphDatabase;
import org.springframework.data.neo4j.template.Neo4jOperations;
import org.springframework.stereotype.Repository;

/**
 * Repository class that uses the new4j template instead of the Spring Data Repository
 * @author stuartm
 */
@Repository
public class CustomContactRepository 
{    
    private final static Logger log = LoggerFactory.getLogger(Application.class);
    
    @Autowired
    private ContactRepository contactRepo;   
    
    @Autowired
    private GraphDatabase graphDatabase;
    
    @Autowired
    private Neo4jOperations neo4j;

    void justDoIt() 
    {
        Contact greg = new Contact("Greg");
        Contact roy = new Contact("Roy");
        Contact craig = new Contact("Craig");
        List<Contact> team = Arrays.asList(greg, roy, craig);
        log.info("Before linking up with Neo4j...");
        team.stream().forEach((Contact person) -> log.info("\t" + person.toString()));
        Transaction tx = graphDatabase.beginTx();
        try {
            contactRepo.save(greg);
            contactRepo.save(roy);
            contactRepo.save(craig);
            greg = contactRepo.findByFirstName(greg.getFirstName());
            greg.worksWith(roy);
            greg.worksWith(craig);
            contactRepo.save(greg);
            roy = contactRepo.findByFirstName(roy.getFirstName());
            roy.worksWith(craig);
            contactRepo.save(roy);
            // We already know craig works with roy and greg
            log.info("Lookup each person by name...");
            team.stream().forEach((Contact person) -> log.info("\t" + contactRepo.findByFirstName(person.getFirstName()).toString()));
            log.info("Lookup each person by teammate...");
            for (Contact person : team) {
                log.info(person.getFirstName() + " is a teammate of...");
                contactRepo.findByTeammatesFirstName(person.getFirstName()).stream().forEach((Contact teammate) -> log.info("\t" + teammate.getFirstName()));
            }
            tx.success();
        } finally {
            tx.close();
        }
    }
    
    List<Contact> start()
    {
        List<Contact> contacts = new ArrayList<Contact>();
        Transaction tx = graphDatabase.beginTx();
        try {            
            Result<Contact> all = neo4j.findAll(Contact.class);
            contacts = IteratorUtil.asList(all);
            if( contacts.size() == 0 ) { justDoIt(); }
            
            tx.success();
        } finally {
            tx.close();
        }
        return contacts;
    }
}

package contacts;

import java.util.Arrays;
import java.util.List;
import java.util.Map;
import org.neo4j.graphdb.Transaction;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.neo4j.core.GraphDatabase;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/")
public class ContactController {
    
    private final static Logger log = LoggerFactory.getLogger(Application.class);

    private final ContactRepository contactRepo;    
    private final GraphDatabase graphDatabase;

    @Autowired
    public ContactController(ContactRepository contactRepo, GraphDatabase graphDatabase) {
        this.contactRepo = contactRepo;
        this.graphDatabase = graphDatabase;
    }

    @RequestMapping(method = RequestMethod.GET)
    public String home(Map<String, Object> model) {       
        //model.put("contacts", contactRepo.findAll());
        justDoIt();
        return "home";
    }

    @RequestMapping(method = RequestMethod.POST)
    public String submit(Contact contact) {
        contactRepo.save(contact);        
        return "redirect:/";
    }

    private void justDoIt() {
        Contact greg = new Contact("Greg");
        Contact roy = new Contact("Roy");
        Contact craig = new Contact("Craig");

        List<Contact> team = Arrays.asList(greg, roy, craig);

        log.info("Before linking up with Neo4j...");

        team.stream().forEach(person -> log.info("\t" + person.toString()));

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
                team.stream()
                        .forEach(person ->
                                log.info("\t" + contactRepo
                                                .findByFirstName(person.getFirstName()).toString()));

                log.info("Lookup each person by teammate...");
                for (Contact person : team) {
                        log.info(person.getFirstName() + " is a teammate of...");
                        contactRepo.findByTeammatesFirstName(person.getFirstName()).stream()
                                .forEach(teammate -> log.info("\t" + teammate.getFirstName()));
                }

                tx.success();
        } finally {
                tx.close();
        }
    }
}

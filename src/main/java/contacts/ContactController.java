package contacts;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import org.neo4j.graphdb.Transaction;
import org.neo4j.helpers.collection.IteratorUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.neo4j.conversion.Result;
import org.springframework.data.neo4j.core.GraphDatabase;
import org.springframework.data.neo4j.template.Neo4jOperations;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/")
public class ContactController 
{       
    private final ContactRepository contactRepo;    
    private final GraphDatabase graphDatabase;
    
    @Autowired
    private CustomContactRepository customContactRepository;
       
    @Autowired
    public ContactController(ContactRepository contactRepo, GraphDatabase graphDatabase) {
        this.contactRepo = contactRepo;
        this.graphDatabase = graphDatabase;
    }

    @RequestMapping(method = RequestMethod.GET)
    public String home(Map<String, Object> model) {
        model.put("contacts", customContactRepository.start());
        return "home";
    }

    @RequestMapping(method = RequestMethod.POST)
    public String submit(Contact contact) {
        contactRepo.save(contact);        
        return "redirect:/";
    }
}

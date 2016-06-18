package contacts;

import java.util.Map;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/")
public class HomeController {
    
    private final static Logger log = LoggerFactory.getLogger(Application.class);
    
    public HomeController() 
    {
        
    }

    @RequestMapping(method = RequestMethod.GET)
    public String home(Map<String, Object> model) 
    {     
        model.put("title", "Investement Tracker");

        return "home";
    }

    @RequestMapping(method = RequestMethod.POST)
    public String submit(Contact contact) 
    {
       
        return "redirect:/";
    }
}

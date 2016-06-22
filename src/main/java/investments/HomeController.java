package investments;

import java.lang.annotation.Annotation;
import java.util.Map;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/")
public class HomeController extends BaseController {
    
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
    public String submit(Investment investment) 
    {
       
        return "redirect:/";
    }

    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import java.io.IOException;
import java.util.Map;
import javax.servlet.http.Part;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestPart;

@Controller
@RequestMapping("/endofday")
public class EndOfDayPricesController 
{
    @RequestMapping(method = RequestMethod.GET)
    public String home(Map<String, Object> model) 
    {
        return "endOfDayStockPrices";
    }
    
       @RequestMapping(value="/upload", method=RequestMethod.POST)
  public String upload( @RequestPart("csv") Part csv, Model model) throws IOException, Exception
  {
      model.addAttribute("filename", csv.getName());
      model.addAttribute("size", csv.getSize());      
      //model.addAttribute("meals", mealService.importMealsCSV(csv.getInputStream()));
      return "endOfDayStockPrices";
  }
    
    
}

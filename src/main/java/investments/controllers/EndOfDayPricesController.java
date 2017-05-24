/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.controllers;

import investments.services.EndOfDayService;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashSet;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;
import javax.servlet.http.Part;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestPart;

@Controller
@RequestMapping("/endofday")
public class EndOfDayPricesController 
{
    @Autowired
    EndOfDayService endOfDayService;
    
    @RequestMapping(method = RequestMethod.GET)
    public String home(Map<String, Object> model) 
    {
        return "endOfDayStockPrices";
    }
    
       @RequestMapping(value="/upload", method=RequestMethod.POST)
  public String upload( @RequestPart("csv") Part csv, Model model) throws IOException, Exception
  {
      
      
      java.util.Scanner s = new Scanner(csv.getInputStream(), "UTF-8").useDelimiter("\\A");
      String content = s.hasNext() ? s.next() : "";
      String result = endOfDayService.GenerateEndOfDayCSV(content, false, "UK", "en-gb");
      model.addAttribute("content", result);
      return "endOfDayStockPricesWorker";
  }
    
    
}

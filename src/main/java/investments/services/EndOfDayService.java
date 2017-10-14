package investments.services;

import com.google.gson.Gson;
import investments.BOLO.NameLookupResult;
import investments.BOLO.TickerDetailsQuote;
import investments.BOLO.TickerDetailsRootObject;
import investments.db.DataAccess;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;
import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.HttpException;
import org.apache.commons.httpclient.HttpMethod;
import org.apache.commons.httpclient.methods.GetMethod;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import static investments.services.ObjectListToCSV.*;


/**
 * Deals with getting end of day information
 * @author Stuart
 */
@Service
public class EndOfDayService
{
    public static Logger logger;
    public EndOfDayService()
    {
        logger = LoggerFactory.getLogger(this.getClass());
    }
    
    public static String GenerateEndOfDayCSV(String csv, boolean symbolcsv, String region, String lang) throws Exception 
    {
        HashMap<String,TickerDetailsQuote> Quotes = new HashMap<>();
        
        // Open Company CSV
        HttpClient web = new HttpClient();
        String[] lines = csv.split(System.getProperty("line.separator"));
        int lineCount = 0;
        for( String line : lines)
        {
            if (line.isEmpty())
                continue;

            String[] values = line.split(",");
            String company = values[0];
            if (!company.isEmpty())
            {
                String  name = URLEncoder.encode(company,"UTF-8").replace("+", "%20");    
                
                // Try resolve the company name to a ticker symbol
                String request = String.format("http://d.yimg.com/aq/autoc?query=%s&region=%s&lang=%s",name,region,lang);
                String ticker;
                try
                {
                    if (!symbolcsv)
                    {
                        HttpMethod method = new GetMethod(request);
                        web.executeMethod(method);
                        String nameResolveRequest = new String(method.getResponseBody());
                        method.releaseConnection();

                        NameLookupResult nameResult = new Gson().fromJson(nameResolveRequest, NameLookupResult.class);
                        if (nameResult.getResultSet() == null)
                            continue;

                        if (nameResult.getResultSet().getResult() == null)
                            continue;
                        if(nameResult.getResultSet().getResult().size() == 0)
                           continue;

                        ticker = nameResult.getResultSet().getResult().get(0).getsymbol();
                    }
                    else
                    {
                        // Ticker symbl is the first value of CSV
                        ticker = values[0];
                    } 
                    // Extract ticker from result
                    // Now get stock prices about this ticker symbol
                    String tickerRequest = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22"+ticker+"%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";
                    HttpMethod method = new GetMethod(tickerRequest);
                    web.executeMethod(method);
                    String answer = new String(method.getResponseBody());
                    method.releaseConnection();

                    TickerDetailsRootObject  tickerResult = new Gson().fromJson(answer, TickerDetailsRootObject.class);
                    if (tickerResult.getquery().getcount() == 0)
                        continue;

                    // Save the details
                    String  LastTradePriceOnly = tickerResult.getquery().getresults().getquote().getLastTradePriceOnly();
                    TickerDetailsQuote  quote = tickerResult.getquery().getresults().getquote();
                    quote.setFullName(company);
                    if (!Quotes.containsKey(company))
                    {
                        Quotes.put(company, quote);
                    }

                    lineCount++;
                    System.out.println(lineCount + "-Company=" + company + " Ticker=" + ticker + " Ask=" + LastTradePriceOnly);
                }
                catch (HttpException | IllegalStateException e)
                {
                    System.out.println("Error:" + e.getMessage());
                }

            } 
            
            
        }
        
        //; dont know if this works or not
        investments.services.ObjectListToCSV objectListToCSV = new ObjectListToCSV();
        return convertListToCSV(new ArrayList<>(Quotes.values()));
    }

    
}

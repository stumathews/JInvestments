package investments;

import java.util.Arrays;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Import;
import org.springframework.webflow.mvc.builder.MvcViewFactoryCreator;
import org.springframework.webflow.mvc.servlet.FlowHandlerAdapter;
import org.springframework.webflow.mvc.servlet.FlowHandlerMapping;
import org.thymeleaf.spring4.SpringTemplateEngine;
import org.thymeleaf.spring4.view.AjaxThymeleafViewResolver;
import org.thymeleaf.spring4.view.FlowAjaxThymeleafView;
import org.thymeleaf.spring4.view.ThymeleafViewResolver;
import org.thymeleaf.templateresolver.FileTemplateResolver;
import org.thymeleaf.templateresolver.ITemplateResolver;
import org.thymeleaf.templateresolver.TemplateResolver;

@Configuration
public class ThymeleafConfiguration {  
    
  @Autowired
  WebflowConfig webflowConfig;
  
  @Bean
  public ITemplateResolver defaultTemplateResolver() {
    TemplateResolver resolver = new FileTemplateResolver();
    resolver.setSuffix(".html");
    resolver.setPrefix("src/main/resources/templates/");
    resolver.setTemplateMode("HTML5");
    resolver.setCharacterEncoding("UTF-8");
    resolver.setCacheable(false); // Allows refreshing .html files and saving without needing to redeploy
    return resolver;
  }  
  
  @Bean   
    public SpringTemplateEngine getTemplateEngine() {
    	SpringTemplateEngine templateEngine = new SpringTemplateEngine();
    	templateEngine.setTemplateResolver(defaultTemplateResolver());
	return templateEngine;
    }
  
    @Bean
    public AjaxThymeleafViewResolver thymeleafViewResolver(){
        //  compatibility with AJAX-based events (redirects) in Spring WebFlow
    	AjaxThymeleafViewResolver viewResolver = new AjaxThymeleafViewResolver(); 
        viewResolver.setViewClass(FlowAjaxThymeleafView.class);
    	viewResolver.setTemplateEngine(getTemplateEngine());
	return viewResolver;
    }
    
        
    
    
}
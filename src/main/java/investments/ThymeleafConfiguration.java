package investments;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.thymeleaf.spring4.SpringTemplateEngine;
import org.thymeleaf.spring4.view.ThymeleafView;
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

  @Bean public ThymeleafViewResolver thymeleafViewResolver(){
    //  compatibility with AJAX-based events (redirects) in Spring WebFlow
    ThymeleafViewResolver viewResolver = new ThymeleafViewResolver();
    viewResolver.setViewClass(ThymeleafView.class);
    viewResolver.setTemplateEngine(getTemplateEngine());
	return viewResolver;
  }
}
package investments;

import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.boot.context.web.SpringBootServletInitializer;
import org.springframework.context.annotation.ComponentScan;
import java.io.File;
import org.neo4j.io.fs.FileUtils;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@ComponentScan
@EnableAutoConfiguration
@SpringBootApplication
public class Application extends SpringBootServletInitializer 
{    
        
    @Override
    protected SpringApplicationBuilder configure(SpringApplicationBuilder application) {
        return application.sources(Application.class);        
    }
    
        
    public static void main(String[] args) throws Exception {
        FileUtils.deleteRecursively(new File("our.db"));        
        SpringApplication.run(Application.class, args);
    }
            
    
    
}

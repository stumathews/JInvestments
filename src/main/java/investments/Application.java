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
    /***
     * This enables us to deploy as a WAR to tomcat containers
     * @param application
     * @return 
     */
    @Override
    protected SpringApplicationBuilder configure(SpringApplicationBuilder application) {
        return application.sources(Application.class);
    }

    /***
     * Start the Spring application
     * @param args
     * @throws Exception 
     */
    public static void main(String[] args) throws Exception {
        FileUtils.deleteRecursively(new File("our.db"));        
        SpringApplication.run(Application.class, args);
    }
}

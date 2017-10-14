/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments;

import java.util.Arrays;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Bean;
import org.springframework.web.servlet.ViewResolver;
import org.springframework.webflow.config.AbstractFlowConfiguration;
import org.springframework.webflow.definition.registry.FlowDefinitionRegistry;
import org.springframework.webflow.engine.builder.support.FlowBuilderServices;
import org.springframework.webflow.executor.FlowExecutor;
import org.springframework.webflow.mvc.builder.MvcViewFactoryCreator;
import org.springframework.webflow.mvc.servlet.FlowHandlerAdapter;
import org.springframework.webflow.mvc.servlet.FlowHandlerMapping;

@Configuration
public class WebflowConfig extends AbstractFlowConfiguration
{
    @Autowired 
    ThymeleafConfiguration thymeleafConfiguration;
    
   @Bean
    public FlowDefinitionRegistry flowRegistry() {
    return getFlowDefinitionRegistryBuilder(flowBuilderServices())
        .setBasePath("/WEB-INF/flows")
        .addFlowLocationPattern("/**/*-flow.xml")        
        .build();
    } 
    
    @Bean
    public FlowHandlerMapping flowHandlerMapping() {
            FlowHandlerMapping handlerMapping = new FlowHandlerMapping();
            handlerMapping.setOrder(-1);
            handlerMapping.setFlowRegistry(flowRegistry());
            return handlerMapping;
    }

    @Bean
    public FlowHandlerAdapter flowHandlerAdapter() {
		FlowHandlerAdapter handlerAdapter = new FlowHandlerAdapter();
		handlerAdapter.setFlowExecutor(flowExecutor());		
                handlerAdapter.setSaveOutputToFlashScopeOnRedirect(true);
		return handlerAdapter;
    }
    
    @Bean
    public FlowExecutor flowExecutor() {
        return getFlowExecutorBuilder(flowRegistry()).build();
    }
    
    @Bean
    public FlowBuilderServices flowBuilderServices() {
        return getFlowBuilderServicesBuilder()
                .setViewFactoryCreator(mvcViewFactoryCreator())                
                .setDevelopmentMode(true)
                .build();
    }   
    
    @Bean
    public MvcViewFactoryCreator mvcViewFactoryCreator()
    {
        MvcViewFactoryCreator factoryCreator = new MvcViewFactoryCreator();
        factoryCreator.setViewResolvers(Arrays.asList(thymeleafConfiguration.thymeleafViewResolver()));
        factoryCreator.setUseSpringBeanBinding(true);
        return factoryCreator;
    }

    
}



package investments;

import org.springframework.context.annotation.Bean;
import org.springframework.web.socket.config.annotation.EnableWebSocket;
import org.springframework.web.socket.config.annotation.WebSocketConfigurer;
import org.springframework.web.socket.config.annotation.WebSocketHandlerRegistry;

@EnableWebSocket
public class WebSocketConfig implements WebSocketConfigurer
{
    @Override
    public void registerWebSocketHandlers(WebSocketHandlerRegistry registry)
    {
        registry.addHandler(endOfDayHandler(), "/endofdaysocket").withSockJS();
    }
    
    @Bean public EndOfDayHandler endOfDayHandler()
    {
        return new EndOfDayHandler();
    }
    
}

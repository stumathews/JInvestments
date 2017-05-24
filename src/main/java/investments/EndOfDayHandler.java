/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.socket.TextMessage;
import org.springframework.web.socket.WebSocketSession;
import org.springframework.web.socket.handler.AbstractWebSocketHandler;

public class EndOfDayHandler extends AbstractWebSocketHandler
{
    private static final Logger logger = LoggerFactory.getLogger(EndOfDayHandler.class);
    
    @Override
    protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception 
    {
        logger.info("received message: "+ message.getPayload());
        Thread.sleep(2000);
        session.sendMessage(new TextMessage("Yo"));
    }
    
}

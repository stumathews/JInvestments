package investments.controllers;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * Makes things like the logger available
 */
public class BaseController
{
    protected static Logger logger;
    
    public BaseController()
    {
        logger = LoggerFactory.getLogger(this.getClass());
    }    
}

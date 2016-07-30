package investments.controllers;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class BaseController
{
    protected static Logger logger;
    
    public BaseController()
    {
        logger = LoggerFactory.getLogger(this.getClass());
    }    
}

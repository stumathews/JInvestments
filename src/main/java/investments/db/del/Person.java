/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

/**
 * Model a human being involved or associated with an investment
 * @author Stuart
 */
class Person
{
    private String Name;

    /**
     * Name of the individual
     * @return 
     */
    public String getName()
    {
        return Name;
    }

    public void setName(String Name)
    {
        this.Name = Name;
    }
    
}

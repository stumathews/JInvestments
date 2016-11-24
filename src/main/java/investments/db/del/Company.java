/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

import java.util.List;

/**
 * This will represent or model a company.
 * @author Stuart
 */
public class Company extends Investment
{
    
    private List<Person> keyPeople;
    private String industry;

    /**
     * Key people who influence this company
     * @return 
     */
    public List<Person> getKeyPeople()
    {
        return keyPeople;
    }

    public void setKeyPeople(List<Person> keyPeople)
    {
        this.keyPeople = keyPeople;
    }

    /**
     * Industry that this company is in
     * @return 
     */
    public String getIndustry()
    {
        return industry;
    }

    public void setIndustry(String industry)
    {
        this.industry = industry;
    }

    
}

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
    private List<Service> services;
    private List<Product> products;
    private List<Person> keyPeople;
    private String industry;

    /**
     * Services that this company provides
     * @return 
     */
    public List<Service> getServices()
    {
        return services;
    }

    public void setServices(List<Service> services)
    {
        this.services = services;
    }

    /**
     * Products that this company sells/offers
     * @return 
     */
    public List<Product> getProducts()
    {
        return products;
    }

    public void setProducts(List<Product> products)
    {
        this.products = products;
    }

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

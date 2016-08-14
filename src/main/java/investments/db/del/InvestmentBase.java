/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investments.db.del;

/**
 *
 * @author Stuart
 */
public class InvestmentBase
{
    public String desirabilityStatement;
    public float initialInvestment;
    public String name;
    public String symbol;
    public String valueProposition;
    public String whyReasonStatement;
        
    public String getSymbol()
    {
        return symbol;
    }

    public void setSymbol(String symbol)
    {
        this.symbol = symbol;
    }

    public String getDesirabilityStatement()
    {
        return desirabilityStatement;
    }

    public void setDesirabilityStatement(String desirabilityStatement)
    {
        this.desirabilityStatement = desirabilityStatement;
    }

    public String getName()
    {
        return name;
    }

    public String getValueProposition()
    {
        return valueProposition;
    }

    public String getWhyReasonStatement()
    {
        return whyReasonStatement;
    }

    public void setInitialInvestment(float initialInvestment)
    {
        this.initialInvestment = initialInvestment;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public void setValueProposition(String valueProposition)
    {
        this.valueProposition = valueProposition;
    }

    public void setWhyReasonStatement(String whyReasonStatement)
    {
        this.whyReasonStatement = whyReasonStatement;
    }

    public float getInitialInvestment()
    {
        return initialInvestment;
    }
    
}

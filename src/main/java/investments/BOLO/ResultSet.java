package investments.BOLO;

import java.util.List;

public class ResultSet   
{
    private String __Query;
    public String getQuery() {
        return __Query;
    }

    public void setQuery(String value) {
        __Query = value;
    }

    private List<Result> __Result;
    public List<Result> getResult() {
        return __Result;
    }

    public void setResult(List<Result> value) {
        __Result = value;
    }

}



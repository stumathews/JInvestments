namespace WinInvestmentTracker.Models.BOLO
{
    public class HtmlAction
    {
        public HtmlAction(string name, string title, string actionName, string controllerName, object routeValues = null )
        {
            Title = title;
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
        }
        
        public string Title { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public object RouteValues { get; set; }
    }
}
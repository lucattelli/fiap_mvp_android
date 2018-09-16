namespace DSC.SmartMarket.BusinessLogic.Common
{
    public static class SortOrderHelper
    {
        public static string ToQueryTerm(this SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return "ASC";
            }
            else
            {
                return "DESC";
            }
        }
    }
}

using Core.Entities;

namespace Services.Models.ReportsModel.ResponseModels
{
    public class CruiseProfitResponseModel
    {
        public CruiseProfitResponseModel(CruiseProfit cruiseProfit)
        {
            CruiseName = cruiseProfit.CruiseName;
            PassangerProfit = cruiseProfit.PassangerProfit;
            FuelCost = cruiseProfit.FuelCost;
            Profit = cruiseProfit.Profit;
        }

        public string CruiseName { get; }

        public int PassangerProfit { get; }

        public int FuelCost { get; }

        public int Profit { get; }
    }
}

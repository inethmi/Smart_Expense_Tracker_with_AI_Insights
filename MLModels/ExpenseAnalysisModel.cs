using Microsoft.ML.Data;

namespace SmartExpenseTracker.API.MLModels
{
    public class ExpenseAnalysisModel
    {
        [LoadColumn(0)]
        public float Food { get; set; }

        [LoadColumn(1)]
        public float Transport { get; set; }

        [LoadColumn(2)]
        public float Entertainment { get; set; }

        [LoadColumn(3)]
        public float TotalSpending { get; set; }

        [LoadColumn(4)]
        public string Insight { get; set; } // AI-generated financial insight
    }
}


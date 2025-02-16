using Microsoft.ML;
using Microsoft.ML.Data;
using SmartExpenseTracker.API.MLModels;

namespace SmartExpenseTracker.API.Services
{
    public class TrainExpenseModel
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;

        public TrainExpenseModel()
        {
            _mlContext = new MLContext();

            var data = new List<ExpenseAnalysisModel>
            {
                new ExpenseAnalysisModel { Food = 200, Transport = 100, Entertainment = 150, TotalSpending = 450, Insight = "Balanced spending." },
                new ExpenseAnalysisModel { Food = 300, Transport = 150, Entertainment = 100, TotalSpending = 550, Insight = "Food spending increased by 50%." },
                new ExpenseAnalysisModel { Food = 100, Transport = 200, Entertainment = 200, TotalSpending = 500, Insight = "Transport costs are too high." }
            };

            var trainingDataView = _mlContext.Data.LoadFromEnumerable(data);

            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("Insight")
                .Append(_mlContext.Transforms.Concatenate("Features", new[] { "Food", "Transport", "Entertainment", "TotalSpending" }))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Insight", "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("Insight"));

            _model = pipeline.Fit(trainingDataView);
        }

        public string PredictInsight(float food, float transport, float entertainment, float totalSpending)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ExpenseAnalysisModel, ExpensePrediction>(_model);
            var input = new ExpenseAnalysisModel { Food = food, Transport = transport, Entertainment = entertainment, TotalSpending = totalSpending };

            return predictionEngine.Predict(input).Insight;
        }
    }

    public class ExpensePrediction
    {
        [ColumnName("PredictedLabel")]
        public string Insight { get; set; }
    }
}

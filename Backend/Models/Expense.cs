namespace SmartExpenseTracker.API.Models
{
    public class Expense
    {
        public int Id { get; set; } // Unique ID
        public string Title { get; set; } // Expense name (e.g., "Groceries")
        public float Amount { get; set; } // Cost of expense
        public string Category { get; set; } // Category (Food, Travel, etc.)
        public DateTime Date { get; set; } // Expense date
    }
}

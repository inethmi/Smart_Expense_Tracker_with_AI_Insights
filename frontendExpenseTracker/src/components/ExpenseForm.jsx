import { useState } from "react";
import axios from "axios";

const ExpenseForm = ({ onExpenseAdded }) => {
  const [title, setTitle] = useState("");
  const [amount, setAmount] = useState("");
  const [category, setCategory] = useState("");
  const [date, setDate] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!title || !amount || !category || !date) {
      alert("Please fill all fields.");
      return;
    }

    const newExpense = {
      title,
      amount: parseFloat(amount),
      category,
      date,
    };

    await axios.post("https://localhost:7034/api/Expenses", newExpense);

    alert("Expense added successfully!");
    onExpenseAdded();

    setTitle("");
    setAmount("");
    setCategory("");
    setDate("");
  };

  return (
    <form onSubmit={handleSubmit} className="p-3 bg-light border rounded">
      <h4>Add Expense</h4>
      <input
        type="text"
        className="form-control mb-2"
        placeholder="Title"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        required
      />
      <input
        type="number"
        className="form-control mb-2"
        placeholder="Amount"
        value={amount}
        onChange={(e) => setAmount(e.target.value)}
        required
      />
      <input
        type="text"
        className="form-control mb-2"
        placeholder="Category"
        value={category}
        onChange={(e) => setCategory(e.target.value)}
        required
      />
      <input
        type="date"
        className="form-control mb-2"
        value={date}
        onChange={(e) => setDate(e.target.value)}
        required
      />
      <button type="submit" className="btn btn-primary w-100">
        Add Expense
      </button>
    </form>
  );
};

export default ExpenseForm;

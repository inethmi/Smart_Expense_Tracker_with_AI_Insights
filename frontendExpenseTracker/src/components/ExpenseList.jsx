import { useEffect, useState } from "react";
import axios from "axios";

const ExpenseList = ({ refresh }) => {
  const [expenses, setExpenses] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:7034/api/Expenses")
      .then((response) => setExpenses(response.data))
      .catch(() => setExpenses([]));
  }, [refresh]);

  return (
    <div className="mt-4">
      <h4 className="mb-3 text-center text-primary">Expense List</h4>
      {expenses.length === 0 ? (
        <p className="text-muted text-center">No expenses found.</p>
      ) : (
        <div className="table-responsive">
          <table className="table table-bordered text-center">
            <thead style={{ backgroundColor: "#FFC3A0", color: "#5D576B" }}>
              <tr>
                <th>#</th>
                <th>Title</th>
                <th>Amount (LKR)</th>
                <th>Category</th>
                <th>Date</th>
              </tr>
            </thead>
            <tbody>
              {expenses.map((expense, index) => (
                <tr key={expense.id} style={{ backgroundColor: index % 2 === 0 ? "#FFEECC" : "#C3F8FF" }}>
                  <td>{index + 1}</td>
                  <td>{expense.title}</td>
                  <td>Rs. {parseFloat(expense.amount).toLocaleString("en-LK", { minimumFractionDigits: 2 })}</td>
                  <td>{expense.category}</td>
                  <td>{new Date(expense.date).toLocaleDateString("en-LK")}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

export default ExpenseList;


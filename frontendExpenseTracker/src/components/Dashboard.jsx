import { useState } from "react";
import ExpenseForm from "./ExpenseForm";
import ExpenseList from "./ExpenseList";

const Dashboard = () => {
  const [refresh, setRefresh] = useState(false);

  return (
    <div className="container mt-4">
      <h2>Expense Tracker</h2>
      <ExpenseForm onExpenseAdded={() => setRefresh(!refresh)} />
      <ExpenseList refresh={refresh} />
    </div>
  );
};

export default Dashboard;


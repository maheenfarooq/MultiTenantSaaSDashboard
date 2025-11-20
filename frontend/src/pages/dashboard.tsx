import React, { useEffect, useState } from 'react';

interface Employee { id: number; name: string; tenantId: string; }

const Dashboard = () => {
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    fetch('/api/Employee')
      .then(res => res.json())
      .then(data => setEmployees(data));
  }, []);

  return (
    <div>
      <h1>Employees</h1>
      <ul>
        {employees.map(emp => <li key={emp.id}>{emp.name} ({emp.tenantId})</li>)}
      </ul>
    </div>
  );
};

export default Dashboard;

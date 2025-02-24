import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Login from './assets/Components/Login/Login';
import Register from './assets/Components/Registration/Registration';
import ShopkeeperDashboard from './assets/Components/ShopkeeperDashboard/ShopkeeperDashboard';
import UserDashboard from './assets/Components/UserDashboard/UserDashboard';
import ViewMenu from './assets/Components/ViewMenu/ViewMenu';
import AddMenu from './assets/Components/AddMenu/AddMenu';
import './App.css';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate to="/login" />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/dashboard" element={<ShopkeeperDashboard />} />
        <Route path="/user-dashboard" element={<UserDashboard />} />
        <Route path="/view-menu" element={<ViewMenu />} />
        <Route path="/add-menu" element={<AddMenu />} />
        <Route path="*" element={<h1>Page Not Found</h1>} />
      </Routes>
    </Router>
  );
}

export default App;
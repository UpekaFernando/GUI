import React, { useState } from 'react';
import './Shopkeeper.css';

const ShopkeeperDashboard = ({ shopName }) => {
  const [currentView, setCurrentView] = useState('home');
  const [orders, setOrders] = useState([]);

  const handleViewChange = (view) => {
    setCurrentView(view);
    if (view === 'orders') {
      loadOrders();
    }
  };

  const loadOrders = () => {
    // Simulating a database fetch
    const fetchedOrders = [
      { orderDate: '2025-01-01', menuName: 'Burger Combo' },
      { orderDate: '2025-01-02', menuName: 'Pizza Special' },
    ];
    setOrders(fetchedOrders);
  };

  const clearOrderHistory = () => {
    setOrders([]);
    alert('Order history cleared.');
  };

  return (
    <div className="dashboard-container">
      <header>
        <h1>{shopName}'s Dashboard</h1>
      </header>
      <nav>
        <button onClick={() => handleViewChange('home')}>Home</button>
        <button onClick={() => handleViewChange('manageListings')}>Manage Listings</button>
        <button onClick={() => handleViewChange('orders')}>Orders</button>
        <button onClick={() => handleViewChange('salesReport')}>Sales Report</button>
        <button onClick={() => handleViewChange('customerFeedback')}>Customer Feedback</button>
        <button onClick={() => handleViewChange('settings')}>Settings</button>
      </nav>
      <main>
        {currentView === 'home' && <p>Welcome to your Dashboard!</p>}
        {currentView === 'manageListings' && <p>Manage your product listings here!</p>}
        {currentView === 'orders' && (
          <div>
            <h2>Orders</h2>
            <ul>
              {orders.map((order, index) => (
                <li key={index}>
                  {order.orderDate}: {order.menuName}
                </li>
              ))}
            </ul>
            <button onClick={clearOrderHistory}>Clear Order History</button>
          </div>
        )}
        {currentView === 'salesReport' && <p>View your sales report here!</p>}
        {currentView === 'customerFeedback' && <p>View and respond to customer feedback here!</p>}
        {currentView === 'settings' && <p>Manage your shop settings here!</p>}
      </main>
    </div>
  );
};

export default ShopkeeperDashboard;

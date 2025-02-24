import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './ShopkeeperDashboard.css';

function ShopkeeperDashboard() {
  const navigate = useNavigate();
  const [activePanel, setActivePanel] = useState('home');
  const [menuName, setMenuName] = useState('');
  const [menuDescription, setMenuDescription] = useState('');
  const [menuPrice, setMenuPrice] = useState('');
  const [orders, setOrders] = useState([]);
  const shopkeeperId = 1; // Replace with actual shopkeeper ID from login

  useEffect(() => {
    if (activePanel === 'orders') {
      fetchOrders(shopkeeperId).then(setOrders).catch(console.error);
    }
  }, [activePanel]);

  const handleAddMenu = async (e) => {
    e.preventDefault();
    const data = { shopkeeperId, name: menuName, description: menuDescription, price: menuPrice };
    try {
      const response = await fetch('http://localhost:3001/add-menu', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data),
      });
      const result = await response.json();
      alert(result.message);
    } catch (error) {
      alert('Failed to add menu item');
    }
  };

  const fetchOrders = async (shopkeeperId) => {
    try {
      const response = await fetch(`http://localhost:3001/orders/${shopkeeperId}`);
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error('Failed to fetch orders');
    }
  };

  const renderContent = () => {
    switch (activePanel) {
      case 'home':
        return <div className="content">Welcome to your Dashboard!</div>;
      case 'addMenu':
        return (
          <div className="content">
            <form onSubmit={handleAddMenu}>
              <input type="text" placeholder="Menu Name" value={menuName} onChange={(e) => setMenuName(e.target.value)} required />
              <textarea placeholder="Description" value={menuDescription} onChange={(e) => setMenuDescription(e.target.value)} required />
              <input type="number" placeholder="Price" value={menuPrice} onChange={(e) => setMenuPrice(e.target.value)} required />
              <button type="submit">Add Menu Item</button>
            </form>
          </div>
        );
      case 'orders':
        return (
          <div className="content">
            <ul className="orders-list">
              {orders.map(order => (
                <li key={order.id}>
                  Order ID: {order.id}, Menu Item ID: {order.menu_item_id}, Quantity: {order.quantity}, Date: {order.order_date}
                </li>
              ))}
            </ul>
            <button className="btn" onClick={() => alert('Order history cleared!')}>Clear Order History</button>
          </div>
        );
      // Add more cases for other buttons
      default:
        return <div className="content">Welcome to your Dashboard!</div>;
    }
  };

  return (
    <div className="dashboard-container">
      <div className="sidebar">
        <button className="btn" onClick={() => setActivePanel('home')}>Home</button>
        <button className="btn" onClick={() => setActivePanel('addMenu')}>Add Menu</button>
        <button className="btn" onClick={() => setActivePanel('orders')}>Orders</button>
        <button className="btn" onClick={() => setActivePanel('salesReport')}>Sales Report</button>
        <button className="btn" onClick={() => setActivePanel('customerFeedback')}>Customer Feedback</button>
        <button className="btn" onClick={() => setActivePanel('settings')}>Settings</button>
      </div>
      <div className="content-area">
        {renderContent()}
      </div>
    </div>
  );
}

export default ShopkeeperDashboard;
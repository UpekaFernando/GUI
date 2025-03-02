import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './ShopkeeperDashboard.css';

function ShopkeeperDashboard() {
  const navigate = useNavigate();
  const [activePanel, setActivePanel] = useState('home');
  const [menuItems, setMenuItems] = useState([]);
  const [menuName, setMenuName] = useState('');
  const [menuDescription, setMenuDescription] = useState('');
  const [menuPrice, setMenuPrice] = useState('');
  const [orders, setOrders] = useState([]);
  const [editMenuId, setEditMenuId] = useState(null);
  const shopkeeperId = 1; // Replace with actual shopkeeper ID from login

  useEffect(() => {
    if (activePanel === 'orders') {
      fetchOrders(shopkeeperId);
    } else if (activePanel === 'addMenu') {
      fetchMenuItems(shopkeeperId);
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
      fetchMenuItems(shopkeeperId);
    } catch (error) {
      alert('Failed to add menu item');
    }
  };

  const handleEditMenu = async (e) => {
    e.preventDefault();
    const data = { name: menuName, description: menuDescription, price: menuPrice };
    try {
      const response = await fetch(`http://localhost:3001/edit-menu/${editMenuId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data),
      });
      const result = await response.json();
      alert(result.message);
      setEditMenuId(null);
      setMenuName('');
      setMenuDescription('');
      setMenuPrice('');
      fetchMenuItems(shopkeeperId);
    } catch (error) {
      alert('Failed to edit menu item');
    }
  };

  const handleDeleteMenu = async (menuId) => {
    try {
      const response = await fetch(`http://localhost:3001/delete-menu/${menuId}`, {
        method: 'DELETE',
      });
      const result = await response.json();
      alert(result.message);
      fetchMenuItems(shopkeeperId);
    } catch (error) {
      alert('Failed to delete menu item');
    }
  };

  const fetchMenuItems = async (shopkeeperId) => {
    try {
      const response = await fetch(`http://localhost:3001/menu/${shopkeeperId}`);
      const result = await response.json();
      setMenuItems(result);
    } catch (error) {
      console.error('Failed to fetch menu items', error);
    }
  };

  const fetchOrders = async (shopkeeperId) => {
    try {
      const response = await fetch(`http://localhost:3001/orders/${shopkeeperId}`);
      const result = await response.json();
      setOrders(result);
    } catch (error) {
      console.error('Failed to fetch orders', error);
    }
  };

  const handleClearOrders = async () => {
    try {
      const response = await fetch(`http://localhost:3001/clear-orders/${shopkeeperId}`, {
        method: 'DELETE',
      });
      const result = await response.json();
      alert(result.message);
      setOrders([]);
    } catch (error) {
      alert('Failed to clear order history');
    }
  };

  const renderContent = () => {
    switch (activePanel) {
      case 'home':
        return <div className="content">Welcome to your Dashboard!</div>;
      case 'addMenu':
        return (
          <div className="content">
            <form onSubmit={editMenuId ? handleEditMenu : handleAddMenu}>
              <input type="text" placeholder="Menu Name" value={menuName} onChange={(e) => setMenuName(e.target.value)} required />
              <textarea placeholder="Description" value={menuDescription} onChange={(e) => setMenuDescription(e.target.value)} required />
              <input type="number" placeholder="Price" value={menuPrice} onChange={(e) => setMenuPrice(e.target.value)} required />
              <button type="submit">{editMenuId ? 'Edit Menu Item' : 'Add Menu Item'}</button>
            </form>
            <ul className="menu-list">
              {menuItems.map(item => (
                <li key={item.id}>
                  {item.name} - ${item.price}
                  <button onClick={() => {
                    setEditMenuId(item.id);
                    setMenuName(item.name);
                    setMenuDescription(item.description);
                    setMenuPrice(item.price);
                  }}>Edit</button>
                  <button onClick={() => handleDeleteMenu(item.id)}>Delete</button>
                </li>
              ))}
            </ul>
          </div>
        );
      case 'orders':
        return (
          <div className="content">
            <ul className="orders-list">
              {orders.map(order => (
                <li key={order.id}>
                  Order ID: {order.id}, Menu Item: {order.menu_item_name}, Quantity: {order.quantity}, Date: {order.order_date}
                </li>
              ))}
            </ul>
            <button className="btn" onClick={handleClearOrders}>Clear Order History</button>
          </div>
        );
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
      </div>
      <div className="content-area">
        {renderContent()}
      </div>
    </div>
  );
}

export default ShopkeeperDashboard;
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './ShopkeeperDashboard.css';
import { 
  FaHome, 
  FaPlus, 
  FaList, 
  FaUser, 
  FaComments,
  FaStore, 
  FaMapMarkerAlt, 
  FaPhone, 
  FaEnvelope, 
  FaIdCard 
} from 'react-icons/fa';

function ShopkeeperDashboard() {
  const navigate = useNavigate();
  const [activePanel, setActivePanel] = useState('home');
  const [menuItems, setMenuItems] = useState([]);
  const [menuName, setMenuName] = useState('');
  const [menuDescription, setMenuDescription] = useState('');
  const [menuPrice, setMenuPrice] = useState('');
  const [orders, setOrders] = useState([]);
  const [editMenuId, setEditMenuId] = useState(null);
  const shopkeeperId = localStorage.getItem('userId');
  const userRole = localStorage.getItem('userRole');
  const [shopName] = useState(localStorage.getItem('shopName') || 'My Shop');

  useEffect(() => {
    if (!shopkeeperId || userRole !== 'shopkeeper') {
      alert('Only shopkeepers have access to this page');
      navigate('/login');
      return;
    }

    if (activePanel === 'orders') {
      fetchOrders(shopkeeperId);
    } else if (activePanel === 'addMenu') {
      fetchMenuItems(shopkeeperId);
    }
  }, [activePanel, shopkeeperId, userRole]);

  const handleAddMenu = async (e) => {
    e.preventDefault();
    const data = { 
      shopkeeperId: parseInt(shopkeeperId), 
      name: menuName, 
      description: menuDescription, 
      price: parseFloat(menuPrice) 
    };
    
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
      const response = await fetch(`http://localhost:3001/menu/${shopkeeperId}?role=shopkeeper&userId=${shopkeeperId}`);
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

  const handleUpdateOrderStatus = async (orderId, status) => {
    try {
      const response = await fetch(`http://localhost:3001/order/${orderId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ status }),
      });
      const result = await response.json();
      alert(result.message);
      fetchOrders(shopkeeperId);
    } catch (error) {
      console.error('Failed to update order', error);
      alert('Failed to update order status');
    }
  };

  const renderContent = () => {
    switch (activePanel) {
      case 'home':
        return <div className="content">Welcome to your Dashboard!</div>;
    case 'profile':
          return <div className="content">profile is here!</div>;
      case 'addMenu':
        return (
          <div className="content">
            <form onSubmit={editMenuId ? handleEditMenu : handleAddMenu} className="menu-form">
              <input type="text" placeholder="Menu Name" value={menuName} onChange={(e) => setMenuName(e.target.value)} required />
              <textarea placeholder="Description" value={menuDescription} onChange={(e) => setMenuDescription(e.target.value)} required />
              <input type="number" placeholder="Price" value={menuPrice} onChange={(e) => setMenuPrice(e.target.value)} required />
              <button type="submit" className="btn-submit">{editMenuId ? 'Edit Menu Item' : 'Add Menu Item'}</button>
            </form>
            <ul className="menu-list">
              {menuItems.map(item => (
                <li key={item.id} className="menu-item">
                  {item.name} - Rs. {item.price}
                  <button className="btn-edit" onClick={() => {
                    setEditMenuId(item.id);
                    setMenuName(item.name);
                    setMenuDescription(item.description);
                    setMenuPrice(item.price);
                  }}>Edit</button>
                  <button className="btn-delete" onClick={() => handleDeleteMenu(item.id)}>Delete</button>
                </li>
              ))}
            </ul>
          </div>
        );
      case 'orders':
        return (
          <div className="order-panel">
            <h3>Orders</h3>
            {orders.length > 0 ? (
              <div>
                <table className="orders-table">
                  <thead>
                    <tr>
                      <th>Order ID</th>
                      <th>Customer</th>
                      <th>Menu Item</th>
                      <th>Quantity</th>
                      <th>Date</th>
                      <th>Status</th>
                      <th>Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    {orders.map(order => (
                      <tr key={order.id}>
                        <td>{order.id}</td>
                        <td>{order.user_email}</td>
                        <td>{order.menu_item_name}</td>
                        <td>{order.quantity}</td>
                        <td>{new Date(order.order_date).toLocaleString()}</td>
                        <td>{order.status}</td>
                        <td>
                          {order.status !== 'completed' && (
                            <button className="btn-complete" onClick={() => handleUpdateOrderStatus(order.id, 'completed')}>
                              Mark as Completed
                            </button>
                          )}
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
                <button className="clear-btn" onClick={handleClearOrders}>Clear All Orders</button>
              </div>
            ) : (
              <p>No orders found</p>
            )}
          </div>
        );
      case 'feedback':
        return (
          <div className="content">
            <h2>Customer Feedback</h2>
            <p>This is your feedback section</p>
          </div>
        );
      case 'profile':
        return (
          <div className="profile-container">
            <div className="profile-header">
              <div className="profile-avatar-container">
                <div className="profile-avatar">
                  <FaUser className="avatar-icon" />
                </div>
              </div>
              <div className="profile-info">
                <h2>{shopName}</h2>
                <div className="shop-meta">
                  <span className="shop-id">
                    <FaIdCard /> ID: {shopkeeperId}
                  </span>
                  <div className="shop-details">
                    <div className="shop-info-item">
                      <FaStore className="shop-info-icon" />
                      <span>Restaurant Type: Fast Food</span>
                    </div>
                    <div className="shop-info-item">
                      <FaMapMarkerAlt className="shop-info-icon" />
                      <span>Location: City Center, Main Street</span>
                    </div>
                    <div className="shop-info-item">
                      <FaPhone className="shop-info-icon" />
                      <span>Contact: +1234567890</span>
                    </div>
                    <div className="shop-info-item">
                      <FaEnvelope className="shop-info-icon" />
                      <span>Email: {localStorage.getItem('shopkeeperEmail') || 'shop@example.com'}</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        );
      default:
        return <div className="content">Welcome to your Dashboard!</div>;
    }
  };

  return (
    <div className="dashboard-container">
      <div className="dashboard-header">Food Management</div>
      <div className="sidebar">
        <button className="btn" onClick={() => setActivePanel('home')}>
          <FaHome /> Home
        </button>
        <button className="btn" onClick={() => setActivePanel('addMenu')}>
          <FaPlus /> Add Menu
        </button>
        <button className="btn" onClick={() => setActivePanel('orders')}>
          <FaList /> Orders
        </button>
        <button className="btn" onClick={() => setActivePanel('feedback')}>
          <FaComments /> Customer Feedback
        </button>
        <button className="btn" onClick={() => setActivePanel('profile')}>
          <FaUser /> Profile
        </button>
      </div>
      <div className="content-area">
        {renderContent()}
      </div>
    </div>
  );
}

export default ShopkeeperDashboard;
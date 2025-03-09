import React, { useState, useEffect } from 'react';
import './UserDashboard.css';
import { FaStore, FaStar, FaMapMarkerAlt, FaClock, FaUser, FaWallet } from 'react-icons/fa';

function UserDashboard() {
  const [activeTab, setActiveTab] = useState('home');
  const [shops, setShops] = useState([]);
  const [selectedShop, setSelectedShop] = useState(null);
  const [menuItems, setMenuItems] = useState([]);
  const [orderHistory, setOrderHistory] = useState([]);
  const [userBalance] = useState(5000); // Fixed balance of Rs. 5000
  const email = localStorage.getItem('userEmail') || 'user@example.com'; // Get email from localStorage or use default
  const userId = 1; // Replace with actual user ID from login

  useEffect(() => {
    if (activeTab === 'nearbyShops') fetchShops();
    else if (activeTab === 'orderHistory') fetchUserOrders();
  }, [activeTab]);

  const fetchShops = async () => {
    try {
      const response = await fetch('http://localhost:3001/shops');
      setShops(await response.json());
    } catch (error) {
      console.error('Failed to fetch shops', error);
    }
  };

  const fetchMenuItems = async (shopkeeperId) => {
    try {
      const response = await fetch(`http://localhost:3001/menu/${shopkeeperId}`);
      setMenuItems(await response.json());
    } catch (error) {
      console.error('Failed to fetch menu items', error);
    }
  };

  const fetchUserOrders = async () => {
    try {
      const response = await fetch(`http://localhost:3001/user-orders/${userId}`);
      setOrderHistory(await response.json());
    } catch (error) {
      console.error('Failed to fetch order history', error);
    }
  };

  const handlePlaceOrder = async (menuItemId) => {
    const data = { userId, shopkeeperId: selectedShop.id, menuItemId, quantity: 1 };
    try {
      const response = await fetch('http://localhost:3001/place-order', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data),
      });
      alert((await response.json()).message);
      fetchUserOrders(); // Refresh order history after placing an order
    } catch (error) {
      alert('Failed to place order');
    }
  };

  const handleShopClick = async (shop) => {
    setSelectedShop(shop);
    fetchMenuItems(shop.id);
  };

  const renderContent = () => {
    switch (activeTab) {
      case 'home':
        return (
          <div className="welcome-section">
            <h2>Welcome to Food Management</h2>
            <p>Discover nearby shops and explore delicious meals</p>
          </div>
        );
      case 'nearbyShops':
        return (
          <div className="shops-container">
            <h3>
              <FaStore className="section-icon" /> 
              Nearby Shops
            </h3>
            <div className="shop-grid">
              {shops.map((shop, index) => (
                <div 
                  key={shop.id} 
                  className="shop-card"
                  style={{"--card-index": index}} // For staggered animation
                  onClick={() => handleShopClick(shop)}
                >
                  <div className="shop-header">
                    <h3 className="shop-name">{shop.shop_name}</h3>
                    <div className="shop-meta">
                      <div className="shop-rating">
                        <FaStar className="star-icon" />
                        <span>{shop.rating || '4.5'}</span>
                      </div>
                      <div className="shop-distance">
                        <FaMapMarkerAlt className="location-icon" />
                        <span>{shop.distance || '2.5'}km</span>
                      </div>
                    </div>
                  </div>
                  <div className={`shop-status ${shop.is_open ? 'status-open' : 'status-closed'}`}>
                    <FaClock className="clock-icon" />
                    <span>{shop.is_open ? 'Open Now' : 'Closed'}</span>
                  </div>
                </div>
              ))}
            </div>
            
            {selectedShop && (
              <div className="menu-container">
                <h3>Menu for {selectedShop.shop_name}</h3>
                <div className="menu-grid">
                  {menuItems.map(item => (
                    <div key={item.id} className="menu-card">
                      <div className="menu-image-placeholder">
                        {item.name.charAt(0).toUpperCase()}
                      </div>
                      <h4>{item.name}</h4>
                      <p className="price">Rs.{item.price}</p>
                      <button 
                        className="order-button"
                        onClick={() => handlePlaceOrder(item.id)}
                      >
                        Order Now
                      </button>
                    </div>
                  ))}
                </div>
              </div>
            )}
          </div>
        );
      case 'offer/discounts':
        return <h2>No discounts yet.</h2>;
      case 'favourites':
          return <h2>No Favourite Items</h2>;
  

      case 'orderHistory':
        return (
          <div className="order-history-container">
            <h3>Order History</h3>
            <div className="order-grid">
              {orderHistory.map(order => (
                <div key={order.id} className="order-card">
                  <div className="order-header">
                    <span className="order-id">Order #{order.id}</span>
                    <span className="order-date">{order.order_date}</span>
                  </div>
                  <div className="order-details">
                    <p>Item: {order.menu_item_id}</p>
                    <p>Quantity: {order.quantity}</p>
                  </div>
                </div>
              ))}
            </div>
          </div>
        );
      case 'profile':
        return (
          <div className="profile-container">
            <div className="profile-header">
              <div className="profile-avatar">
                <FaUser className="avatar-icon" />
              </div>
              <div className="profile-info">
                <h2>{email}</h2>
                <div className="wallet-info">
                  <FaWallet className="wallet-icon" />
                  <span className="amount">Rs. {userBalance.toFixed(2)}</span>
                </div>
              </div>
            </div>
          </div>
        );
      default:
        return null;
    }
  };

  return (
    <div className="user-dashboard">
      <div className="dashboard-header">Food Management</div>
      <div className="dashboard-content">
        <div className="tabs">
          <button onClick={() => setActiveTab('home')}>Home</button>
          <button onClick={() => setActiveTab('nearbyShops')}>Nearby Shops</button>
          <button onClick={() => setActiveTab('offer/discounts')}>Offer/Discounts</button>
          <button onClick={() => setActiveTab('favourites')}>Favourites</button>
          <button onClick={() => setActiveTab('orderHistory')}>Order History</button>
          <button onClick={() => setActiveTab('profile')}>Profile</button>
        </div>
        <div className="tab-content-container">{renderContent()}</div>
      </div>
    </div>
  );
}

export default UserDashboard;
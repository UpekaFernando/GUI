import React, { useState, useEffect } from 'react';
import './UserDashboard.css';

function UserDashboard() {
  const [activeTab, setActiveTab] = useState('home');
  const [shops, setShops] = useState([]);
  const [selectedShop, setSelectedShop] = useState(null);
  const [menuItems, setMenuItems] = useState([]);
  const [orderHistory, setOrderHistory] = useState([]);
  const userId = 1; // Replace with actual user ID from login

  useEffect(() => {
    if (activeTab === 'nearbyShops') {
      fetchShops().then(setShops).catch(console.error);
    } else if (activeTab === 'orderHistory') {
      fetchUserOrders(userId).then(setOrderHistory).catch(console.error);
    }
  }, [activeTab]);

  const fetchShops = async () => {
    try {
      const response = await fetch('http://localhost:3001/shops');
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error('Failed to fetch shops');
    }
  };

  const fetchMenuItems = async (shopkeeperId) => {
    try {
      const response = await fetch(`http://localhost:3001/menu/${shopkeeperId}`);
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error('Failed to fetch menu items');
    }
  };

  const fetchUserOrders = async (userId) => {
    try {
      const response = await fetch(`http://localhost:3001/user-orders/${userId}`);
      const result = await response.json();
      return result;
    } catch (error) {
      throw new Error('Failed to fetch user orders');
    }
  };

  const handlePlaceOrder = async (menuItemId) => {
    const quantity = 1; // Replace with actual quantity
    const data = { userId, shopkeeperId: selectedShop.id, menuItemId, quantity };
    try {
      const response = await fetch('http://localhost:3001/place-order', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data),
      });
      const result = await response.json();
      alert(result.message);
    } catch (error) {
      alert('Failed to place order');
    }
  };

  const renderContent = () => {
    switch (activeTab) {
      case 'home':
        return (
          <div className="tab-content">
            <h2>Welcome, [User Name]! Explore shops around the campus.</h2>
            <input
              type="text"
              className="search-bar"
              placeholder="Search for a shop or product..."
            />
            <div className="nearby-shops">
              <h3>Nearby Shops</h3>
              <ul className="shop-list">
                {shops.map(shop => (
                  <li key={shop.id} onClick={() => setSelectedShop(shop)}>
                    {shop.shop_name}
                  </li>
                ))}
              </ul>
            </div>
          </div>
        );
      case 'nearbyShops':
        return (
          <div className="tab-content">
            <h3>Nearby Shops</h3>
            <ul className="shop-list">
              {shops.map(shop => (
                <li key={shop.id} onClick={() => {
                  setSelectedShop(shop);
                  fetchMenuItems(shop.id).then(setMenuItems).catch(console.error);
                }}>
                  {shop.shop_name}
                </li>
              ))}
            </ul>
            {selectedShop && (
              <div>
                <h3>Menu for {selectedShop.shop_name}</h3>
                <ul className="menu-list">
                  {menuItems.map(item => (
                    <li key={item.id}>
                      {item.name} - ${item.price}
                      <button onClick={() => handlePlaceOrder(item.id)}>Order</button>
                    </li>
                  ))}
                </ul>
              </div>
            )}
          </div>
        );
      case 'offers':
        return (
          <div className="tab-content">
            <h3>Special Offers</h3>
            <ul className="offer-list">
              <li>20% off at The Food Hub</li>
              <li>Buy 1 Get 1 Free at Campus Supplies</li>
              <li>10% off on groceries at Fresh Mart</li>
            </ul>
          </div>
        );
      case 'favorites':
        return (
          <div className="tab-content">
            <h3>Your Favorite Shops</h3>
            {/* Add favorite shops content here */}
          </div>
        );
      case 'profile':
        return (
          <div className="tab-content profile-tab">
            <img
              src="D:/GUI/GUI/desktop application/shopmanegement/profilepic.png"
              alt="Profile"
              className="profile-pic"
            />
            <h3>User</h3>
            <p>Balance: $50</p>
            <button className="btn" onClick={() => alert('Top Up Balance')}>
              Top Up Balance
            </button>
          </div>
        );
      case 'orderHistory':
        return (
          <div className="tab-content">
            <h3>Order History</h3>
            <ul className="order-history">
              {orderHistory.map(order => (
                <li key={order.id}>
                  Order ID: {order.id}, Menu Item ID: {order.menu_item_id}, Quantity: {order.quantity}, Date: {order.order_date}
                </li>
              ))}
            </ul>
            <button className="btn" onClick={() => alert('Order history cleared!')}>
              Clear Order History
            </button>
          </div>
        );
      default:
        return null;
    }
  };

  return (
    <div className="user-dashboard">
      <div className="tabs">
        <button className="tab" onClick={() => setActiveTab('home')}>Home</button>
        <button className="tab" onClick={() => setActiveTab('nearbyShops')}>Nearby Shops</button>
        <button className="tab" onClick={() => setActiveTab('offers')}>Offers/Discounts</button>
        <button className="tab" onClick={() => setActiveTab('favorites')}>Favorites</button>
        <button className="tab" onClick={() => setActiveTab('profile')}>Profile</button>
        <button className="tab" onClick={() => setActiveTab('orderHistory')}>Order History</button>
      </div>
      <div className="tab-content-container">
        {renderContent()}
      </div>
    </div>
  );
}

export default UserDashboard;
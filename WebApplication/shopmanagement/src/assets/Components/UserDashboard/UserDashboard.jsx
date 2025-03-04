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
        return <h2>Welcome! Explore nearby shops.</h2>;
      case 'nearbyShops':
        return (
          <div>
            <h3>Nearby Shops</h3>
            <ul className="shop-list">
              {shops.map(shop => (
                <li key={shop.id} onClick={() => handleShopClick(shop)}>
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
      case 'orderHistory':
        return (
          <div>
            <h3>Order History</h3>
            <ul className="order-history">
              {orderHistory.map(order => (
                <li key={order.id}>
                  Order ID: {order.id}, Menu Item ID: {order.menu_item_id}, Quantity: {order.quantity}, Date: {order.order_date}
                </li>
              ))}
            </ul>
          </div>
        );
      default:
        return null;
    }
  };

  return (
    <div className="user-dashboard">
      <div className="tabs">
        <button onClick={() => setActiveTab('home')}>Home</button>
        <button onClick={() => setActiveTab('nearbyShops')}>Nearby Shops</button>
        <button onClick={() => setActiveTab('orderHistory')}>Order History</button>
      </div>
      <div className="tab-content-container">{renderContent()}</div>
    </div>
  );
}

export default UserDashboard;
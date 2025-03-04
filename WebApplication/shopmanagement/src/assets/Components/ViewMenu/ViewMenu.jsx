import React, { useState, useEffect } from 'react';
import './ViewMenu.css';

function ViewMenu() {
  const [menus, setMenus] = useState([]);
  const [shops, setShops] = useState([]);
  const userId = localStorage.getItem('userId');
  const userRole = localStorage.getItem('userRole');

  useEffect(() => {
    console.log('Current userId:', userId); // Debug log
    console.log('Current userRole:', userRole); // Debug log
    fetchMenuItems();
  }, [userId]); // Add userId as dependency

  const fetchMenuItems = async () => {
    try {
      if (userRole === 'shopkeeper') {
        if (!userId) {
          console.error('No userId found');
          return;
        }
        console.log('Fetching menu items for shopkeeper:', userId); // Debug log
        const response = await fetch(`http://localhost:3001/menu/${userId}?role=${userRole}&userId=${userId}`);
        const data = await response.json();
        console.log('Fetched menu items:', data); // Debug log
        setMenus(data);
      } else {
        // If customer, fetch shops first
        const shopsResponse = await fetch('http://localhost:3001/shops');
        const shopsData = await response.json();
        setShops(shopsData);
        setMenus([]); // Clear menus until shop is selected
      }
    } catch (error) {
      console.error('Error fetching menu items:', error);
    }
  };

  const handleChooseMenu = async (shopId) => {
    if (!shopId) return;
    
    try {
      const response = await fetch(`http://localhost:3001/menu/${shopId}?role=${userRole}&userId=${userId}`);
      const data = await response.json();
      setMenus(data);
    } catch (error) {
      console.error('Error fetching shop menu:', error);
    }
  };

  return (
    <div className="view-menu-container">
      <div className="sidebar">
        {userRole === 'user' && shops.length > 0 && (
          <div className="shop-list">
            <h3>Select a Shop</h3>
            {shops.map(shop => (
              <button 
                key={shop.id}
                className="btn"
                onClick={() => handleChooseMenu(shop.id)}
              >
                {shop.shop_name}
              </button>
            ))}
          </div>
        )}
      </div>
      <div className="content-area">
        {userId && ( // Only show if userId exists
          <ul className="menu-list">
            {menus.map(menu => (
              <li key={menu.id}>
                <h3>{menu.name}</h3>
                <p>{menu.description}</p>
                <p>Price: ${menu.price}</p>
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}

export default ViewMenu;
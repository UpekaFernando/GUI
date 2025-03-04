import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './AddMenu.css';

function AddMenu() {
  const [itemName, setItemName] = useState('');
  const [price, setPrice] = useState('');
  const [description, setDescription] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const shopkeeperId = localStorage.getItem('userId');
    const userRole = localStorage.getItem('userRole');
  
    console.log('Adding menu item for shopkeeper:', shopkeeperId); // Debug log
    console.log('User role:', userRole); // Debug log
  
    if (!shopkeeperId || userRole !== 'shopkeeper') {
      alert('Only shopkeepers can add menu items');
      return;
    }
  
    const menuData = {
      shopkeeperId: parseInt(shopkeeperId), // Convert to number
      name: itemName,
      description,
      price: parseFloat(price)
    };
  
    console.log('Sending menu data:', menuData); // Debug log
  
    try {
      const response = await fetch('http://localhost:3001/add-menu', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(menuData),
      });
  
      const result = await response.json();
      console.log('Server response:', result); // Debug log
  
      if (response.ok) {
        alert('Menu item added successfully');
        navigate('/dashboard');
      } else {
        alert('Failed to add menu item: ' + result.message);
      }
    } catch (error) {
      console.error('Error:', error);
      alert('Failed to add menu item');
    }
  };

  return (
    <div className="add-menu-container">
      <h2>Add Menu</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Item Name:</label>
          <input
            type="text"
            value={itemName}
            onChange={(e) => setItemName(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label>Description:</label>
          <textarea
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label>Price:</label>
          <input
            type="number"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            required
          />
        </div>
        <button type="submit">Add Item</button>
      </form>
    </div>
  );
}

export default AddMenu;
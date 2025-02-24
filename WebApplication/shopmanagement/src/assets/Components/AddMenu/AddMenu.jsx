import React, { useState } from 'react';
import './AddMenu.css';

function AddMenu() {
  const [itemName, setItemName] = useState('');
  const [price, setPrice] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    // Handle add menu item logic here
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
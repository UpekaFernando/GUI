import React, { useState } from 'react';
import './ViewMenu.css';

function ViewMenu() {
  const [menus, setMenus] = useState([
    // Add some sample menu items
    { id: 1, name: 'Menu 1' },
    { id: 2, name: 'Menu 2' },
    { id: 3, name: 'Menu 3' },
  ]);

  const handleChooseMenu = () => {
    // Handle choose menu logic here
    alert('Choose Menu button clicked');
  };

  return (
    <div className="view-menu-container">
      <div className="sidebar">
        <button className="btn" onClick={handleChooseMenu}>Choose Menu</button>
      </div>
      <div className="content-area">
        <ul className="menu-list">
          {menus.map(menu => (
            <li key={menu.id}>{menu.name}</li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default ViewMenu;
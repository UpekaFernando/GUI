import React, { useState, useEffect } from 'react';
import { AppBar, Toolbar, Typography, Button, Container, List, ListItem, ListItemText, Paper, Grid, IconButton } from '@mui/material';
import { ShoppingCart } from '@mui/icons-material';
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
        return <Typography variant="h5">Welcome! Explore nearby shops.</Typography>;
      case 'nearbyShops':
        return (
          <Container>
            <Typography variant="h6">Nearby Shops</Typography>
            <List>
              {shops.map(shop => (
                <ListItem button key={shop.id} onClick={() => handleShopClick(shop)}>
                  <ListItemText primary={shop.shop_name} />
                </ListItem>
              ))}
            </List>
            {selectedShop && (
              <Paper elevation={3} style={{ padding: '16px', marginTop: '16px' }}>
                <Typography variant="h6">Menu for {selectedShop.shop_name}</Typography>
                <List>
                  {menuItems.map(item => (
                    <ListItem key={item.id}>
                      <ListItemText primary={`${item.name} - $${item.price}`} />
                      <IconButton onClick={() => handlePlaceOrder(item.id)}>
                        <ShoppingCart />
                      </IconButton>
                    </ListItem>
                  ))}
                </List>
              </Paper>
            )}
          </Container>
        );
      case 'orderHistory':
        return (
          <Container>
            <Typography variant="h6">Order History</Typography>
            <List>
              {orderHistory.map(order => (
                <ListItem key={order.id}>
                  <ListItemText primary={`Order ID: ${order.id}, Menu Item ID: ${order.menu_item_id}, Quantity: ${order.quantity}, Date: ${order.order_date}`} />
                </ListItem>
              ))}
            </List>
          </Container>
        );
      default:
        return null;
    }
  };

  return (
    <div>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" style={{ flexGrow: 1 }}>
            User Dashboard
          </Typography>
          <Button color="inherit" onClick={() => setActiveTab('home')}>Home</Button>
          <Button color="inherit" onClick={() => setActiveTab('nearbyShops')}>Nearby Shops</Button>
          <Button color="inherit" onClick={() => setActiveTab('orderHistory')}>Order History</Button>
        </Toolbar>
      </AppBar>
      <Container style={{ marginTop: '16px' }}>
        {renderContent()}
      </Container>
    </div>
  );
}

export default UserDashboard;
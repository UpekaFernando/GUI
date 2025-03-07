const express = require('express');
const db = require('./db');
const cors = require('cors');

const app = express();

app.use(cors());
app.use(express.json());

app.post('/register/:role', (req, res) => {
  const { email, password, shopName } = req.body;
  const { role } = req.params;

  const query = 'INSERT INTO users (email, password, role, shop_name) VALUES (?, ?, ?, ?)';
  db.query(query, [email, password, role, shopName || null], (err, result) => {
    if (err) {
      return res.status(500).json({ message: 'Registration failed' });
    }
    res.status(201).json({ message: 'User registered successfully' });
  });
});

app.post('/login/:role', (req, res) => {
  const { email, password } = req.body;
  const { role } = req.params;

  const query = 'SELECT * FROM users WHERE email = ? AND role = ?';
  db.query(query, [email, role], (err, results) => {
    if (err || results.length === 0) {
      return res.status(401).json({ message: 'Login failed' });
    }

    const user = results[0];
    if (password !== user.password) {
      return res.status(401).json({ message: 'Login failed' });
    }

    res.status(200).json({ message: `${role.charAt(0).toUpperCase() + role.slice(1)} logged in successfully`, userId: user.id });
  });
});

app.get('/shops', (req, res) => {
  const query = 'SELECT id, shop_name FROM users WHERE role = "shopkeeper"';
  db.query(query, (err, results) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to fetch shops' });
    }
    res.status(200).json(results);
  });
});

app.post('/add-menu', (req, res) => {
  const { shopkeeperId, name, description, price } = req.body;

  const query = 'INSERT INTO menu_items (shopkeeper_id, name, description, price) VALUES (?, ?, ?, ?)';
  db.query(query, [shopkeeperId, name, description, price], (err, result) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to add menu item' });
    }
    res.status(201).json({ message: 'Menu item added successfully' });
  });
});

app.put('/edit-menu/:menuId', (req, res) => {
  const { menuId } = req.params;
  const { name, description, price } = req.body;

  const query = 'UPDATE menu_items SET name = ?, description = ?, price = ? WHERE id = ?';
  db.query(query, [name, description, price, menuId], (err, result) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to edit menu item' });
    }
    res.status(200).json({ message: 'Menu item edited successfully' });
  });
});

app.delete('/delete-menu/:menuId', (req, res) => {
  const { menuId } = req.params;

  const query = 'DELETE FROM menu_items WHERE id = ?';
  db.query(query, [menuId], (err, result) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to delete menu item' });
    }
    res.status(200).json({ message: 'Menu item deleted successfully' });
  });
});

app.get('/menu/:shopkeeperId', (req, res) => {
  const { shopkeeperId } = req.params;

  const query = 'SELECT * FROM menu_items WHERE shopkeeper_id = ?';
  db.query(query, [shopkeeperId], (err, results) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to fetch menu items' });
    }
    res.status(200).json(results);
  });
});

app.post('/place-order', (req, res) => {
  const { userId, shopkeeperId, menuItemId, quantity } = req.body;

  const query = 'INSERT INTO orders (user_id, shopkeeper_id, menu_item_id, quantity) VALUES (?, ?, ?, ?)';
  db.query(query, [userId, shopkeeperId, menuItemId, quantity], (err, result) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to place order' });
    }
    res.status(201).json({ message: 'Order placed successfully' });
  });
});

app.get('/orders/:shopkeeperId', (req, res) => {
  const { shopkeeperId } = req.params;

  const query = 'SELECT * FROM orders WHERE shopkeeper_id = ?';
  db.query(query, [shopkeeperId], (err, results) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to fetch orders' });
    }
    res.status(200).json(results);
  });
});

app.delete('/clear-orders/:shopkeeperId', (req, res) => {
  const { shopkeeperId } = req.params;

  const query = 'DELETE FROM orders WHERE shopkeeper_id = ?';
  db.query(query, [shopkeeperId], (err, result) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to clear order history' });
    }
    res.status(200).json({ message: 'Order history cleared successfully' });
  });
});

app.get('/user-orders/:userId', (req, res) => {
  const { userId } = req.params;

  const query = 'SELECT * FROM orders WHERE user_id = ?';
  db.query(query, [userId], (err, results) => {
    if (err) {
      return res.status(500).json({ message: 'Failed to fetch user orders' });
    }
    res.status(200).json(results);
  });
});

app.listen(3001, () => {
  console.log('Server is running on port 3001');
});
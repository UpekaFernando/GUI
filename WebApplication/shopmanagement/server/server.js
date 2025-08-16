const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');

const app = express();
const PORT = 3001;

// Middleware
app.use(cors());
app.use(bodyParser.json());

// In-memory storage (replace with a database in production)
const users = [];
const shopkeepers = [];

// User registration endpoint
app.post('/register/user', (req, res) => {
  const { email, password } = req.body;
  
  // Check if user already exists
  if (users.find(user => user.email === email)) {
    return res.status(400).json({ message: 'User already exists' });
  }
  
  // Store new user
  users.push({ email, password });
  
  console.log('New user registered:', email);
  res.status(201).json({ message: 'User registered successfully' });
});

// Shopkeeper registration endpoint
app.post('/register/shopkeeper', (req, res) => {
  const { email, password, shopName } = req.body;
  
  // Check if shopkeeper already exists
  if (shopkeepers.find(shop => shop.email === email)) {
    return res.status(400).json({ message: 'Shopkeeper already exists' });
  }
  
  // Store new shopkeeper
  shopkeepers.push({ email, password, shopName });
  
  console.log('New shopkeeper registered:', email, 'Shop:', shopName);
  res.status(201).json({ message: 'Shopkeeper registered successfully' });
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
```

import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';

function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [shopName, setShopName] = useState('');
  const [role, setRole] = useState('user'); // Default role is user
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const data = { email, password };
    const endpoint = role === 'user' ? '/login/user' : '/login/shopkeeper';

    try {
      const response = await fetch(`http://localhost:3001${endpoint}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });

      if (response.ok) {
        alert(`${role.charAt(0).toUpperCase() + role.slice(1)} logged in successfully`);
        if (role === 'user') {
          navigate('/user-dashboard');
        } else {
          navigate('/dashboard');
        }
      } else {
        alert('Login failed');
      }
    } catch (error) {
      console.error('Error:', error);
      alert('Login failed');
    }
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      <div className="role-selection">
        <button className={`role-btn ${role === 'user' ? 'active' : ''}`} onClick={() => setRole('user')}>User</button>
        <button className={`role-btn ${role === 'shopkeeper' ? 'active' : ''}`} onClick={() => setRole('shopkeeper')}>Shopkeeper</button>
      </div>
      <form onSubmit={handleSubmit}>
        {role === 'shopkeeper' && (
          <div className="form-group">
            <label>Shop Name:</label>
            <input
              type="text"
              value={shopName}
              onChange={(e) => setShopName(e.target.value)}
              required
            />
          </div>
        )}
        <div className="form-group">
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit">Login</button>
      </form>
      <p>
        Don't have an account? <a href="/register">Register here</a>
      </p>
    </div>
  );
}

export default Login;
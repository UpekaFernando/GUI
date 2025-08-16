import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { loginUser } from '../../../api';
import './Login.css';
import './error-styles.css';

function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [shopName, setShopName] = useState('');
  const [role, setRole] = useState('user'); // Default role is user
  const [error, setError] = useState(''); // Error state
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(''); // Clear previous errors
    
    const data = { email, password };
    
    try {
      const result = await loginUser(data, role);
      
      if (!result.userId) {
        throw new Error(`Login failed: Please check your email and password`);
      }
      
      // Store user ID in localStorage
      localStorage.setItem('userId', result.userId.toString());
      localStorage.setItem('userRole', role);
      localStorage.setItem('userEmail', email);
      
      if (role === 'shopkeeper') {
        localStorage.setItem('shopName', shopName);
      }
      
      if (role === 'user') {
        navigate('/user-dashboard');
      } else {
        navigate('/dashboard');
      }
    } catch (error) {
      console.error('Login error details:', error);
      setError(error.message || 'Login failed: Unknown error');
    }
  };

  return (
    <div className="auth-page">
      <div className="auth-header">Food Management</div>
      <div className={`login-container ${role === 'user' ? 'user-mode' : 'shopkeeper-mode'}`}>
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
          {error && <div className="error-message">{error}</div>} {/* Display error message */}
          <button type="submit">Login</button>
        </form>
        <p>
          Don't have an account? <a href="/register">Register here</a>
        </p>
      </div>
    </div>
  );
}

export default Login;
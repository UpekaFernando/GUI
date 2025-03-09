import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './Registration.css';

export default function Register() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [role, setRole] = useState("user");
  const [shopName, setShopName] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (password !== confirmPassword) {
      alert("Passwords do not match");
      return;
    }

    const data = role === "user" ? { email, password } : { email, password, shopName };
    
    try {
      const response = await fetch(`http://localhost:3001/register/${role}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
      });

      const result = await response.json();
      alert(result.message);
    } catch (error) {
      alert("Registration failed");
    }
  };

  return (
    <div className="auth-page">
      <div className="auth-header">Food Management</div>
      <div className={`registration-container ${role === 'user' ? 'user-mode' : 'shopkeeper-mode'}`}>
        <h2>Register</h2>
        <div className="role-selection">
          <button 
            className={`role-btn ${role === 'user' ? 'active' : ''}`}
            onClick={() => setRole('user')}
          >
            User
          </button>
          <button 
            className={`role-btn ${role === 'shopkeeper' ? 'active' : ''}`}
            onClick={() => setRole('shopkeeper')}
          >
            Shopkeeper
          </button>
        </div>
        
        <form onSubmit={handleSubmit}>
          {role === "shopkeeper" && (
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
          <div className="form-group">
            <label>Confirm Password:</label>
            <input 
              type="password" 
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)} 
              required 
            />
          </div>
          <button type="submit">Register</button>
        </form>

        <p>
          Already have an account? <Link to="/login">Login here</Link>
        </p>
      </div>
    </div>
  );
}
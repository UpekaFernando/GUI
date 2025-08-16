import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { registerUser } from '../../../api';
import './Registration.css';

export default function Register() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [role, setRole] = useState("user");
  const [shopName, setShopName] = useState("");
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    setErrorMessage("");
    
    if (password !== confirmPassword) {
      setErrorMessage("Passwords do not match");
      setIsLoading(false);
      return;
    }

    const data = role === "user" ? { email, password } : { email, password, shopName };
    
    try {
      console.log('Sending registration request for:', role, data);
      const result = await registerUser(data, role);
      
      if (!result || result.message.includes('failed')) {
        throw new Error(`Registration failed: ${result?.message || 'Unknown error'}`);
      }
      
      console.log('Registration successful:', result);
      alert(result.message);
    } catch (error) {
      console.error('Registration error details:', error);
      if (error.message.includes('Failed to fetch') || error.message.includes('NetworkError')) {
        setErrorMessage("Cannot connect to the server. Please ensure the backend service is running on port 3001.");
      } else {
        setErrorMessage("Registration failed: " + (error.message || "Unknown error"));
      }
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="auth-page">
      <div className="auth-header">Food Management</div>
      <div className={`registration-container ${role === 'user' ? 'user-mode' : 'shopkeeper-mode'}`}>
        <h2>Register</h2>
        {errorMessage && <div className="error-message">{errorMessage}</div>}
        
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
          <button type="submit" disabled={isLoading}>
            {isLoading ? 'Registering...' : 'Register'}
          </button>
        </form>

        <p>
          Already have an account? <Link to="/login">Login here</Link>
        </p>
      </div>
    </div>
  );
}
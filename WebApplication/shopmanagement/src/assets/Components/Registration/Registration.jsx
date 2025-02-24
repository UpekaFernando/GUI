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
    <div>
      <h2>Register</h2>
      <button onClick={() => setRole("user")}>User</button>
      <button onClick={() => setRole("shopkeeper")}>Shopkeeper</button>

      <form onSubmit={handleSubmit}>
        {role === "shopkeeper" && (
          <input
            type="text"
            placeholder="Shop Name"
            onChange={(e) => setShopName(e.target.value)}
            required
          />
        )}
        <input type="email" placeholder="Email" onChange={(e) => setEmail(e.target.value)} required />
        <input type="password" placeholder="Password" onChange={(e) => setPassword(e.target.value)} required />
        <input type="password" placeholder="Confirm Password" onChange={(e) => setConfirmPassword(e.target.value)} required />
        <button type="submit">Register</button>
      </form>

      <p>Already have an account? <Link to="/login">Login here</Link></p>
    </div>
  );
}
// src/api.js
const API_BASE_URL = 'http://localhost:3001';

// Authentication API calls
export const registerUser = async (userData, role) => {
  const response = await fetch(`${API_BASE_URL}/register/${role}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(userData),
  });
  return response.json();
};

export const loginUser = async (credentials, role) => {
  const response = await fetch(`${API_BASE_URL}/login/${role}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(credentials),
  });
  return response.json();
};

// Shop management
export const fetchShops = async () => {
  const response = await fetch(`${API_BASE_URL}/shops`);
  return response.json();
};

// Menu management
export const addMenuItem = async (menuItem) => {
  const response = await fetch(`${API_BASE_URL}/add-menu`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(menuItem),
  });
  return response.json();
};

export const editMenuItem = async (menuId, menuItem) => {
  const response = await fetch(`${API_BASE_URL}/edit-menu/${menuId}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(menuItem),
  });
  return response.json();
};

export const deleteMenuItem = async (menuId) => {
  const response = await fetch(`${API_BASE_URL}/delete-menu/${menuId}`, {
    method: 'DELETE',
  });
  return response.json();
};

export const fetchMenuItems = async (shopkeeperId) => {
  const response = await fetch(`${API_BASE_URL}/menu/${shopkeeperId}`);
  return response.json();
};

// Order management
export const placeOrder = async (orderDetails) => {
  const response = await fetch(`${API_BASE_URL}/place-order`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(orderDetails),
  });
  return response.json();
};

export const fetchOrders = async (shopkeeperId) => {
  const response = await fetch(`${API_BASE_URL}/orders/${shopkeeperId}`);
  return response.json();
};

export const clearOrderHistory = async (shopkeeperId) => {
  const response = await fetch(`${API_BASE_URL}/clear-orders/${shopkeeperId}`, {
    method: 'DELETE',
  });
  return response.json();
};

export const fetchUserOrders = async (userId) => {
  const response = await fetch(`${API_BASE_URL}/user-orders/${userId}`);
  return response.json();
};

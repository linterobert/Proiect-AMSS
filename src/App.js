import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import ProductPage from './pages/ProductPage';
import"./navigation/Navigation.css";
import AddProductPage from './pages/AddProductPage';

function App() {
  return (
    <Router>
      <nav className = "navbar">
          <ul>
            <li className="nav-item">
              <Link to="/" className="nav-link">Home</Link>
            </li>
            <li className="nav-item">
              <Link to="/productlist" className="nav-link">Products</Link>
            </li>
            <li className="nav-item">
              <Link to="/login" className="nav-link">Log in</Link>
            </li>
            <li className="nav-item">
              <Link to="/register" className="nav-link">Register</Link>
            </li>
            <li className="nav-item">
              <Link to="/addproduct" className="nav-link">Add Product</Link>
            </li>
          </ul>
        </nav>
      <Routes>
        <Route path="/productlist" element={<ProductPage />} />
        <Route path="/addproduct" element={<AddProductPage />} />
      </Routes>
    </Router>
  );
}

export default App;

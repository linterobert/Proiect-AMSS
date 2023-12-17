// App.js

import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import './App.css';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [rememberMe, setRememberMe] = useState(false);

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  const handleRememberMeChange = () => {
    setRememberMe(!rememberMe);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('Email:', email);
    console.log('Password:', password);
    console.log('Remember Me:', rememberMe);
  };

  return (
    <div className="login-container">
      <h1 id="login">Login</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <input
            type="email"
            id="email"
            placeholder="Your Email"
            value={email}
            onChange={handleEmailChange}
            required
          />
        </div>
        <div className="form-group">
          <input
            type="password"
            id="password"
            placeholder="Your Password"
            value={password}
            onChange={handlePasswordChange}
            required
          />
        </div>
        <div className="form-group">
          <label>
            <input
              type="checkbox"
              id="rememberMe"
              checked={rememberMe}
              onChange={handleRememberMeChange}
            />
          </label>
          <h4 id="remember-me"> Remember Me </h4>
        </div>
        <div className="form-group">
          <button type="submit" id="submit">
            SIGN IN
          </button>
        </div>
        <p id="register-text">
          Are you new? <Link to="/register" className="register-link">Register</Link>
        </p>
      </form>
    </div>
  );
};

const Register = () => {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleFirstNameChange = (e) => {
    setFirstName(e.target.value);
  };

  const handleLastNameChange = (e) => {
    setLastName(e.target.value);
  };

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  const handleRegister = (e) => {
    e.preventDefault();
    console.log('First Name:', firstName);
    console.log('Last Name:', lastName);
    console.log('Email:', email);
    console.log('Password:', password);

  };

  return (
    <div className="login-container">
      <h1 id="login">Register</h1>
      <form onSubmit={handleRegister}>
        <div className="form-group">
          <input
            type="text"
            id="firstName"
            placeholder="Enter Your First Name"
            value={firstName}
            onChange={handleFirstNameChange}
            required
          />
        </div>
        <div className="form-group">
          <input
            type="text"
            id="lastName"
            placeholder="Enter Your Last Name"
            value={lastName}
            onChange={handleLastNameChange}
            required
          />
        </div>
        <div className="form-group">
          <input
            type="email"
            id="email"
            placeholder="Enter Your Email"
            value={email}
            onChange={handleEmailChange}
            required
          />
        </div>
        <div className="form-group">
          <input
            type="password"
            id="password"
            placeholder="Enter Your Password"
            value={password}
            onChange={handlePasswordChange}
            required
          />
        </div>
        <div className="form-group">
          <button type="submit" id="register-button">
            REGISTER
          </button>
        </div>
        <p id="login-text">
          Do you have an account? <Link to="/" className="login-link">Log In</Link>
        </p>
      </form>
    </div>
  );
};

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />
      </Routes>
    </Router>
  );
};

export default App;
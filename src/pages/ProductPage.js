// ProductPage.js
import { BrowserRouter, Routes, Route } from "react-router-dom";
import React, { useState } from 'react';
import ViewProduct from "./ViewProduct";
import "./cardStyles.css";

// Product component representing an individual product
const Product = ({ name, price, description, imageLink }) => {
  return (
    <div>
      <h2>{name}</h2>
      <p>{description}</p>
      <p>Price: ${price}</p>
      <img
        className="card-img"
        src={imageLink}
        style={{
          height: 200,
          width: 200,
          borderRadius: 10,
        }}
        alt={name}
      ></img>
    </div>
  );
};

// ProductPage component representing the entire product page
const ProductPage = () => {
  // Dummy product data (you can replace this with data from an API or other source)
  const products = [
    {
      id: 1,
      name: 'Custom Wedding Cake Topper',
      price: 9.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/81OugXcG1iL._AC_UY218_.jpg",
    },
    {
      id: 2,
      name: 'Personalized embossing cookie stamp',
      price: 17.99,
      description: 'Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
      imageLink: "https://m.media-amazon.com/images/I/616Tih9o6QL._AC_UY218_.jpg",
    },
    {
      id: 3,
      name: 'Green and Beige Poterry Mug',
      price: 37.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/819pgEkjFdL._AC_UY218_.jpg",
    },
    {
      id: 4,
      name: 'Handmade Rustic Vintage Cup',
      price: 29.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/618cXqAkoFL._AC_UY218_.jpg",
    },
    {
      id: 5,
      name: 'Handmade Colorful Ceramic Mug',
      price: 20.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/61H87IxWQML._AC_UY218_.jpg",
    },
    {
      id: 6,
      name: 'Embroidered Chef Apron',
      price: 30.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/61z66deOh2L._AC_UL320_.jpg",
    },
    {
      id: 7,
      name: 'Personalized Cutting Board',
      price: 24.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/81FqEA4SD6L._AC_UL320_.jpg",
    },
    {
      id: 8,
      name: 'Norwegian Rosemaling Ring',
      price: 50.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/71S0ngQT1VL._AC_UL320_.jpg",
    },
    {
      id: 9,
      name: 'Custom Wood Name Sign',
      price: 350.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/61srlsTb6jL._AC_UL320_.jpg",
    },
    {
      id: 10,
      name: 'Sterling Silver Necklace',
      price: 49.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/91ha6jYKclL._AC_UL320_.jpg",
    },
    {
      id: 11,
      name: 'Iron Infinity Bracelet',
      price: 49.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/61tJWePvH4L._AC_UL320_.jpg",
    },
    {
      id: 12,
      name: 'Custom Wind Chime',
      price: 53.99,
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
      imageLink: "https://m.media-amazon.com/images/I/81wIb1muL1L._AC_UL320_.jpg",
    },
  ];

  // State to manage the selected product
  const [selectedProduct, setSelectedProduct] = useState(null);

  return (
    <div>
      <h1 className="product-list-title">Product List</h1>

      {/* List of products */}
      <div className="parent-container"> 
        {products.map((product) => {
            return <ViewProduct product={product} />;
        })}
      </div>
      {/* Selected product details */}
      {selectedProduct && (
        <div>
          <h2>Selected Product</h2>
          <Product {...selectedProduct} />
          <button onClick={() => setSelectedProduct(null)}>Close Details</button>
        </div>
      )}
    </div>
  );
};

export default ProductPage;

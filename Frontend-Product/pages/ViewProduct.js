import React, { useState, useEffect } from "react";
import "./cardStyles.css";

function ViewProduct(props) {
  const product = props.product;
  const [isRefreshing, setIsRefreshing] = useState(false);

  const handleRefresh = () => {
    setIsRefreshing(true);
    setTimeout(() => {
      window.location.reload();
    }, 100);
  };

  const handleDeleteAndRefresh = () => {
    // Add logic for deleting the product
    // deleteProduct(product.id);
    handleRefresh();
  };

  const handleAddToCart = () => {
    // Add logic for adding the product to the cart
    // You can use a state, a context, or any other method to manage the cart state
    console.log(`Product added to cart: ${product.name}`);
  };

  return (
    <div>
      <div className="card" style={{ display: "flex" }}>
        <div className="media p-4">
          <img
            className="card-img"
            src={product.imageLink}
            style={{
              height: 200,
              width: 200,
              borderRadius: 10,
            }}
            alt={product.name}
          ></img>
        </div>
        <div className="product-info">
          <h3
            className="card-title"
            style={{ paddingLeft: 15, paddingRight: 15 }}
          >
            {product.name}
          </h3>
          <h5 style={{ paddingLeft: 18 }}>Price: ${product.price}</h5>
          <button className="add-to-cart-btn" onClick={handleAddToCart}>
            Add to Cart
          </button>
        </div>
      </div>
    </div>
  );
}

export default ViewProduct;

import React, { useState } from "react";
import AddProductForm from "../forms/AddProductForm";
import "./cardStyles.css";

function AddProductPage() {
  const [stompClient, setStompClient] = useState(null);

  return (
    <div className="form-page">
      <div className="form-box">
        <h3 className="">Product Details</h3>
        <p className="">Please enter your product details!</p>
        <AddProductForm stompClient={stompClient} />
      </div>
    </div>
  );
}

export default AddProductPage;

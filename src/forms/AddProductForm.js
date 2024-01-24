import React from "react";
import { useForm } from "react-hook-form";
import "./formstyles.css";

function AddProductForm(props) {
  const { register, handleSubmit } = useForm();
  const stompClient = props.stompClient;

  function validateProductAddValues(formData) {
    var errorToDisplay = "";
    const name = formData.get("name");
    const description = formData.get("description");
    const price = formData.get("price");
    const imageLink = formData.get("imageLink");

    const allowedImgTypes = ["image/jpeg", "image/png", "image/gif"];

    if (!name) {
      errorToDisplay += "You must insert a product name";
    }

    if (!description) {
      if (errorToDisplay) {
        errorToDisplay += " and product description";
      } else {
        errorToDisplay += "You must insert a product description";
      }
    }

    if (!price) {
      if (errorToDisplay) {
        errorToDisplay += " and a price";
      } else {
        errorToDisplay += "You must insert a price";
      }
    }

    if (!imageLink) {
        if (errorToDisplay) {
          errorToDisplay += " and an image";
        } else {
          errorToDisplay += "You must insert an image";
        }
      }

    if (errorToDisplay) {
      alert(errorToDisplay);
      return false;
    }

    return true;
  }

  const onSubmit = async (data) => {
    const formData = new FormData();

    formData.append("name", data.name);
    formData.append("description", data.description);
    formData.append("price", data.price);
    formData.append("imageLink", data.imageLink);

    if (validateProductAddValues(formData)) {
      try {
        alert("Product has been added successfully!");
      } catch (e) {
        alert("Something went wrong with adding the Product!");
      }
    }
  };

  return (
    <div className="d-flex flex-column align-items-center mt-5">
      <h2 className="mb-4">Add a Product</h2>
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="w-50"
        encType="multipart/form-data"
      >
        <div className="form-floating mb-3">
          <input
            type="text"
            className="form-control"
            id="name"
            name="name"
            placeholder="Product Name"
            {...register("name")}
          />
          <label htmlFor="name"> Product Name</label>
        </div>

        <div className="form-floating mb-3">
          <input
            type="text"
            className="form-control"
            id="description"
            name="description"
            placeholder="Product description"
            {...register("description")}
          />
          <label htmlFor="description"> Product description</label>
        </div>

        <div className="form-floating mb-3">
          <input
            type="text"
            className="form-control"
            id="price"
            name="price"
            placeholder="Product price"
            {...register("price")}
          />
          <label htmlFor="price"> Product price</label>
        </div>

        <div className="mb-3 d-flex flex-column justify-content-center">
          
          <input
            className="form-control"
            id="imgLink"
            type="file"
            {...register("imgLink")}
          />
          <label htmlFor="imgLink" className="form-label">
            Choose an image
          </label>
        </div>

        <button className="btn btn-primary px-5 add-btn" type="submit">
          Add Product
        </button>
      </form>
    </div>
  );
}

export default AddProductForm;
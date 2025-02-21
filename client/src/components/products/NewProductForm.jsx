import { useEffect, useState } from 'react';
import './NewProductForm.css';
import { getAllCategories } from '../../managers/categoryManager';
import { addNewProduct } from '../../managers/productManager';
import closeIcon from '../../assets/close.png';

export const NewProductForm = ({
  isNewProductFormOpen,
  onClose,
  getAllProductsAndSetProducts,
}) => {
  const [product, setProduct] = useState({});
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    getAllCategories().then((data) => setCategories(data));
  }, []);

  const handleOnChange = (e) => {
    const { name, value } = e.target;
    const fieldsToParse = ['price', 'categoryId', 'stockQuantity'];

    setProduct((prevState) => ({
      ...prevState,
      [name]: fieldsToParse.includes(name) ? parseInt(value) : value,
    }));
  };

  const handleSubmitBtnClick = (e) => {
    e.preventDefault();

    if (
      !product.name ||
      !product.price ||
      !product.stockQuantity ||
      !product.imageUrl ||
      !product.description
    ) {
      alert('Please enter all fields before submitting');
    } else {
      addNewProduct(product).then(() => {
        onClose();
        getAllProductsAndSetProducts();
      });
    }
  };

  return (
    <div className={`modal ${isNewProductFormOpen ? 'open' : ''}`}>
      <div className="modal-content">
        <div className="close-add-product-btn-wrapper">
          <button
            className="close-add-product-modal-btn"
            type="button"
            onClick={onClose}
          >
            <img className="x-icon-close-add-product-img" src={closeIcon} />
          </button>
        </div>
        <h2>Add New Product</h2>
        <form>
          <label>
            Name:
            <input onChange={handleOnChange} type="text" name="name" />
          </label>
          <label>
            Price:
            <input type="number" name="price" onChange={handleOnChange} />
          </label>
          <label>
            Category
            <select name="categoryId" onChange={handleOnChange}>
              <option value="">--Please select category</option>
              {categories.map((c) => {
                return (
                  <option key={c.id} value={c.id}>
                    {c.name}
                  </option>
                );
              })}
            </select>
          </label>
          <label>
            Description:
            <textarea name="description" onChange={handleOnChange} />
          </label>
          <label>
            Stock Quantity:
            <input
              type="number"
              name="stockQuantity"
              onChange={handleOnChange}
            />
          </label>
          <label>
            Image Url:
            <input type="text" name="imageUrl" onChange={handleOnChange} />
          </label>

          <div className="modal-actions">
            <button
              className="submit-new-product-btn"
              type="submit"
              onClick={handleSubmitBtnClick}
            >
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

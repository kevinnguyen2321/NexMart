import { useEffect, useState } from 'react';
import { getAllCategories } from '../../managers/categoryManager';
import { editProduct, getProductById } from '../../managers/productManager';
import { useNavigate } from 'react-router-dom';

export const EditProductForm = ({
  isEditProductModalOpen,
  selectedProductId,
  onClose,
  updateProducts,
}) => {
  const [product, setProduct] = useState({});
  const [categories, setCategories] = useState([]);

  const navigate = useNavigate();

  useEffect(() => {
    getAllCategories().then((data) => setCategories(data));
  }, []);

  useEffect(() => {
    getProductById(selectedProductId).then((data) => setProduct(data));
  }, [selectedProductId]);

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
      !product.description
    ) {
      alert('Please enter all fields before submitting');
    } else {
      editProduct(selectedProductId, product).then(() => {
        onClose();
        updateProducts();
      });
    }
  };

  return (
    <div className={`modal ${isEditProductModalOpen ? 'open' : ''}`}>
      <div className="modal-content">
        <h2>Edit Product</h2>
        <form>
          <label>
            Name:
            <input
              onChange={handleOnChange}
              type="text"
              name="name"
              value={product.name ? product.name : ''}
            />
          </label>
          <label>
            Price:
            <input
              type="number"
              name="price"
              onChange={handleOnChange}
              value={product.price ? product.price : ''}
            />
          </label>
          <label>
            Category
            <select
              name="categoryId"
              onChange={handleOnChange}
              value={product.categoryId ? product.categoryId : ''}
            >
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
            <textarea
              name="description"
              onChange={handleOnChange}
              value={product.description ? product.description : ''}
            />
          </label>
          <label>
            Stock Quantity:
            <input
              type="number"
              name="stockQuantity"
              onChange={handleOnChange}
              value={product.stockQuantity ? product.stockQuantity : ''}
            />
          </label>
          <label>
            Image Url:
            <input
              type="text"
              name="imageUrl"
              onChange={handleOnChange}
              value={product.imageUrl ? product.imageUrl : ''}
            />
          </label>

          <div className="modal-actions">
            <button type="button" onClick={onClose}>
              Close
            </button>
            <button type="submit" onClick={handleSubmitBtnClick}>
              Save
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

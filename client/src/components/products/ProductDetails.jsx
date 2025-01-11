import { useEffect, useState } from 'react';
import './NewProductForm.css';
import { getProductById } from '../../managers/productManager';

export const ProductDetails = ({
  isProductDetailsOpen,
  selectedProductId,
  onClose,
}) => {
  const [product, setProduct] = useState({});

  useEffect(() => {
    getProductById(selectedProductId).then((data) => setProduct(data));
  }, [selectedProductId]);

  return (
    <div className={`modal ${isProductDetailsOpen ? 'open' : ''}`}>
      <div className="modal-content">
        <div>
          <h3>Product Details</h3>
          <p>Name: {product.name}</p>
          <p>Category: {product?.category?.name}</p>
          <img
            src={
              product.imageUrl
                ? product.imageUrl
                : `https://dummyimage.com/300x200/000/fff&text=${product.name}`
            }
          />
        </div>
        <div className="modal-actions">
          <button type="button" onClick={onClose}>
            Close
          </button>
          <button type="submit">Submit</button>
        </div>
      </div>
    </div>
  );
};

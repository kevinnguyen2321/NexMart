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
          <h4>{product.name}</h4>
          <p>${product.price}</p>
          <p className="product-details-category">
            <span>Category:</span> {product?.category?.name}
          </p>
          <img
            className="product-details-img"
            src={
              product.imageUrl
                ? product.imageUrl
                : `https://dummyimage.com/300x200/000/fff&text=${product.name}`
            }
          />
          <p className="product-description">
            <span>Description: </span>
            {product.description}
          </p>
        </div>
        <div className="modal-actions">
          <button type="button" onClick={onClose}>
            Close
          </button>
        </div>
      </div>
    </div>
  );
};

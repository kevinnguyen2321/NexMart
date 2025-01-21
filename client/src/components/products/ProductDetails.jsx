import { useEffect, useState } from 'react';
import './NewProductForm.css';
import { getProductById } from '../../managers/productManager';
import closeIcon from '../../assets/close.png';

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
      <div className="modal-content product-details">
        <div className="modal-actions">
          <button className="close-product-btn" type="button" onClick={onClose}>
            <img className="red-x-icon" src={closeIcon} />
          </button>
        </div>
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
      </div>
    </div>
  );
};

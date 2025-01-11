import { useEffect, useState } from 'react';
import { getAllProducts } from '../../managers/productManager';
import './ProductsListAdmin.css';
import { NewProductForm } from './NewProductForm';

export const ProductsListAdmin = () => {
  const [products, setProducts] = useState([]);
  const [isNewProductFormOpen, setIsNewProductFormOpen] = useState(false);

  const handleAddBtnClick = () => {
    setIsNewProductFormOpen(true);
  };

  const handleCloseModal = () => {
    setIsNewProductFormOpen(false);
  };

  useEffect(() => {
    getAllProducts().then((data) => setProducts(data));
  }, []);

  return (
    <div>
      <div className="products-list-wrapper">
        <div>
          <button onClick={handleAddBtnClick}>Add new product</button>
        </div>
        <div className="products-wrapper-admin">
          <h3>Products</h3>
          {products.map((p) => {
            return (
              <div className="product-list-card" key={p.id}>
                <div className="product-list-card-info">
                  <p>
                    <span>Product Id:</span> {p.id}
                  </p>
                  <p>
                    <span>Name:</span> {p.name}
                  </p>
                  <p>
                    <span>Stock Quantity:</span> {p.stockQuantity}
                  </p>
                  <p>
                    <span>Price:</span> ${p.price}
                  </p>
                </div>
                <div className="product-list-btn-wrapper">
                  <button>View</button>
                  <button>Edit</button>
                  <button>Delete</button>
                </div>
              </div>
            );
          })}
        </div>
      </div>
      <div>
        {isNewProductFormOpen && (
          <NewProductForm
            isNewProductFormOpen={isNewProductFormOpen}
            onClose={handleCloseModal}
          />
        )}
      </div>
    </div>
  );
};

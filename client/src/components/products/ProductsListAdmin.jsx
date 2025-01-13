import { useEffect, useState } from 'react';
import { getAllProducts } from '../../managers/productManager';
import './ProductsListAdmin.css';
import { NewProductForm } from './NewProductForm';
import { ProductDetails } from './ProductDetails';
import { EditProductForm } from './EditProductForm';

export const ProductsListAdmin = () => {
  const [products, setProducts] = useState([]);
  const [isNewProductFormOpen, setIsNewProductFormOpen] = useState(false);
  const [isProductDetailsOpen, setIsProductDetailsOpen] = useState(false);
  const [isEditProductModalOpen, setIsEditProductModalOpen] = useState(false);
  const [selectedProductId, setSelectedProductId] = useState(null);

  const getAllProductsAndSetProducts = () => {
    getAllProducts().then((data) => setProducts(data));
  };

  const handleAddBtnClick = () => {
    setIsNewProductFormOpen(true);
  };

  const handleCloseModal = () => {
    setIsNewProductFormOpen(false);
  };

  const handleProductDetailsToggle = (productId) => {
    setIsProductDetailsOpen((prev) => !prev);
    setSelectedProductId(productId);
  };

  const handleCloseProductDetailModal = () => {
    setIsProductDetailsOpen(false);
    setSelectedProductId(null);
  };

  const handleEditProductToggle = (productId) => {
    setIsEditProductModalOpen((prev) => !prev);
    setSelectedProductId(productId);
  };

  const handleCloseEditModal = () => {
    setIsEditProductModalOpen(false);
    setSelectedProductId(null);
  };

  useEffect(() => {
    getAllProductsAndSetProducts();
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
                  <button onClick={() => handleProductDetailsToggle(p.id)}>
                    View
                  </button>
                  <button onClick={() => handleEditProductToggle(p.id)}>
                    Edit
                  </button>
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
      <div>
        {isProductDetailsOpen && (
          <ProductDetails
            isProductDetailsOpen={isProductDetailsOpen}
            selectedProductId={selectedProductId}
            onClose={handleCloseProductDetailModal}
          />
        )}
      </div>
      <div>
        {isEditProductModalOpen && (
          <EditProductForm
            isEditProductModalOpen={isEditProductModalOpen}
            selectedProductId={selectedProductId}
            onClose={handleCloseEditModal}
            updateProducts={getAllProductsAndSetProducts}
          />
        )}
      </div>
    </div>
  );
};

import { useEffect, useState } from 'react';
import { deleteProduct, getAllProducts } from '../../managers/productManager';
import './ProductsListAdmin.css';
import { NewProductForm } from './NewProductForm';
import { ProductDetails } from './ProductDetails';
import { EditProductForm } from './EditProductForm';
import addIcon from '../../assets/add.png';
import viewIcon from '../../assets/view.png';
import editIcon from '../../assets/edit.png';
import deleteIcon from '../../assets/delete.png';

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

  const handleDeleteBtnClick = (product) => {
    const userConfirmed = window.confirm(
      `Are you sure you want to delete ${product.name}?`
    );

    if (userConfirmed) {
      deleteProduct(product.id).then(() => getAllProductsAndSetProducts());
    }
  };

  useEffect(() => {
    getAllProductsAndSetProducts();
  }, []);

  return (
    <div>
      <div className="products-list-wrapper">
        <div className="products-wrapper-admin">
          <div className="plus-icon-btn-wrapper">
            <button
              className="add-product-admin-btn"
              onClick={handleAddBtnClick}
            >
              <img className="add-new-product-icon" src={addIcon} />
            </button>
          </div>
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
                  <button
                    className="view-product-btn-admin"
                    onClick={() => handleProductDetailsToggle(p.id)}
                  >
                    <img src={viewIcon} className="view-product-admin-image" />
                  </button>
                  <button
                    className="edit-product-button"
                    onClick={() => handleEditProductToggle(p.id)}
                  >
                    <img className="edit-product-image" src={editIcon} />
                  </button>
                  <button
                    className="delete-product-btn"
                    onClick={() => handleDeleteBtnClick(p)}
                  >
                    <img className="delete-product-image" src={deleteIcon} />
                  </button>
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

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
import dropdownArrowIcon from '../../assets/dropdown.png';

export const ProductsListAdmin = () => {
  const [products, setProducts] = useState([]);
  const [isNewProductFormOpen, setIsNewProductFormOpen] = useState(false);
  const [isProductDetailsOpen, setIsProductDetailsOpen] = useState(false);
  const [isEditProductModalOpen, setIsEditProductModalOpen] = useState(false);
  const [selectedProductId, setSelectedProductId] = useState(null);
  const [productKeyword, setProductKeyword] = useState('');
  const [isSortDropdownOpen, setIsSortDropdownOpen] = useState(false);
  const [sortOption, setSortOption] = useState('');
  const [filteredProducts, setFilteredProducts] = useState([]);

  useEffect(() => {
    getAllProductsAndSetProducts();
  }, []);

  useEffect(() => {
    let updatedProducts = products;

    // Filter by keyword
    if (productKeyword) {
      updatedProducts = updatedProducts.filter(
        (product) =>
          product.name &&
          product.name.toLowerCase().includes(productKeyword.toLowerCase())
      );
    }

    // Sort products based on the selected sort option
    if (sortOption === 'low-to-high') {
      updatedProducts = [...updatedProducts].sort((a, b) => a.price - b.price);
    } else if (sortOption === 'high-to-low') {
      updatedProducts = [...updatedProducts].sort((a, b) => b.price - a.price);
    } else if (sortOption === 'low-stock') {
      updatedProducts = [...updatedProducts].sort(
        (a, b) => a.stockQuantity - b.stockQuantity
      );
    } else if (sortOption === 'high-stock') {
      updatedProducts = [...updatedProducts].sort(
        (a, b) => b.stockQuantity - a.stockQuantity
      );
    }

    setFilteredProducts(updatedProducts);
  }, [productKeyword, sortOption, products]);

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

  const handleSearchChange = (e) => {
    setProductKeyword(e.target.value);
  };

  const toggleSortDropdown = () => {
    setIsSortDropdownOpen((prev) => !prev);
  };

  const handleSortOptionChange = (option) => {
    setSortOption(option);
    setIsSortDropdownOpen(false); // Close dropdown after selection
  };

  const handleClearFilter = () => {
    setProductKeyword('');
    setSortOption('');
  };

  return (
    <div className="main-admin-products-list-wrapper">
      <div className="products-list-wrapper">
        <div className="products-wrapper-admin">
          <div className="plus-icon-btn-wrapper">
            <div className="product-filter-wrapper">
              <div className="left-side-search">
                <input
                  onChange={handleSearchChange}
                  type="search"
                  placeholder="Search for products..."
                />
                <div className="sort-products-admin-wrapper ">
                  <p onClick={toggleSortDropdown} className="sort-toggle">
                    Sort By{' '}
                    <img
                      className="drop-down-icon"
                      src={dropdownArrowIcon}
                      alt="Sort Arrow"
                    />
                  </p>

                  {isSortDropdownOpen && (
                    <div className="sort-dropdown-for-products">
                      <button
                        onClick={() => handleSortOptionChange('low-to-high')}
                      >
                        Price: Low to High
                      </button>
                      <button
                        onClick={() => handleSortOptionChange('high-to-low')}
                      >
                        Price: High to Low
                      </button>
                      <button
                        onClick={() => handleSortOptionChange('low-stock')}
                      >
                        Stock: Low to High
                      </button>
                      <button
                        onClick={() => handleSortOptionChange('high-stock')}
                      >
                        Stock: High to Low
                      </button>
                    </div>
                  )}
                  <button
                    onClick={handleClearFilter}
                    className="clear-filter-button"
                  >
                    Clear Filter
                  </button>
                </div>
              </div>

              <div>
                <button
                  className="add-product-admin-btn"
                  onClick={handleAddBtnClick}
                >
                  <img className="add-new-product-icon" src={addIcon} />
                </button>
              </div>
            </div>
          </div>
          <h3>Products</h3>
          {filteredProducts.length === 0 && (
            <p>No products found for "{productKeyword}"</p>
          )}

          {filteredProducts.map((p) => {
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

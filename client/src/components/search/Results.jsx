import { useContext, useEffect, useState } from 'react';
import SearchContext from '../context/SearchContextComp';
import { getAllProducts } from '../../managers/productManager';
import './Results.css';
import { ProductDetails } from '../products/ProductDetails';
import { useCart } from '../context/useCart';
import viewProductIcon from '../../assets/view.png';
import addToCartIcon from '../../assets/cartAdd.png';
import dropdownArrowIcon from '../../assets/dropdown.png';
import { getAllCategories } from '../../managers/categoryManager';

export const Results = () => {
  const [products, setProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [isProductDetailsOpen, setIsProductDetailsOpen] = useState(false);
  const [selectedProductId, setSelectedProductId] = useState(null);
  const [isSortDropdownOpen, setIsSortDropdownOpen] = useState(false);
  const [sortOption, setSortOption] = useState('');
  const [filteredProducts, setFilteredProducts] = useState([]);

  const { keyword } = useContext(SearchContext);
  const { addItemToCart } = useCart();

  useEffect(() => {
    getAllProducts().then((data) => setProducts(data));
  }, []);

  useEffect(() => {
    getAllCategories().then((data) => setCategories(data));
  }, []);

  useEffect(() => {
    if (selectedCategory) {
      getAllProducts(selectedCategory).then((data) => setProducts(data));
    } else {
      getAllProducts().then((data) => setProducts(data));
    }
  }, [selectedCategory]);

  useEffect(() => {
    let updatedProducts = products;

    // Filter by keyword
    if (keyword) {
      updatedProducts = updatedProducts.filter(
        (product) =>
          product.name &&
          product.name.toLowerCase().includes(keyword.toLowerCase())
      );
    }

    // Sort products based on the selected sort option
    if (sortOption === 'low-to-high') {
      updatedProducts = [...updatedProducts].sort((a, b) => a.price - b.price);
    } else if (sortOption === 'high-to-low') {
      updatedProducts = [...updatedProducts].sort((a, b) => b.price - a.price);
    }

    setFilteredProducts(updatedProducts);
  }, [keyword, sortOption, products]);

  const handleProductDetailsToggle = (productId) => {
    setIsProductDetailsOpen((prev) => !prev);
    setSelectedProductId(productId);
  };

  const handleCloseProductDetailModal = () => {
    setIsProductDetailsOpen(false);
    setSelectedProductId(null);
  };

  const handleCategoryChange = (e) => {
    setSelectedCategory(parseInt(e.target.value));
  };

  const toggleSortDropdown = () => {
    setIsSortDropdownOpen((prev) => !prev);
  };

  const handleSortOptionChange = (option) => {
    setSortOption(option);
    setIsSortDropdownOpen(false); // Close dropdown after selection
  };

  const handleClearFilterClick = () => {
    setSelectedCategory(null);
    setSortOption('products');
  };

  return (
    <>
      <div className="results-wrapper">
        <div className="category-filter-wrapper">
          <h3>Categories</h3>
          {categories.map((category) => {
            return (
              <div key={category.id} className="category-filters">
                <label key={category.id}>{category.name}</label>
                <input
                  type="radio"
                  name="category"
                  value={category.id}
                  checked={selectedCategory === category.id}
                  onChange={handleCategoryChange}
                />
              </div>
            );
          })}
          <div className="clear-filter-btn-wrapper">
            <button onClick={handleClearFilterClick}>Clear Filter</button>
          </div>
        </div>
        <div className="sort-and-products-wrapper">
          {keyword && <p>Results for "{keyword}"</p>}
          <div className="sort-items-wrapper">
            <p onClick={toggleSortDropdown} className="sort-toggle">
              Sort By{' '}
              <img
                className="drop-down-icon"
                src={dropdownArrowIcon}
                alt="Sort Arrow"
              />
            </p>
            {isSortDropdownOpen && (
              <div className="sort-dropdown">
                <button onClick={() => handleSortOptionChange('low-to-high')}>
                  Price: Low to High
                </button>
                <button onClick={() => handleSortOptionChange('high-to-low')}>
                  Price: High to Low
                </button>
              </div>
            )}
          </div>
          <div className="results-products-wrapper">
            {filteredProducts.map((product) => (
              <div className="result-product-card" key={product.id}>
                <h4>{product.name}</h4>
                <img src={product.imageUrl} alt={product.name} />
                <p>${product.price.toFixed(2)}</p>
                <div className="feature-product-button-wrapper">
                  <button
                    className="view-btn"
                    onClick={() => handleProductDetailsToggle(product.id)}
                  >
                    <img
                      className="view-item-icon"
                      src={viewProductIcon}
                      alt="view icon"
                    />
                  </button>
                  <button
                    className="add-to-cart-btn"
                    onClick={() => addItemToCart(product)}
                  >
                    <img
                      className="add-item-icon"
                      src={addToCartIcon}
                      alt="add item to cart icon"
                    />
                  </button>
                </div>
              </div>
            ))}
            {filteredProducts.length < 1 && (
              <p>No results found for "{keyword}"</p>
            )}
          </div>
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
      </div>
    </>
  );
};

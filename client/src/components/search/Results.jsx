import { useContext, useEffect, useState } from 'react';
import SearchContext from '../context/SearchContextComp';
import { getAllProducts } from '../../managers/productManager';
import './Results.css';
import { ProductDetails } from '../products/ProductDetails';
import { useCart } from '../context/useCart';

export const Results = () => {
  const [products, setProducts] = useState([]);
  const [isProductDetailsOpen, setIsProductDetailsOpen] = useState(false);
  const [selectedProductId, setSelectedProductId] = useState(null);

  const { keyword } = useContext(SearchContext);
  const { addItemToCart } = useCart();

  useEffect(() => {
    getAllProducts().then((data) => setProducts(data));
  }, []);

  const filteredProducts = keyword
    ? products.filter(
        (product) =>
          product.name &&
          product.name.toLowerCase().includes(keyword.toLowerCase())
      )
    : products; // Show all products if no keyword

  const handleProductDetailsToggle = (productId) => {
    setIsProductDetailsOpen((prev) => !prev);
    setSelectedProductId(productId);
  };

  const handleCloseProductDetailModal = () => {
    setIsProductDetailsOpen(false);
    setSelectedProductId(null);
  };

  return (
    <>
      {keyword && <p>Results for "{keyword}"</p>}
      <div className="results-products-wrapper">
        {filteredProducts.map((product) => (
          <div className="result-product-card" key={product.id}>
            <h4>{product.name}</h4>
            <img src={product.imageUrl} alt={product.name} />
            <p>${product.price.toFixed(2)}</p>
            <div className="feature-product-button-wrapper">
              <button onClick={() => handleProductDetailsToggle(product.id)}>
                View
              </button>
              <button onClick={() => addItemToCart(product)}>
                Add to cart
              </button>
            </div>
          </div>
        ))}
        {filteredProducts.length < 1 && <p>No results found for "{keyword}"</p>}
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
    </>
  );
};

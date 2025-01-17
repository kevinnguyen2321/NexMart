import { useContext, useEffect, useState } from 'react';
import SearchContext from '../context/SearchContextComp';
import { getAllProducts } from '../../managers/productManager';
import './Results.css';

export const Results = () => {
  const [products, setProducts] = useState([]);

  const { keyword } = useContext(SearchContext);

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
              <button>View</button>
              <button>Add to cart</button>
            </div>
          </div>
        ))}
      </div>
    </>
  );
};

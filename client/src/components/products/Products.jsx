import { useEffect, useState } from 'react';
import { getAllProducts } from '../../managers/productManager';
import './Products.css';

export const Products = () => {
  const [products, setProducts] = useState([]);
  const [featuredProducts, setFeaturedProducts] = useState([]);

  useEffect(() => {
    getAllProducts().then((data) => {
      setProducts(data);
      setFeaturedProducts(selectRandomProducts(data, 8));
    });
  }, []);

  // Function to select random products
  const selectRandomProducts = (products, count) => {
    const shuffled = [...products].sort(() => 0.5 - Math.random()); // Shuffle array
    return shuffled.slice(0, count); // Select first `count` items
  };
  // Giving each featured product dummy image (placeholder)//
  featuredProducts.forEach((fp) => {
    fp.imageUrl = 'https://dummyimage.com/300x200/000/fff&text=Hello';
  });

  return (
    <div className="products-wrapper">
      <div>
        <h2>Featured Items</h2>
        <div className="featured-products">
          {featuredProducts.map((product) => (
            <div className="product-card" key={product.id}>
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
      </div>
    </div>
  );
};

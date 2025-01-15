import { useEffect, useState } from 'react';
import { getAllProducts } from '../../managers/productManager';
import './Products.css';
import { ProductDetails } from './ProductDetails';
import { useCart } from '../context/useCart';

export const Products = ({ selectedCategoryId, loggedInUser }) => {
  const [products, setProducts] = useState([]);
  const [featuredProducts, setFeaturedProducts] = useState([]);
  const [selectedProductId, setSelectedProductId] = useState(null);
  const [isProductDetailsOpen, setIsProductDetailsOpen] = useState(false);

  const { addItemToCart } = useCart();

  useEffect(() => {
    getAllProducts().then((data) => {
      setProducts(data);
      setFeaturedProducts(selectRandomProducts(data, 8));
    });
  }, []);

  useEffect(() => {
    if (selectedCategoryId) {
      getAllProducts(selectedCategoryId).then((data) =>
        setFeaturedProducts(data)
      );
    }
  }, [selectedCategoryId]);

  // Function to select random products
  const selectRandomProducts = (products, count) => {
    const shuffled = [...products].sort(() => 0.5 - Math.random()); // Shuffle array
    return shuffled.slice(0, count); // Select first `count` items
  };
  // Giving each featured product dummy image (placeholder)//
  featuredProducts.forEach((fp) => {
    fp.imageUrl = `https://dummyimage.com/300x200/000/fff&text=${fp.name}`;
  });

  const handleViewBtnClick = (productId) => {
    setIsProductDetailsOpen((prev) => !prev);
    setSelectedProductId(productId);
  };

  const handleCloseProductDetailModal = () => {
    setIsProductDetailsOpen(false);
    setSelectedProductId(null);
  };

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
                <button onClick={() => handleViewBtnClick(product.id)}>
                  View
                </button>
                <button onClick={() => addItemToCart(product)}>
                  Add to cart
                </button>
              </div>
            </div>
          ))}
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
  );
};

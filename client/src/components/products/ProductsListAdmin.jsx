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
        <button onClick={handleAddBtnClick}>Add new product</button>
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

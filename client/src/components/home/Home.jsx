import { useState } from 'react';
import { Categories } from '../categories/Categories';
import { Products } from '../products/Products';

export const Home = ({ loggedInUser }) => {
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);

  const handleCategoryClick = (categoryId) => {
    setSelectedCategoryId(categoryId);
  };
  return (
    <div>
      <Categories
        selectedCategoryId={selectedCategoryId}
        handleCategoryClick={handleCategoryClick}
      />
      <Products
        loggedInUser={loggedInUser}
        selectedCategoryId={selectedCategoryId}
      />
    </div>
  );
};

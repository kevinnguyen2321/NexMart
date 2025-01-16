import { useEffect, useState } from 'react';
import { getAllCategories } from '../../managers/categoryManager';
import './CategoryListAdmin.css';
import { NewCategoryForm } from './NewCategoryForm';

export const CategoryListAdmin = () => {
  const [categories, setCategories] = useState([]);
  const [isNewCategoryFormOpen, setIsNewCategoryFormOpen] = useState(false);

  const getAndSetAllCategories = () => {
    getAllCategories().then((data) => setCategories(data));
  };

  useEffect(() => {
    getAndSetAllCategories();
  }, []);

  const handleAddBtnClick = () => {
    setIsNewCategoryFormOpen(true);
  };

  const handleCloseModal = () => {
    setIsNewCategoryFormOpen(false);
  };

  return (
    <>
      <div className="category-list-wrapper">
        <h2>Categories</h2>
        <button onClick={handleAddBtnClick}>Add Category</button>
        {categories.map((c) => {
          return (
            <div className="category-list-card" key={c.id}>
              <p>{c.name}</p>
              <button>Edit</button>
              <button>Delete</button>
            </div>
          );
        })}
      </div>

      {isNewCategoryFormOpen && (
        <div>
          <NewCategoryForm
            isNewCategoryFormOpen={isNewCategoryFormOpen}
            onClose={handleCloseModal}
            getAndSetAllCategories={getAndSetAllCategories}
          />
        </div>
      )}
    </>
  );
};

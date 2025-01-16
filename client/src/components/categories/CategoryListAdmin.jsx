import { useEffect, useState } from 'react';
import { getAllCategories } from '../../managers/categoryManager';
import './CategoryListAdmin.css';
import { NewCategoryForm } from './NewCategoryForm';
import { EditCategoryForm } from './EditCategoryForm';

export const CategoryListAdmin = () => {
  const [categories, setCategories] = useState([]);
  const [isNewCategoryFormOpen, setIsNewCategoryFormOpen] = useState(false);
  const [isEditCategoryFormOpen, setIsEditCategoryFormOpen] = useState(false);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);

  const getAndSetAllCategories = () => {
    getAllCategories().then((data) => setCategories(data));
  };

  useEffect(() => {
    getAndSetAllCategories();
  }, []);

  const handleAddBtnClick = () => {
    setIsNewCategoryFormOpen(true);
  };

  const handleEditBtnClick = (id) => {
    setSelectedCategoryId(id);
    setIsEditCategoryFormOpen(true);
  };

  const handleCloseModal = () => {
    setIsNewCategoryFormOpen(false);
  };

  const handleCloseEditModal = () => {
    setIsEditCategoryFormOpen(false);
  };

  return (
    <>
      <div className="category-list-wrapper">
        <button onClick={handleAddBtnClick}>Add Category</button>
        <h2>Categories</h2>

        {categories.map((c) => {
          return (
            <div className="category-list-card" key={c.id}>
              <p>{c.name}</p>
              <button onClick={() => handleEditBtnClick(c.id)}>Edit</button>
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

      {isEditCategoryFormOpen && (
        <div>
          <EditCategoryForm
            isEditCategoryFormOpen={isEditCategoryFormOpen}
            onClose={handleCloseEditModal}
            getAndSetAllCategories={getAndSetAllCategories}
            selectedCategoryId={selectedCategoryId}
          />
        </div>
      )}
    </>
  );
};

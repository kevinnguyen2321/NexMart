import { useEffect, useState } from 'react';
import {
  deleteCategory,
  getAllCategories,
} from '../../managers/categoryManager';
import './CategoryListAdmin.css';
import { NewCategoryForm } from './NewCategoryForm';
import { EditCategoryForm } from './EditCategoryForm';
import addIcon from '../../assets/add.png';
import editIcon from '../../assets/edit.png';
import deleteIcon from '../../assets/delete.png';

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

  const handleDeleteBtnClick = (category) => {
    const userConfirmed = window.confirm(
      `Are you sure you want to delete the category ${category.name}?`
    );

    if (userConfirmed) {
      deleteCategory(category.id).then(() => getAndSetAllCategories());
    }
  };

  return (
    <>
      <div className="category-list-wrapper">
        <button className="add-new-category-btn" onClick={handleAddBtnClick}>
          <img className="add-new-category-icon" src={addIcon} alt="add icon" />
        </button>
        <h2>Categories</h2>

        {categories.map((c) => {
          return (
            <div className="category-list-card" key={c.id}>
              <p>
                {c.id} .{c.name}
              </p>
              <button
                className="edit-category-btn"
                onClick={() => handleEditBtnClick(c.id)}
              >
                <img src={editIcon} className="edit-category-icon" />
              </button>
              <button
                className="delete-category-btn"
                onClick={() => handleDeleteBtnClick(c)}
              >
                <img className="delete-category-icon" src={deleteIcon} />
              </button>
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

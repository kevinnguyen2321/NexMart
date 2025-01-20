import { useState } from 'react';
import './NewCategoryForm.css';
import { addNewCategory } from '../../managers/categoryManager';
import closeIcon from '../../assets/close.png';

export const NewCategoryForm = ({
  isNewCategoryFormOpen,
  onClose,
  getAndSetAllCategories,
}) => {
  const [newCategory, setNewCategory] = useState({});

  const handleOnChange = (e) => {
    const copyObj = { ...newCategory };
    copyObj[e.target.name] = e.target.value;

    setNewCategory(copyObj);
  };

  const handleSubmitBtnClick = (e) => {
    e.preventDefault();
    if (!newCategory.name) {
      alert('Please enter a name');
    } else {
      addNewCategory(newCategory).then(() => {
        onClose();
        getAndSetAllCategories();
      });
    }
  };
  return (
    <div className={`category-modal ${isNewCategoryFormOpen ? 'open' : ''}`}>
      <div className="category-modal-content">
        <div className="close-category-modal-wrapper">
          <button
            className="close-add-new-category-btn"
            type="button"
            onClick={onClose}
          >
            <img className="close-category-modal-icon" src={closeIcon} />
          </button>
        </div>
        <h2>Add New Category</h2>
        <form>
          <label>
            Name:
            <input onChange={handleOnChange} type="text" name="name" />
          </label>

          <div className="category-modal-actions">
            <button
              className="submit-new-category-btn"
              onClick={handleSubmitBtnClick}
              type="submit"
            >
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

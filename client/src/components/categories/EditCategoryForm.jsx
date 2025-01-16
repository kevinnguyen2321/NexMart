import { useEffect, useState } from 'react';
import { editCategory, getCategoryById } from '../../managers/categoryManager';

export const EditCategoryForm = ({
  isEditCategoryFormOpen,
  onClose,
  getAndSetAllCategories,
  selectedCategoryId,
}) => {
  const [category, setCategory] = useState({});

  useEffect(() => {
    getCategoryById(selectedCategoryId).then((data) => setCategory(data));
  }, [selectedCategoryId]);

  const handleOnChange = (e) => {
    const copyObj = { ...category };
    copyObj[e.target.name] = e.target.value;

    setCategory(copyObj);
  };

  const handleSaveBtnClick = (e) => {
    e.preventDefault();
    if (!category.name) {
      alert('Please enter a name');
    } else {
      editCategory(selectedCategoryId, category).then(() => {
        onClose();
        getAndSetAllCategories();
      });
    }
  };

  return (
    <div className={`category-modal ${isEditCategoryFormOpen ? 'open' : ''}`}>
      <div className="category-modal-content">
        <h2>Edit Category</h2>
        <form>
          <label>
            Name:
            <input
              onChange={handleOnChange}
              type="text"
              name="name"
              value={category.name ? category.name : ''}
            />
          </label>

          <div className="category-modal-actions">
            <button type="button" onClick={onClose}>
              Close
            </button>
            <button onClick={handleSaveBtnClick} type="submit">
              Save
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

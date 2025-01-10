import { useEffect, useState } from 'react';
import { getAllCategories } from '../../managers/categoryManager';
import './Categories.css';

export const Categories = ({ selectedCategoryId, handleCategoryClick }) => {
  const [categories, setCategories] = useState([]);
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);

  useEffect(() => {
    getAllCategories().then((data) => setCategories(data));
  }, []);

  const handleCategoryClickAndClose = (categoryId) => {
    handleCategoryClick(categoryId); // Trigger parent function
    setIsDropdownOpen(false); // Close the dropdown
  };

  const toggleDropdown = () => {
    setIsDropdownOpen((prev) => !prev);
  };

  return (
    <div className="category-wrapper">
      <div className="category-dropdown">
        <p onClick={toggleDropdown}>Categories</p>
        {isDropdownOpen && (
          <div className="category-dropdown-menu">
            <ul>
              {categories.map((c) => (
                <li
                  key={c.id}
                  onClick={() => handleCategoryClickAndClose(c.id)}
                >
                  {c.name}
                </li>
              ))}
            </ul>
          </div>
        )}
      </div>
      <div className="display-categories-wrapper">
        <ul>
          {categories.slice(0, 6).map((c) => {
            return (
              <li key={c.id} onClick={() => handleCategoryClickAndClose(c.id)}>
                {c.name}
              </li>
            );
          })}
        </ul>
      </div>
    </div>
  );
};

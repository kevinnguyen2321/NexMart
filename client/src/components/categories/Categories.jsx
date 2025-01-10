import { useEffect, useState } from 'react';
import { getAllCategories } from '../../managers/categoryManager';
import './Categories.css';

export const Categories = () => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    getAllCategories().then((data) => setCategories(data));
  }, []);

  return (
    <div className="category-wrapper">
      <div>
        <p>Categories</p>
      </div>
      <div className="display-categories-wrapper">
        <ul>
          {categories.slice(0, 6).map((c) => {
            return <li>{c.name}</li>;
          })}
        </ul>
      </div>
    </div>
  );
};

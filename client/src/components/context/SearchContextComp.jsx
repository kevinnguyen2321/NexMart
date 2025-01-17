import { createContext, useState } from 'react';

const SearchContext = createContext();

export const SearchContextComp = ({ children }) => {
  const [keyword, setKeyword] = useState(null);

  const handleUserSearchTypeOnChange = (e) => {
    setKeyword(e.target.value);
  };

  return (
    <SearchContext.Provider value={{ keyword, handleUserSearchTypeOnChange }}>
      {children}
    </SearchContext.Provider>
  );
};

export default SearchContext;

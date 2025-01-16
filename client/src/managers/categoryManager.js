const _apiUrl = '/api/category';

export const getAllCategories = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getCategoryById = (categoryId) => {
  return fetch(`${_apiUrl}/${categoryId}`).then((res) => res.json());
};

export const addNewCategory = (category) => {
  return fetch(_apiUrl, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(category),
  }).then((res) => res.json());
};

export const editCategory = (categoryId, category) => {
  return fetch(`${_apiUrl}/${categoryId}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(category),
  });
};

export const deleteCategory = (categoryId) => {
  return fetch(`${_apiUrl}/${categoryId}`, {
    method: 'DELETE',
  }).then((response) => {
    if (!response.ok) {
      throw new Error('Failed to delete category');
    } else {
      return { success: true, message: 'Category deleted successfully' };
    }
  });
};

const _apiUrl = '/api/product';

export const getAllProducts = (categoryId) => {
  const url = categoryId ? `${_apiUrl}?categoryId=${categoryId}` : _apiUrl;

  return fetch(url).then((res) => res.json());
};

export const getProductById = (productId) => {
  return fetch(`${_apiUrl}/${productId}`).then((res) => res.json());
};

export const addNewProduct = (product) => {
  return fetch(_apiUrl, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(product),
  }).then((res) => res.json());
};

export const editProduct = (productId, product) => {
  return fetch(`${_apiUrl}/${productId}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(product),
  });
};

export const deleteProduct = (productId) => {
  return fetch(`${_apiUrl}/${productId}`, {
    method: 'DELETE',
  }).then((response) => {
    if (!response.ok) {
      throw new Error('Failed to delete product');
    } else {
      return { success: true, message: 'Product deleted successfully' };
    }
  });
};

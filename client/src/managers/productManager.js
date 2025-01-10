const _apiUrl = '/api/product';

export const getAllProducts = (categoryId) => {
  const url = categoryId ? `${_apiUrl}?categoryId=${categoryId}` : _apiUrl;

  return fetch(url).then((res) => res.json());
};

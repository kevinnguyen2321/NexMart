const _apiUrl = '/api/order';

export const getAllOrders = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getOrderById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

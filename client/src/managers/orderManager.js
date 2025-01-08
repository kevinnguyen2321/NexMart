const _apiUrl = '/api/order';

export const getAllOrders = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

const _apiUrl = '/api/order';

export const getAllOrders = (userProfileId) => {
  const url = userProfileId
    ? `${_apiUrl}?userProfileId=${userProfileId}`
    : _apiUrl;
  return fetch(url).then((res) => res.json());
};

export const getOrderById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const cancelOrder = (orderId) => {
  return fetch(`${_apiUrl}/${orderId}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
  });
};

export const placeOrder = (order) => {
  return fetch(_apiUrl, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(order),
  }).then((res) => res.json());
};

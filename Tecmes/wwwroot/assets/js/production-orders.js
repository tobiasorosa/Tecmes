import { apiGet } from './api';

async function loadProductionOrders() {
  try {
    const response = await apiGet('/api/production-orders');
  } catch (err) {
      console.log(err);
  }
}

// Function to get the JWT token from localStorage
function getJwtToken() {
  return localStorage.getItem('jwtToken');
}

// Function to make authenticated API calls
export async function apiGet(endpoint) {
  const jwtToken = getJwtToken();

  // Set the token in the request headers
  axios.defaults.headers.common.Authorization = `Bearer ${jwtToken}`;

  // Now you can make API calls with authentication
  try {
    const response = await axios.get(`/api/${endpoint}`);
    return response.data;
  } catch (error) {
    // Handle any error that occurred during the API call
    console.error('Error:', error);
    return error;
  }
}

export async function apiPost(endpoint, body) {
  const jwtToken = getJwtToken();

  // Set the token in the request headers
  axios.defaults.headers.common.Authorization = `Bearer ${jwtToken}`;

  // Now you can make API calls with authentication
  try {
    const response = await axios.post(`/api/${endpoint}`, body);
    return response.data;
  } catch (error) {
    // Handle any error that occurred during the API call
    console.error('Error:', error);
    return error;
  }
}

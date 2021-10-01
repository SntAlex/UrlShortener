export const getResponseErrorMessage = (error) => {
    try {
        error.message = error.response.data.message + ' Status code: ' + error.response.data.statusCode;
    } finally {
        return error.message;
    }
};
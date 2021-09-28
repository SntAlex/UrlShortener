import React from 'react';

const ErrorPage = ({error}) => {
    return (
        <h1>
           Error!
            {error}
        </h1>
    );
};

export default ErrorPage;
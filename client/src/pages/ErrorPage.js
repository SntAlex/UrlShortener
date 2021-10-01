import React from 'react';
import ErrorMessage from "../components/UI/ErrorMessage/ErrorMessage";

const ErrorPage = () => {
    return (
        <div className='page'>
            <ErrorMessage error={'Something went wrong!'}/>
        </div>
    );
};

export default ErrorPage;
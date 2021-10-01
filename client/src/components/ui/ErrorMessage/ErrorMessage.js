const ErrorMessage = ({error, ...props}) => {
    return (
        <h4 {...props}>
            {error}
        </h4>
    );
};

export default ErrorMessage;
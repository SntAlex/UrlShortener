import classes from "./ErrorMessage.module.css";

const ErrorMessage = ({error, ...props}) => {
    return (
        <h4 className={classes.errorMessage} {...props}>
            {error}
        </h4>
    );
};

export default ErrorMessage;
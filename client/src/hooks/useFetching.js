import {useState} from "react";
import {getResponseErrorMessage} from "../utils/ErrorMessageUtils";

export const useFetching = (callback) => {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');

    const fetching = async (...args) => {
        try {
            setIsLoading(true);
            setError('');
            await callback(...args);
        } catch (error) {
            setError(getResponseErrorMessage(error))
        } finally {
            setIsLoading(false);
        }
    };

    return [fetching, isLoading, error]
}
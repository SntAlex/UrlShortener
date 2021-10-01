import axios from "axios";

export default class UrlMinificationService {
    static async createShortUrl(input){
        return await axios.post('https://localhost:8001/api/v1/UrlShortener', {url: input});
    }

    static async getOriginalUrl(){
        const shortUrlPath = (window.location.pathname).replace('/', '');
        return await axios.get("https://localhost:8001/api/v1/UrlShortener/shortUrl", {
            params: {
                ShortUrlPath: shortUrlPath
            }
        });
    }
}
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./components/AppRouter/AppRouter";
import './App.css';
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";

const App = () => {
    return (
        <BrowserRouter>
            <Header/>
            <AppRouter/>
            <Footer/>
        </BrowserRouter>
    );
};

export default App;
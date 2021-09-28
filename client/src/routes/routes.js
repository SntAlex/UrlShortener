import RedirectPage from "../pages/RedirectPage";
import HomePage from "../pages/HomePage";

export const routes = [
    {path: '/', component: HomePage, exact: true},
    {path: '/', component: RedirectPage, exact: false}
];
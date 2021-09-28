import RedirectPage from "../pages/RedirectPage";
import HomePage from "../pages/HomePage";
import ErrorPage from "../pages/ErrorPage";

export const routes = [
    {path: '/', component: HomePage, exact: true},
    {path: '/error', component: ErrorPage, exact: true},
    {path: '/', component: RedirectPage, exact: false}
];
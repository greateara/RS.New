import { makeAutoObservable, runInAction } from "mobx";
import { User, UserFormValues } from "../models/User";
import agent from "../api/Agent";
import { Store } from "./Store";
import { Router } from "../router/Routes";

export default class UserStore {
    user: User | null = null;
    constructor() { makeAutoObservable(this) }
    get IsLoggedIn() { return !!this.user; }
    login = async (creds : UserFormValues) => {
        try {
            const user = await agent.Account.login(creds);
            Store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            Router.navigate('/Stay');
            // console.log(user);      
            Store.modalStore.closeModal();      
        } catch (error) {
            throw error;
        }
    }

    register = async (creds : UserFormValues) => {
        try {
            const user = await agent.Account.register(creds);
            Store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            Router.navigate('/Stay');
            // console.log(user);      
            Store.modalStore.closeModal();      
        } catch (error) {
            // console.log(error);      
            throw error;

        }
    }

    logout = () => {
        Store.commonStore.setToken(null);
        // localStorage.removeItem('jwt');
        this.user = null;
        Router.navigate('/');
    }

    getUser = async () => {
        try {
            const user = await agent.Account.current();
            runInAction(() => this.user = user);
        } catch (error) {
            console.log(error);
        }
    }
}
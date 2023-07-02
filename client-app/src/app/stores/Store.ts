import {createContext, useContext} from 'react'
import OrgTypeStore from "./OrgTypeStore";
import CommonStore from './CommonStore';
import UserStore from './UserStore';
import ModalStore from './ModalStore';
import AgamaStore from './AgamaStore';
    

interface Store {
    agamaStore: AgamaStore;
    orgTypeStore: OrgTypeStore;
    commonStore : CommonStore;
    userStore : UserStore;
    modalStore : ModalStore;
}

export const Store: Store = {
    agamaStore : new AgamaStore(),
    orgTypeStore: new OrgTypeStore(),
    commonStore : new CommonStore(),
    userStore : new UserStore(),
    modalStore : new ModalStore(),
}

export const StoreContext = createContext(Store);

export function useStore() {
    return useContext(StoreContext);
}
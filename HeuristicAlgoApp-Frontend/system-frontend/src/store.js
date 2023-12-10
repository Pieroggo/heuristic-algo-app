import { createContext, useContext } from "react";
import AppStore from "./AppStore";

// interfejs
// interface Store{
//     appStore: AppStore
// }

// obiekt typu Store z inicjalizacją 
export const store = {
    appStore: new AppStore()
}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext)
}


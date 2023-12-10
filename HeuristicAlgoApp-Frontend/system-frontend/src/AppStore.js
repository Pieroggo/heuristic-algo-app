import { makeAutoObservable } from "mobx";
import axios from "axios";

export default class AppStore {

    //apiPath = "https://localhost:7188/";
    apiPath = 'https://jsonplaceholder.typicode.com/';
    algorithms = [];

    constructor() {
        makeAutoObservable(this);
    }




}
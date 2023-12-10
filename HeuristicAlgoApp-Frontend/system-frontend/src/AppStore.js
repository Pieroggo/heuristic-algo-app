import { makeAutoObservable } from "mobx";
import axios from "axios";

export default class AppStore {

    //apiPath = 'https://jsonplaceholder.typicode.com/';
    apiPath = 'https://localhost:7071/api';

    algorithms = [];
    functions = [];

    constructor() {
        makeAutoObservable(this);
    }




}
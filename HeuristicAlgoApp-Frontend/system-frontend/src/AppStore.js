import { makeAutoObservable } from "mobx";
import axios from "axios";

export default class AppStore {

    constructor() {
        makeAutoObservable(this);
    }

    //apiPath = 'https://jsonplaceholder.typicode.com/';
    apiPath = 'https://localhost:7071/api';

    algorithms = [];
    functions = [];
    file = "";

    setAlgorithms = (data) => {
        this.algorithms = data;
    }

    setFunctions = (data) => {
        this.functions = data;
    }

    handleFileChange = (event) => {
        
        console.log("> Zmieniam plik");
        
        if (event.target.files && event.target.files.length > 0) {
            const selectedFile = event.target.files[0];
            this.file = selectedFile;
        }
        
        console.log(this.file);
    };

    handleUpload = async (event) => {

        if (this.file) {
            console.log("> Uploaduje plik");
            const formData = new FormData();
            formData.append('file', this.file);
            try {
                const response = await axios.post(this.apiPath + '/Upload/Add', formData);
                console.log('Plik przesłany pomyślnie', response);
                alert("Plik wysłany")
            } catch (error) {
                console.error('Błąd podczas przesyłania pliku', error);
            }
        }
        else {
            console.log("Brak pliku do przesłania")
        }
        
        this.file = ""
        console.log("Czyszcze input")
        document.getElementById("fileUpload").value = ""
    }



}
import { action, makeAutoObservable, runInAction } from "mobx";
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

    przerwanoSingleTask = false;
    przerwanoMultiTask = false;

    // TO DO break functionality

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

    // FUNCTION get func of id

    getFunctionById = (id) => {
        let f = this.functions.filter((f) => {return f.id == id})[0]
        console.log("> Wybieram funkcje: ", f.id, " : ", f.name)
        return f
    }


    // PARAMETERS changing

    // setFuntionDimension = (id, dim) => {
    //     this.getFunctionById(id).dimension = dim
    // }

    setFuntionDimension = (id, dim) => {
        runInAction(() => {
            this.getFunctionById(id).dimension = dim
        })
    }

    handleFuncDimChange = (e, id) => {
        
        // zmiejszamy
        if(this.getFunctionById(id).dimension > e.target.value){
            this.getFunctionById(id).lowerBoundaries.pop()
        }
        if(this.getFunctionById(id).dimension > e.target.value){
            this.getFunctionById(id).upperBoundaries.pop()
        }
        
        // zwiekszamy
        if(this.getFunctionById(id).dimension < e.target.value){
            this.getFunctionById(id).lowerBoundaries.push(0)
        }
        if(this.getFunctionById(id).dimension < e.target.value){
            this.getFunctionById(id).upperBoundaries.push(0)
        }

        this.setFuntionDimension(id, e.target.value)
    }
    
    handleFuncLowBoundChange = (e, dim, id) => {
        id = id-1
        this.functions[id].lowerBoundaries[dim] = e.target.value
    }

    // TASKs

    runSinlgeTask = async () => {

        console.log("> Uruchamiam SINGLE TASK")

        let algoID = document.querySelector('input[name="algo-one"]:checked')
        if (algoID) {
            console.log("Wybrany algorytm: ", algoID.value)
        }
        else {
            console.log("Nie wybrano algorytmu")
        }

        let funcIDs = []
        let checkboxes = document.querySelectorAll('input[name="func-many"]:checked')
        if (checkboxes.length > 0) {
            checkboxes.forEach((checkbox) => {
                funcIDs.push(checkbox.value)
            })
            console.log("Wybrane funkcje: ", funcIDs)
        }
        else {
            console.log("Nie wybrano funkcjów")
        }

        console.log("Czyszcze inputy")
        if (algoID) { algoID.checked = false }
        if (checkboxes.length > 0) {
            checkboxes.forEach((checkbox) => {
                checkbox.checked = false
            })
        }

    }

    algoIDs = []

    handleAlgoIDsChange = () => {
        this.algoIDs = []
        console.log("> algoIDs change")
        let checkboxes = document.querySelectorAll('input[name="algo-many"]:checked')
        if (checkboxes.length > 0) {
            checkboxes.forEach((checkbox) => {
                this.algoIDs.push(checkbox.value)
            })
        }
    }
    
    funcID = null
    
    handleFuncIDChange = () => {
        console.log("> funcID change")
        document.querySelector('input[name="func-one"]:checked')
            ?
            this.funcID = document.querySelector('input[name="func-one"]:checked').value
            :
            this.funcID = null
    }

    runMultiTask = async () => {

        console.log("> Uruchamiam MULTI TASK")

        if (this.algoIDs.length > 0) {
            console.log("Wybrane algosy: ")
            this.algoIDs.forEach((id) => {
                console.log(id)
            })
        }
        else {
            console.log("Nie wybrano algorytmów")
        }

        if (this.funcID) {
            console.log("Wybrana funkcja: ", this.funcID)
        }
        else {
            console.log("Nie wybrano funkcji")
        }

        // let algoIDs = []
        // let checkboxes = document.querySelectorAll('input[name="algo-many"]:checked')
        // if (checkboxes.length > 0) {
        //     checkboxes.forEach((checkbox) => {
        //         algoIDs.push(checkbox.value)
        //     })
        //     console.log("Wybrane algosy: ", algoIDs)
        // }
        // else {
        //     console.log("Nie wybrano algorytmów")
        // }

        // let funcID = document.querySelector('input[name="func-one"]:checked')

        // if (funcID) {
        //     console.log("Wybrana funckja: ", funcID.value)
        // }
        // else {
        //     console.log("Nie wybrano funkcji")
        // }




        console.log("Czyszcze inputy")
        let checkboxes = document.querySelectorAll('input[name="algo-many"]:checked')
        if (checkboxes.length > 0) {
            checkboxes.forEach((checkbox) => {
                checkbox.checked = false
            })
            this.algoIDs = []
        }
        if (this.funcID) {
            document.querySelector('input[name="func-one"]:checked').checked = false
            this.funcID = null
        }

    }



}
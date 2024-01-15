import { action, makeAutoObservable, runInAction } from "mobx";
import axios from "axios";

export default class AppStore {

    constructor() {
        makeAutoObservable(this);
    }

    //apiPath = 'https://jsonplaceholder.typicode.com/';
    apiPath = 'https://localhost:7071/api';

    // SHOW VALUES function to better see values of states when using mobx

    show = (what) => {
        // console.log("> Showing variable values")
        what.map((item) => {
            return console.log(item);
        })
    }

    // FUNCTIONS & ALGORITHMS

    // wczytanie i ustawienie

    algorithms = [];
    functions = [];

    functionsForSingle = []
    algorithmsForSingle = []

    functionsForMulti = []
    algorithmsForMulti = []

    setAlgorithms = (data) => {
        this.algorithms = data;
    }

    setFunctions = (data) => {
        this.functions = data;
    }

    setAllAlgorithms = (data) => {
        this.algorithmsForSingle = data;
        this.algorithmsForMulti = data;
    }

    setAllFunctions = (data) => {
        this.functionsForSingle = data;
        this.functionsForMulti = data;
    }

    // GET BY ID

    // get func of id

    getFunctionById = (singleOrMulti, id) => {
        if (singleOrMulti === "single") {
            let f = this.functionsForSingle.filter((f) => { return f.id == id })[0]
            // console.log("> Wybieram functionsForSingle: ", f.id, " : ", f.name)
            return f
        }
        else if (singleOrMulti === "multi") {
            let f = this.functionsForMulti.filter((f) => { return f.id == id })[0]
            // console.log("> Wybieram functionsForMulti: ", f.id, " : ", f.name)
            return f
        }
        else {
            return false
        }
    }

    getAlgorithmById = (singleOrMulti, id) => {
        if (singleOrMulti === "single") {
            let a = this.algorithmsForSingle.filter((a) => { return a.id == id })[0]
            // console.log("> Wybieram algorithmsForSingle: ", a.id, " : ", a.name)
            return a
        }
        else if (singleOrMulti === "multi") {
            let a = this.algorithmsForMulti.filter((f) => { return f.id == id })[0]
            // console.log("> Wybieram algorithmsForMulti: ", a.id, " : ", a.name)
            return a
        }
        else {
            return false
        }
    }

    // get algo of id

    // FUNCTIONS / ALGOS CHANGING (onChange)

    handleOnChangeFuncId = (singleOrMulti, id, e) => {

        if (singleOrMulti === "single") {
            if (e.target.checked) {
                this.singleFuncIds.push(e.target.value)
            }
            if (!e.target.checked) {
                this.singleFuncIds = this.singleFuncIds.filter(item => item !== e.target.value)
            }
            // console.log("single handleOnChangeFuncId: ")
            this.show(this.singleFuncIds)
        }
        else if (singleOrMulti === "multi") {
            this.multiFuncId = e.target.value
            // console.log("multi handleOnChangeFuncId: ", this.multiFuncId)
        }
        else { }

    }

    handleOnChangeAlgoId = (singleOrMulti, e) => {

        if (singleOrMulti === "single") {
            this.singleAlgoId = e.target.value
            // console.log("single handleOnChangeAlgoId: ", this.singleAlgoId)
            this.setAlgorithmParameters(e.target.value, "all", "min") // ustawienie wartości wstępnych (minimalnych) wartości
        }
        else if (singleOrMulti === "multi") {
            if (e.target.checked) {
                this.multiAlgoIds.push(e.target.value)
            }
            if (!e.target.checked) {
                this.multiAlgoIds = this.multiAlgoIds.filter(item => item !== e.target.value)
            }
            // console.log("multi handleOnChangeAlgoId: ")
            this.show(this.multiAlgoIds)
        }
        else { }

    }

    // PARAMETERS / DIMENSIONS changing

    setAlgorithmParameters = (algoId, position, value) => {
        if (position == "all" && value == "min") {
            runInAction(() => {
                // Array(n).fill(0)
                let a = this.getAlgorithmById("single", algoId)
                this.singleAlgoParameters = Array(a.parameters.length).fill(0) // wyzerowana tablica o długości tyle ile jest parametrów
                a.parameters.map((parameter, i) => (
                    // ustawienie na minimalne wartości
                    this.singleAlgoParameters[i] = parameter.lowerBoundary
                ))
            })
        }
        else {
            value = parseFloat(value)
            runInAction(() => {
                this.singleAlgoParameters[position] = value
            })
        }
        // console.log("parametry ustawione na: ")
        // console.log(this.singleAlgoParameters)
    }

    setIterations = (singleOrMulti, value) => {
        value = parseFloat(value)
        if (value > 0) {
            runInAction(() => {
                if (singleOrMulti == "single") {
                    this.singleIterations = value
                    return true
                }
                else if (singleOrMulti == "multi") {
                    this.multiIterations = value
                    return true
                }
                else {
                    return false
                }
            })
        }
    }

    setPopulation = (singleOrMulti, value) => {
        value = parseFloat(value)
        if (value > 0) {
            runInAction(() => {
                if (singleOrMulti == "single") {
                    this.singlePopulation = value
                    return true
                }
                else if (singleOrMulti == "multi") {
                    this.multiPopulation = value
                    return true
                }
                else {
                    return false
                }
            })
        }
    }

    setFuncDimension = (singleOrMulti, id, value) => {
        runInAction(() => {
            this.getFunctionById(singleOrMulti, id).dimension = value
        })
    }

    handleOnChangeFuncDim = (singleOrMulti, id, e) => {

        // zmiejszamy
        if (this.getFunctionById(singleOrMulti, id).dimension > e.target.value) {
            this.getFunctionById(singleOrMulti, id).lowerBoundaries.pop()
        }
        if (this.getFunctionById(singleOrMulti, id).dimension > e.target.value) {
            this.getFunctionById(singleOrMulti, id).upperBoundaries.pop()
        }

        // zwiekszamy
        if (this.getFunctionById(singleOrMulti, id).dimension < e.target.value) {
            this.getFunctionById(singleOrMulti, id).lowerBoundaries.push(-1)
        }
        if (this.getFunctionById(singleOrMulti, id).dimension < e.target.value) {
            this.getFunctionById(singleOrMulti, id).upperBoundaries.push(1)
        }

        this.setFuncDimension(singleOrMulti, id, e.target.value)
    }

    handleOnChangeFuncLowerBound = (singleOrMulti, fid, dim, e) => {
        if (singleOrMulti == "single") {
            // this.functions[id].lowerBoundaries[dim] = e.target.value
            this.getFunctionById(singleOrMulti, fid).lowerBoundaries[dim] = e.target.value
        }
        if (singleOrMulti == "multi") {
            // this.functions[id].lowerBoundaries[dim] = e.target.value
            this.getFunctionById(singleOrMulti, fid).lowerBoundaries[dim] = e.target.value
        }
    }

    handleOnChangeFuncUpperBound = (singleOrMulti, fid, dim, e) => {
        if (singleOrMulti == "single") {
            this.getFunctionById(singleOrMulti, fid).upperBoundaries[dim] = e.target.value
        }
        if (singleOrMulti == "multi") {
            this.getFunctionById(singleOrMulti, fid).upperBoundaries[dim] = e.target.value
        }
    }

    // SINGLE & MULTI TASK's

    // dla Single Taska:

    singleAlgoId = null;
    singleFuncIds = [];

    singlePopulation = 1
    singleIterations = 1
    singleAlgoParameters = null

    runSinlgeTask = async () => {

        console.log("> Uruchamiam SINGLE TASK")

        if (this.singleFuncIds.length > 0 && this.singleAlgoId){
            console.log("Wysyłam: ")
            console.log("AlgoId: ", this.singleAlgoId)
            console.log("FitFuncIds: ", this.singleFuncIds)
            console.log("NumOfAgents: ", this.singlePopulation)
            console.log("NumOfIterations: ", this.singleIterations)
            console.log("AlgoParameters: ", this.getAlgorithmById("single", this.singleAlgoId).parameters)
            console.log("FitFuncLowerBoundaries: ")
            {this.singleFuncIds.map((fid) => {
                console.log(this.getFunctionById("single", fid).lowerBoundaries)
            })}
            console.log("FitFuncUpperBoundaries: ")
            {this.singleFuncIds.map((fid) => {
                console.log(this.getFunctionById("single", fid).upperBoundaries)
            })}
        }
        else {
            console.log("Nie wybrano funkcjów i/lub algorytmu")
        }

        // console.log("Wysyłam")
        // TO DO

        // console.log("Czyszcze inputy")
        // TO DO

    }

    // dla Multi Taska:

    multiAlgoIds = []
    multiFuncId = null

    multiPopulation = 1
    multiIterations = 1

    runMultiTask = async () => {

        console.log("> Uruchamiam MULTI TASK")
        
        if (this.multiAlgoIds.length > 0 && this.multiFuncId){
            console.log("Wysyłam: ")
            console.log("AlgoIds: ", this.multiAlgoIds)
            console.log("FitFuncId: ", this.multiFuncId)
            console.log("NumOfAgents: ", this.multiPopulation)
            console.log("NumOfIterations: ", this.multiIterations)
            console.log("FitFuncDimension: ", this.getFunctionById("multi", this.multiFuncId).dimension)
            console.log("FitFuncLowerBoundaries: ", this.getFunctionById("multi", this.multiFuncId).lowerBoundaries)
            console.log("FitFuncUpperBoundaries: ", this.getFunctionById("multi", this.multiFuncId).upperBoundaries)
        }
        else {
            console.log("Nie wybrano funkcji i/lub algorytmów")
        }

        // console.log("Wysyłam")
        // TO DO

        // console.log("Czyszcze inputy")
        // TO DO

    }

    // przerywanie tasków PAUSE - RESUME

    przerwanoSingleTask = false;
    przerwanoMultiTask = false;
    // TO DO


    
    // FILE UPLOAD

    file = "";

    // handling upload

    handleOnChangeFile = (event) => {

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
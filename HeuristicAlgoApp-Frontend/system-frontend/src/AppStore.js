import { makeAutoObservable, runInAction } from "mobx";
import axios from "axios";

export default class AppStore {

    constructor() {
        makeAutoObservable(this);
    }

    //apiPath = 'https://jsonplaceholder.typicode.com/';
    apiPath = 'https://localhost:7071/api';

    // SHOW VALUES function to better see values of states when using mobx ..nah

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

    handleOnChangeFuncId = (singleOrMulti, e) => {

        const value = parseInt(e.target.value)

        if (singleOrMulti === "single") {
            if (e.target.checked) {
                this.singleFuncIds.push(value)
            }
            if (!e.target.checked) {
                this.singleFuncIds = this.singleFuncIds.filter(item => item !== value)
            }
            // console.log("single handleOnChangeFuncId: ")
            // this.show(this.singleFuncIds)
        }
        else if (singleOrMulti === "multi") {
            this.multiFuncId = value
            // console.log("multi handleOnChangeFuncId: ", this.multiFuncId)
        }
        else { }

    }

    handleOnChangeAlgoId = (singleOrMulti, e) => {

        const value = parseInt(e.target.value)

        if (singleOrMulti === "single") {
            this.singleAlgoId = value
            // console.log("single handleOnChangeAlgoId: ", this.singleAlgoId)
            this.setAlgorithmParameters(value, "all", "min") // ustawienie wartości wstępnych (minimalnych) wartości
        }
        else if (singleOrMulti === "multi") {
            if (e.target.checked) {
                this.multiAlgoIds.push(value)
            }
            if (!e.target.checked) {
                this.multiAlgoIds = this.multiAlgoIds.filter(item => item !== value)
            }
            // console.log("multi handleOnChangeAlgoId: ")
            // this.show(this.multiAlgoIds)
        }
        else { }

    }

    // PARAMETERS / DIMENSIONS changing

    setAlgorithmParameters = (algoId, position, value) => {
        if (this.getAlgorithmById("single", algoId).parameters != null) {

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

    // SINGLE & MULTI TASK's ///////////////////////////////////////////////////////////////////////////////////////////////////////

    singleTaskIsStarted = false;
    multiTaskIsStarted = false;

    setSingleTaskIsStarted = (bool) => {
        this.singleTaskIsStarted = bool
    }

    setMultiTaskIsStarted = (bool) => {
        this.multiTaskIsStarted = bool
    }

    // dla SINGLE Taska:

    singleAlgoId = null;
    singleFuncIds = [];

    singlePopulation = 1
    singleIterations = 1
    singleAlgoParameters = null

    runSinlgeTask = async () => {

        console.log("> Uruchamiam SINGLE TASK")

        if (this.singleFuncIds.length > 0 && this.singleAlgoId) {
            console.log("Wysyłam: ")
            console.log("AlgoId: ", this.singleAlgoId)
            console.log("FitFuncIds: ", this.singleFuncIds)
            console.log("NumOfAgents: ", this.singlePopulation)
            console.log("NumOfIterations: ", this.singleIterations)
            console.log("AlgoParameters: ", this.getAlgorithmById("single", this.singleAlgoId).parameters)
            console.log("FitFuncDimensions: ")
            {
                this.singleFuncIds.map((fid) => {
                    console.log(this.getFunctionById("single", fid).dimension)
                })
            }
            console.log("FitFuncLowerBoundaries: ")
            {
                this.singleFuncIds.map((fid) => {
                    console.log(this.getFunctionById("single", fid).lowerBoundaries)
                })
            }
            console.log("FitFuncUpperBoundaries: ")
            {
                this.singleFuncIds.map((fid) => {
                    console.log(this.getFunctionById("single", fid).upperBoundaries)
                })
            }

            console.log("Wysyłam")
            // this.clearSinglePDFReports()
            this.setSingleTaskIsStarted(true)
            this.setSingleTaskIsRunning(true)

            const pWaiting = new Promise((resolve) => { // sztuczne czekanie pare sekund, tak jakby się tam coś mieliło
                console.log("Timeout: 0.5 sekund")
                setTimeout(resolve, 500, 'pWaiting');
            })

            const pSingleTaskResponse = await this.postSingleTask()
                .then((result) => {
                    console.log("Odebrano [data]: ", result.data)
                    return result.data
                })
                .catch((err) => {
                    console.log("Task error: ", err)
                    return null
                })

            Promise.all([pWaiting, pSingleTaskResponse])
                .then((values) => {
                    if (values[1] == null) {
                        throw Error("^")
                    }
                    console.log("Proms resolved")
                    this.setSingleTaskIsStarted(false)
                    this.setSingleTaskIsRunning(false)
                    this.clearSinglePDFReports() // wyczyść stare reporty
                    this.addSinglePDFReports(values[1]) // wsadź te odnośnie aktualngo zadania
                })
                .catch(() => {
                    console.log("Promises error")
                    this.setSingleTaskIsStarted(false)
                    this.setSingleTaskIsRunning(false)
                    alert("Przepraszamy, SingleTask nie mógł się wykonać :( \nMożliwe, że podano niedozwolone wartości parametrów.")
                })

        }
        else {
            alert("Nie wybrano funkcji i/lub algorytmów")
            console.log("Nie wybrano funkcjów i/lub algorytmu")
        }
    }

    postSingleTask = async () => {

        return axios.post(this.apiPath + '/Task/TaskForSingleAlgo',
            {
                AlgoId: this.singleAlgoId,
                FitFuncIds: this.singleFuncIds,
                NumOfAgents: this.singlePopulation,
                NumOfIterations: this.singleIterations,
                AlgoParameters: this.singleAlgoParameters,
                FitFuncDimensions: this.singleFuncIds.map((fid) => {
                    return this.getFunctionById("single", fid).dimension
                }),
                FitFuncLowerBoundaries: this.singleFuncIds.map((fid) => {
                    return this.getFunctionById("single", fid).lowerBoundaries
                }),
                FitFuncUpperBoundaries: this.singleFuncIds.map((fid) => {
                    return this.getFunctionById("single", fid).upperBoundaries
                }),
            })
            .then((response) => {
                // if(response.status == 200){
                return response
                // }
            })
            .catch((err) => {
                console.log("postTask error: ", err)
            })
    }

    // dla MULTI Taska:

    multiAlgoIds = []
    multiFuncId = null

    multiPopulation = 1
    multiIterations = 1

    runMultiTask = async () => {

        console.log("> Uruchamiam MULTI TASK")

        if (this.multiAlgoIds.length > 0 && this.multiFuncId) {
            console.log("Wysyłam: ")
            console.log("AlgoIds: ", this.multiAlgoIds)
            console.log("FitFuncId: ", this.multiFuncId)
            console.log("NumOfAgents: ", this.multiPopulation)
            console.log("NumOfIterations: ", this.multiIterations)
            console.log("FitFuncDimension: ", this.getFunctionById("multi", this.multiFuncId).dimension)
            console.log("FitFuncLowerBoundaries: ", this.getFunctionById("multi", this.multiFuncId).lowerBoundaries)
            console.log("FitFuncUpperBoundaries: ", this.getFunctionById("multi", this.multiFuncId).upperBoundaries)

            console.log("Wysyłam")
            // this.clearMultiPDFReports()
            this.setMultiTaskIsStarted(true)
            this.setMultiTaskIsRunning(true)

            const pWaiting = new Promise((resolve) => { // sztuczne czekanie pare sekund, tak jakby się tam coś mieliło
                console.log("Timeout 0.5 sekundy")
                setTimeout(resolve, 500, 'pWaiting');
            })

            const pMultiTaskResponse = await this.postMultiTask()
                .then((result) => {
                    console.log("Odebrano [data]: ", result.data)
                    return result.data
                })
                .catch((err) => {
                    console.log("Task error: ", err)
                    return null
                })

            Promise.all([pWaiting, pMultiTaskResponse])
                .then((values) => {
                    if (values[1] == null) {
                        throw Error("^")
                    }
                    console.log("Proms resolved")
                    this.setMultiTaskIsStarted(false)
                    this.setMultiTaskIsRunning(false)
                    this.clearMultiPDFReports() // wyczyść stare reporty
                    this.addMultiPDFReports(values[1]) // wsadź te odnośnie aktualngo zadania                    
                })
                .catch((err) => {
                    console.log("Promises error: ", err)
                    this.setMultiTaskIsStarted(false)
                    this.setMultiTaskIsRunning(false)
                    alert("Przepraszamy, MultiTask nie mógł się wykonać :( \nMożliwe, że podano niedozwolone wartości parametrów.")
                })
        }
        else {
            alert("Nie wybrano funkcji i/lub algorytmów")
            console.log("Nie wybrano funkcji i/lub algorytmów")
        }
    }

    postMultiTask = async () => {

        return axios.post(this.apiPath + '/Task/TaskForMultiAlgo',
            {
                AlgoIds: this.multiAlgoIds,
                FitFuncId: this.multiFuncId,
                NumOfAgents: this.multiPopulation,
                NumOfIterations: this.multiIterations,
                FitFuncDimension: this.getFunctionById("multi", this.multiFuncId).dimension,
                FitFuncLowerBoundaries: this.getFunctionById("multi", this.multiFuncId).lowerBoundaries,
                FitFuncUpperBoundaries: this.getFunctionById("multi", this.multiFuncId).upperBoundaries
            })
            .then((response) => {
                // if(response.status == 200){
                return response
                // }
            })
            .catch((err) => {
                console.log("postTask error: ", err)
            })
    }

    // przerywanie tasków PAUSE - RESUME

    singleTaskIsRunning = false;
    singleTaskState = null;

    multiTaskIsRunning = false;
    multiTaskState = null;

    setSingleTaskIsRunning = (bool) => {
        this.singleTaskIsRunning = bool
    }

    setSingleTaskState = (data) => {
        this.singleTaskState = data
    }

    setMultiTaskIsRunning = (bool) => {
        this.multiTaskIsRunning = bool
    }

    setMultiTaskState = (data) => {
        this.multiTaskState = data
    }

    breakTask = async (singleOrMulti) => {

        console.log("Breaking " + singleOrMulti + " task..")
        if (singleOrMulti == "single") {
            await this.sendBreakTask()
                .then((response) => {
                    console.log("responseBreakTask (s) json: ", response)
                    // let stan = String(response.name + " " + String(response.id) + "/" + String(response.id) + " [" + String(Math.round((response.id / response.id) * 100)) + "%]")
                    let stan = String(response.name + " " + String(response.i) + "/" + String(response.it) + " [" + String(Math.round((response.i / response.it) * 100)) + "%]")
                    this.setSingleTaskState(stan)
                    this.setSingleTaskIsRunning(false)
                })
                .catch((err) => {
                    alert(err.message)
                    console.log("break not ok: ", err)
                })
            }
            if (singleOrMulti == "multi") {
                await this.sendBreakTask()
                .then((response) => {
                    console.log("responseBreakTask (m) json: ", response)
                    let stan = ""
                    try {
                        response.map((r) => {
                            stan = stan + String(r.name + " " + String(r.i) + "/" + String(r.it) + " [" + String(Math.round((r.i / r.it) * 100)) + "%]")
                        })
                    }
                    catch{
                        stan = String(response.name + " " + String(response.i) + "/" + String(response.it) + " [" + String(Math.round((response.i / response.it) * 100)) + "%]")
                    }
                    this.setMultiTaskState(stan)
                    this.setMultiTaskIsRunning(false)
                })
                .catch((err) => {
                    alert(err.message)
                    console.log("break not ok: ", err)
                })
        }
    }

    resumeTask = async (singleOrMulti) => {

        console.log("Resuming " + singleOrMulti + " task..")
        if (singleOrMulti == "single") {
            await this.sendResumeTask()
                .then((response) => {
                    console.log("responseResumeTask (s): ", response)
                    this.setSingleTaskIsRunning(true)
                })
                .catch((err) => {
                    alert(err.message)
                    console.log("resume not ok: ", err)
                })
        }
        if (singleOrMulti == "multi") {
            await this.sendResumeTask()
                .then((response) => {
                    console.log("responseResumeTask (m): ", response)
                    this.setMultiTaskIsRunning(true)
                })
                .catch((err) => {
                    alert(err.message)
                    console.log("resume not ok: ", err)
                })
        }
    }

    sendBreakTask = async () => {
        // return axios.get("https://localhost:7071/api/Algorithm/GetById/2")
        // return axios.get("https://localhost:7071/api/Algorithm/GetAll")
        return axios.get(this.apiPath + '/Task/BreakSolving')
            .then((response) => {
                if (response.status == 200) {
                    return response.data
                }
                else {
                    throw Error("Not 200")
                }
            })
    }

    sendResumeTask = async () => {
        return axios.get(this.apiPath + '/Task/ResumeSolving')
            .then((response) => {
                if (response.status == 200) {
                    return response
                }
                else {
                    throw Error("Not 200")
                }
            })
    }

    // PDF REPORTs

    // single
    singlePDFReports = []

    addSinglePDFReports = (reportsNames) => {
        reportsNames.map((n) => {
            this.singlePDFReports.push(n)
        })
    }

    clearSinglePDFReports = () => {
        this.singlePDFReports = []
    }

    // multi

    multiPDFReports = []

    addMultiPDFReports = (reportsNames) => {
        reportsNames.map((n) => {
            this.multiPDFReports.push(n)
        })
    }

    clearMultiPDFReports = () => {
        this.multiPDFReports = []
    }

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
                await axios.post(this.apiPath + '/Upload/Add', formData)
                .then((response) => {
                    if(response.status == 200){
                        console.log('Plik przesłany pomyślnie', response);
                        alert("Plik przesłany pomyślnie - odśwież stronę")
                    }
                    else{
                        throw Error(response)
                    }
                })
                .catch((err) => {
                    console.log('Błąd podczas przesyłania pliku: ', err);
                    alert("Błąd podczas przesyłania pliku do bazy \n[" + err.message + "]")
                })
            } catch (error) {
                console.error('Błąd: ', error);
            }
        }
        else {
            alert("Najpierw wybierz plik .dll")
            console.log("Brak pliku do przesłania")
        }

        this.file = ""
        console.log("Czyszcze input")
        document.getElementById("fileUpload").value = ""
    }


}
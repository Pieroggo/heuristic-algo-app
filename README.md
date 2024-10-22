## App for running Optimization Algorithms for given Functions (ASP.NET/React)
Web app project, created in winter 2023/24

The application requires a .dll file with algorithm classes, implementing `IOptimizationAlgorithm` interface and fitness function classes, implementing `IFitnessFunction` interface. To test the app, a dll file is given in the main directory with 3 prepared algorithms:
- Salp Swarm Algorithm
- Grey Wolf Algorithm
- Archimedes Optimization Algorithm

Once you upload the file and refresh the site, you can pick either to test one algorithm with many functions or many algorithms with one function. Result will be returned in a form of a pdf file (one for each algorithm in case of testing many algorithms), which can be downloaded.

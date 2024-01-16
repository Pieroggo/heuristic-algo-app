import React, { Component } from 'react';
import { useStore } from "../store";
import { observer } from "mobx-react-lite";
import DimBoundariesForFunc from "./DimBoundariesForFunc";
import PopulationAndIterationsForAlgo from './PopulationAndIterationsForAlgo';
import ParametersForAlgo from './ParametersForAlgo';
//import Parameters from "./Parameters";

export default observer(function Inputs({ algoOrFunc, multiple }) {

    const { appStore } = useStore();

    // for SINGLE TASK

    // one algo

    if (algoOrFunc === "algo" && multiple === false) {
        return (
            <div className='items'>
                <table className="bp4-html-table .modifier">
                    <thead>
                        <tr>
                            <th>id</th>
                            <th>nazwa</th>
                        </tr>
                    </thead>
                    <tbody>
                        {appStore.algorithmsForSingle.map(algo => (
                            <tr key={algo.id}>
                                <td>{algo.id}</td>
                                <td>
                                    <label htmlFor={"single-algo-" + algo.id}>
                                        {algo.name}
                                    </label>
                                    {(appStore.singleAlgoId == algo.id) && (algo.parameters != null) && (algo.parameters.length > 0) &&
                                        <div>
                                            <br />
                                            <ParametersForAlgo id={algo.id} />
                                        </div>
                                    }
                                </td>
                                <td>
                                    <input type="radio" id={"single-algo-" + algo.id} value={algo.id} name="single-algo-radio" onChange={(e) => appStore.handleOnChangeAlgoId("single", e)}></input>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                {(appStore.singleAlgoId) &&
                    <div>
                        <br />
                        <PopulationAndIterationsForAlgo singleOrMulti={"single"} />
                    </div>
                }
            </div>
        )
    }

    // for SINGLE TASK

    // many functions

    if (algoOrFunc === "func" && multiple === true) {
        return (
            <table className="bp4-html-table .modifier">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>nazwa</th>
                    </tr>
                </thead>
                <tbody>
                    {appStore.functionsForSingle.map(func => (
                        <tr key={func.id}>
                            <td>{func.id}</td>
                            <td>
                                <label htmlFor={"single-func-" + func.id}>
                                    {func.name}
                                </label>
                                {/* {console.log("funcId: ", func.id, appStore.singleFuncIds.find(fid => fid == func.id), appStore.singleFuncIds.includes(func.id))} */}
                                {func.id == appStore.singleFuncIds.find(fid => fid == func.id) &&
                                    <div>
                                        <br />
                                        {/* WYMIAR */}
                                        <label htmlFor={"single-func-dim-" + func.id}>Wymiary: </label>
                                        <input
                                            type="number"
                                            id={"single-func-dim-" + func.id}
                                            value={func.dimension}
                                            min={1}
                                            maxLength={2}
                                            className="smallNumInput"
                                            disabled={!func.isDimensionInfinite}
                                            onChange={(e) => appStore.handleOnChangeFuncDim("single", func.id, e)}>
                                        </input>

                                        {/* GRANICE WYMIARÓW */}
                                        <p>&lt; dolna granica &#59; górna granica &gt;</p>
                                        <DimBoundariesForFunc singleOrMulti={"single"} id={func.id} />

                                    </div>
                                }
                            </td>
                            <td>
                                <input type="checkbox" id={"single-func-" + func.id} value={func.id} name="single-func-boxes" onChange={(e) => appStore.handleOnChangeFuncId("single", e)} ></input>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        )
    }

    // for MULTI TASK

    // many algos

    if (algoOrFunc === "algo" && multiple === true) {
        return (
            <div className='items'>
                <table className="bp4-html-table .modifier">
                    <thead>
                        <tr>
                            <th>id</th>
                            <th>nazwa</th>
                        </tr>
                    </thead>
                    <tbody>
                        {appStore.algorithmsForMulti.map(algo => (
                            <tr key={algo.id}>
                                <td>{algo.id}</td>
                                <td>
                                    <label htmlFor={"multi-algo-" + algo.id}>
                                        {algo.name}
                                    </label>
                                </td>
                                <td>
                                    <input type="checkbox" id={"multi-algo-" + algo.id} value={algo.id} name="multi-algo-boxes" onChange={(e) => appStore.handleOnChangeAlgoId("multi", e)}></input>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                {(appStore.multiAlgoIds.length > 0) &&
                    <div>
                        <br />
                        <PopulationAndIterationsForAlgo singleOrMulti={"multi"} />
                    </div>
                }
            </div>
        )
    }

    // for MULTI TASK

    // one function

    if (algoOrFunc === "func" && multiple === false) {
        return (
            <table className="bp4-html-table .modifier">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>nazwa</th>
                    </tr>
                </thead>
                <tbody>
                    {appStore.functionsForMulti.map(func => (
                        <tr key={func.id}>
                            <td>{func.id}</td>
                            <td>
                                <label htmlFor={"multi-func-" + func.name}>
                                    {func.name}
                                </label>
                                {appStore.multiFuncId == func.id &&
                                    <div>
                                        <br />
                                        {/* WYMIAR */}
                                        <label htmlFor="multi-func-dim">Wymiary: </label>
                                        <input
                                            type="number"
                                            id="multi-func-dim"
                                            value={func.dimension}
                                            min={1}
                                            maxLength={2}
                                            className="smallNumInput"
                                            disabled={!func.isDimensionInfinite}
                                            onChange={(e) => appStore.handleOnChangeFuncDim("multi", func.id, e)}>
                                        </input>

                                        {/* GRANICE WYMIARÓW */}
                                        <p>&lt; dolna granica &#59; górna granica &gt;</p>
                                        <DimBoundariesForFunc singleOrMulti={"multi"} id={func.id} />

                                    </div>
                                }
                            </td>
                            <td>
                                <input type="radio" id={"multi-func-" + func.name} value={func.id} name="multi-func-radio" onChange={(e) => appStore.handleOnChangeFuncId("multi", e)}></input>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        )
    }




})
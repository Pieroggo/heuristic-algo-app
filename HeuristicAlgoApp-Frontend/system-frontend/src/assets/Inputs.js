import React, { Component } from 'react';
import { useStore } from "../store";
import { observer } from "mobx-react-lite";
import BoundariesFor from "./BoundariesFor";
//import Parameters from "./Parameters";

export default observer(function Inputs({ which, many }) {

    const { appStore } = useStore();

    // for SINGLE TASK

    // one algo

    if (which === "algo" && many === false) {
        return (
            <table className="bp4-html-table .modifier">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>nazwa</th>
                    </tr>
                </thead>
                <tbody>
                    {appStore.algorithms.map(algo => (
                        <tr key={algo.id}>
                            <td>{algo.id}</td>
                            <td>
                                <label htmlFor={algo.name + "_one"}>
                                    {algo.name}
                                </label>
                            </td>
                            <td>
                                <input type="radio" id={algo.name + "_one"} value={algo.id} name="algo-one"></input>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        )
    }

    // for SINGLE TASK

    // many functions

    if (which === "func" && many === true) {
        return (
            <table className="bp4-html-table .modifier">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>nazwa</th>
                    </tr>
                </thead>
                <tbody>
                    {appStore.functions.map(func => (
                        <tr key={func.id}>
                            <td>{func.id}</td>
                            <td>
                                <label htmlFor={func.name + "_many"}>
                                    {func.name}
                                </label>
                                {/* {appStore.funcID == func.id &&
                                    <div>
                                        <br />
                                        <label htmlFor="dim_f_many">wymiary: </label>
                                        <input type="number" id="dim_f_many" value={func.dimension} maxLength={1} className="smallNumInput" onChange={(e) => appStore.handleFuncDimChange(e, func.id)}></input>

                                        <p>&lt; dolna granica &#59; górna granica &gt;</p>
                                        <BoundariesFor id={func.id} />
                                        // boudariesFor jeszcze będzie przyjmował czy single czy multi?
                                        // kurcze, mam zagwostke
                                    </div>
                                } */}
                                {/* nie, to nie w ten sposób. trzeba inaczej */}
                                {/* więcej zmiennych - funkcje dla singla i funkcje dla multi [dwie kopie lokalnie] */}
                                {/* przy wysyłaniu pobierasz ino z this.'ów */}
                            </td>
                            <td>
                                {/* <input type="checkbox" id={func.name + "_many"} value={func.id} name="func-many" onChange={() => { appStore.handleFuncIDChange() }}></input> */}
                                {/* onChange wtedy będzie tylko zmieniał odpowiednie wartości odpowiednich zmiennych (opdowiednie XD ale będzie musiał wiedzieć po czymś które to są te odpowiednie)*/}
                                {/* nie potrzeba będzie skomplikowanych IDków (to jak chcesz wiedzieć co dotyczy którego S/M?)*/}
                                {/* React jest stanowy jak USA */}
                                <input type="checkbox" id={func.name + "_many"} value={func.id} name="func-many" onChange={() => { }} ></input>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        )
    }

    // for MULTI TASK

    // many algos

    if (which === "algo" && many === true) {
        return (
            <table className="bp4-html-table .modifier">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>nazwa</th>
                    </tr>
                </thead>
                <tbody>
                    {appStore.algorithms.map(algo => (
                        <tr key={algo.id}>
                            <td>{algo.id}</td>
                            <td>
                                <label htmlFor={algo.name + "_many"}>
                                    {algo.name}
                                </label>
                            </td>
                            <td>
                                <input type="checkbox" id={algo.name + "_many"} value={algo.id} name="algo-many" onChange={() => appStore.handleAlgoIDsChange()}></input>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        )
    }

    // for MULTI TASK

    // one function

    if (which === "func" && many === false) {
        return (
            <table className="bp4-html-table .modifier">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>nazwa</th>
                    </tr>
                </thead>
                <tbody>
                    {appStore.functions.map(func => (
                        <tr key={func.id}>
                            <td>{func.id}</td>
                            <td>
                                <label htmlFor={func.name + "_one"}>
                                    {func.name}
                                </label>
                                {appStore.funcID == func.id &&
                                    // może tak?
                                    // <Parameters id={func.id}/>
                                    <div>
                                        <br />
                                        <label htmlFor="dim_f_one">wymiary: </label>
                                        <input type="number" id="dim_f_one" value={func.dimension} maxLength={1} className="smallNumInput" onChange={(e) => appStore.handleFuncDimChange(e, func.id)}></input>

                                        <p>&lt; dolna granica &#59; górna granica &gt;</p>
                                        <BoundariesFor id={func.id} />

                                        {/* <br />
                                        <label>dolna granica:
                                            <input type="number" id={func.lowerBoundaries[0] + "_one"} value={func.lowerBoundaries[0]} className="mediumNumInput" onChange={(e) => appStore.handleFuncLowBoundChange(e, 1, func.id)}></input>
                                        </label> */}
                                    </div>
                                }
                            </td>
                            <td>
                                <input type="radio" id={func.name + "_one"} value={func.id} name="func-one" onChange={() => { appStore.handleFuncIDChange() }}></input>
                            </td>
                        </tr>
                        // TO DO wyświetlenie paramsów dla wybranych
                    ))}
                </tbody>
            </table>
        )
    }




})
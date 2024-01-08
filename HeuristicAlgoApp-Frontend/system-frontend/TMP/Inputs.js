import { useStore } from "../store";
import { observer } from "mobx-react-lite";
import BoundariesFor from "./BoundariesFor";
import Parameters from "./Parameters";

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
                            </td>
                            <td>
                                <input type="checkbox" id={func.name + "_many"} value={func.id} name="func-many"></input>
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
                                        <input type="number"
                                            id="dim_f_one"
                                            value={func.dimension}
                                            maxLength={1}
                                            className="smallNumInput"
                                            onChange={(e) => appStore.handleFuncDimChange(e, func.id)}
                                        >
                                        </input>
                                        {/* {appStore.checkDim(func.id)} */}

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
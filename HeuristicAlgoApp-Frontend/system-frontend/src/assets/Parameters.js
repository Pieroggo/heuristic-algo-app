import { useStore } from "../store";
import { observer } from "mobx-react-lite";

export default observer(function Parametry({ }) {

    const { appStore } = useStore();

    <div>
        <br />
        {/* <label htmlFor={func.dimension + "_one"}>wymiary: </label>
        <input type="number" id={func.dimension + "_one"} value={func.dimension} maxLength={1} className="smallNumInput"></input>

        for (let i=0; i<2; i++){

            }

        <br />
        <label htmlFor={func.lowerBoundaries[0] + "_one"}>dolna granica: </label>
        <input type="number" id={func.lowerBoundaries[0] + "_one"} value={func.lowerBoundaries[0]} className="mediumNumInput"></input> */}
    </div>


})
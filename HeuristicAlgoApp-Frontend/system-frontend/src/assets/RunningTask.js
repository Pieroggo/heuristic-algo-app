import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function RunningTask({ singleOrMulti }) {

    const { appStore } = useStore();

    if(appStore.singlePDFReport){
        return (
            <div className="runningTask">
                <form action="/pdf/DummySingleAlgoPDF.pdf" className="buttonForm">
                    <input type="submit" value="Otwórz raport" />
                </form>
            </div>
        )
    }


})

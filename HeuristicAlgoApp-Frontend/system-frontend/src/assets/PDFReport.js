import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function PDFReport({ singleOrMulti }) {

    const { appStore } = useStore();

    if(singleOrMulti == "single"){
        return (
            <div className="report">
                <form action="/pdf/DummySingleAlgoPDF.pdf" target="_blank" className="buttonForm">
                    <input type="submit" value="Otwórz raport" />
                </form>
            </div>
        )
    }

    if(singleOrMulti == "multi"){
        return (
            <div className="report">
                <form action="/pdf/DummyMultiAlgoPDF.pdf" target="_blank" className="buttonForm">
                    <input type="submit" value="Otwórz raport" />
                </form>
            </div>
        )
    }


})

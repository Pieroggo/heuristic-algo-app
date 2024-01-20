import { useStore } from "../store";
import React from 'react';
import { observer } from "mobx-react-lite";

export default observer(function PDFReport({ singleOrMulti }) {

    const { appStore } = useStore();

    if (singleOrMulti == "single") {
        return (
            <div className="report">
                <h3>Przejrzyj raporty: </h3>
                {appStore.singlePDFReports.map((reportName, i) => (
                    <form action={"/pdf/" + reportName} target="_blank" className="buttonForm reportButton" key={i} id={"report-" + i}>
                        <input type="submit" value={reportName} />
                    </form>
                ))}
            </div>
        )
    }
    else if (singleOrMulti == "multi") {
        return (
            <div className="report">
                <h3>Przejrzyj raporty: </h3>
                {appStore.multiPDFReports.map((reportName, i) => (
                    <form action={"/pdf/" + reportName} target="_blank" className="buttonForm reportButton" key={i} id={"report-" + i}>
                        <input type="submit" value={reportName} />
                    </form>
                ))}
            </div>
        )
    }


})

"use client";

import { getElectionDetails } from "@/app/server/GetElectionDetails"
import { useEffect, useState } from "react"
import Results from "./Results";

export default function ResultsPage() {
    const [electionStatus, setElectionStatus] = useState(false);

    useEffect(() => {
        getElectionDetails().then((res) => {
            setElectionStatus(res.data.ongoing);
        })
    }, [])

    return (
        <>
        {
            electionStatus ? (
                <div className="text-2xl text-center m-5 font-semibold">Election is ongoing. Please wait for it to finish before viewing results.</div>
            ) : (
                <Results />
            )
        }

        </>
    )
}
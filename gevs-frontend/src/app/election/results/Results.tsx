import { useEffect, useState } from "react"
import { getElectionResult } from "@/app/server/GetElectionResult"
export default function Results() {
    const [electionResult, setElectionResult] = useState<any>([]);
    const [winner, setWinner] = useState<any>("");
    const [status, setStatus] = useState<any>("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getElectionResult().then((res) => {
            setElectionResult(res.data);
            setWinner(res.data.winner);
            setStatus(res.data.status);
            setLoading(false);
        })
    }, [])

    return (
        <>
        <div className="text-2xl text-center m-5 font-semibold">Election Results</div>
        <div className="text-xl text-center m-5 font-semibold">Status: {status}</div>
        <div className="text-xl text-center m-5 font-semibold">Winner: {winner == null ? "Currently no winner" : winner }</div>
        {
            loading ? (
                <div className="text-2xl text-center m-5 font-semibold">Loading...</div>
            ) : (
                <>
                <table className="table-auto m-5">
                <thead>
                    <tr>
                        <th className="px-4 py-2">Party</th>
                        <th className="px-4 py-2">Seats</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        electionResult.seats?.map((item: any, index: any) => {
                            return (
                                <tr key={index}>
                                    <td className="border px-4 py-2">{item.party}</td>
                                    <td className="border px-4 py-2">{item.seat}</td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </table>
                </>
            )
        }
        
        </>
    )
}
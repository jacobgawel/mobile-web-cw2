import { getTokenClient } from "../actions/authActions";

export async function getElectionDetails() {
    console.log("GetElectionDetails.ts: getElectionDetails()");

    const res = await fetch('http://localhost:8000/gevs/election/status', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }, 
        cache: 'no-store'
    });
    // check if the response is ok
    if (!res.ok) {
        return { status: res.status, message: res.statusText}
    }
    return { status: res.status, data: await res.json() }
}
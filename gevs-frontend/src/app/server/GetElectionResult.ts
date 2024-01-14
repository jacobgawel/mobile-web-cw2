export async function getElectionResult() {
    console.log("GetElectionResult.ts: getElectionResult()");

    const res = await fetch('http://localhost:8000/gevs/results', {
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
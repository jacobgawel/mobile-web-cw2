export async function getCandidatesByConstituency(constituency: string) {
    console.log("GetCandidates.ts: getCandidatesByConstituency()");

    const res = await fetch('http://localhost:8000/gevs/constituency/' + constituency, {
        method: 'GET',
        cache: 'no-store'
    });
    // check if the response is ok
    if (!res.ok) {
        return { status: res.status, message: res.statusText}
    }

    return { status: res.status, data: await res.json() }
}
"use server"
import { getCurrentUser, getTokenClient  } from "../actions/authActions"

export async function electionSwitch(status: boolean) {
    console.log("VoteForCandidate.ts: voteForCandidate()");
    const token = await getTokenClient()
    const res = await fetch('http://localhost:8000/gevs/admin/election/' + status, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token?.access_token
        }
    });

     if (!res.ok) {
        return { status: res.status, message: res.statusText}
    }
    return { status: res.status, data: res.statusText }
}
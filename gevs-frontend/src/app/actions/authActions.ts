import { getServerSession } from "next-auth";
import { authOptions } from "../api/auth/[...nextauth]/route";
import { cookies, headers } from "next/headers";
import { NextApiRequest } from "next";
import { getToken } from "next-auth/jwt";

export async function getSession() {
    console.log("authActions.ts: getSession()");
    return await getServerSession(authOptions);
}

export async function getCurrentUser() {
    console.log("authActions.ts: getCurrentUser()");
    // Gets the current user session e.g. { name, image, etc... }
    try {
        const session = await getSession();

        if (!session) {
            return null;
        }

        return session.user;
    } catch (e) {
        console.error(e);
        return null;
    }
}

// gets the current user token to make authenticated requests
export async function getTokenClient() {
    console.log("authActions.ts: getTokenClient()");
    const req = {
        headers: Object.fromEntries(headers() as Headers),
        cookies: Object.fromEntries(
            cookies()
                .getAll()
                .map((c) => [c.name, c.value])
        )
    } as NextApiRequest;

    return await getToken({ req })
}
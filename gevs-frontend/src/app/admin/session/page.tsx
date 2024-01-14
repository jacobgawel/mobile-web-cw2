import { getSession, getTokenClient } from "../../actions/authActions";
import SessionData from "./SessionData";


export default async function Page() {
    const session = await getSession();
    const token = await getTokenClient();
    const role = session!.user.role;

    return (
        <>
        {
            role === 'admin' ? (
                <SessionData />
            ) : (
                <div className="text-2xl text-center m-5 font-semibold">You are not authorized to view this page</div>
            )
        }
        </>
    )
}
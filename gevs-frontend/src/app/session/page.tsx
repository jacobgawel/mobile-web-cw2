import { getSession } from "../actions/authActions";
import NavigationBar from "@/components/NavigationBar";

export default async function Page() {
    const session = await getSession();
    return (
        <>
        <div className="text-2xl text-center m-5 font-semibold">Session</div>
        <div className="bg-blue-200 border-2 border-blue-500 m-5">
            <h3 className='text-lg'>
                Session Data
            </h3>
            <pre>{JSON.stringify(session, null, 2)}</pre>
        </div>
        </>
    )
}
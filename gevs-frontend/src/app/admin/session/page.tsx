import { getSession, getTokenClient } from "../../actions/authActions";


export default async function Page() {
    const session = await getSession();
    const token = await getTokenClient();

    // redirect the user to the / page if they are not an admin

    if (session?.user.role !== 'admin') {
        window.location.href = '/';
    }

    return (
        <>
        <div className="text-2xl text-center m-5 font-semibold">Session</div>
        <div className="bg-blue-200 border-2 border-blue-500 m-5">
            <h3 className='text-lg'>
                Session Data
            </h3>
            <pre>{JSON.stringify(session, null, 2)}</pre>
        </div>
        <div className="bg-green-200 border-2 border-blue-500 m-5">
            <h3 className='text-lg'>
                Token Data
            </h3>
            <pre>{JSON.stringify(token, null, 2)}</pre>
        </div>
        </>
    )
}
import Image from 'next/image'
import { getElectionDetails } from './server/GetElectionDetails'
import { getCurrentUser } from './actions/authActions'

export default async function Home() {
  const electionDetails = await getElectionDetails()
  console.log(electionDetails)
  var user = await getCurrentUser()

  var electionStatus = electionDetails.data.ongoing;
  var statusText = electionStatus ? "There are currently ongoing elections." 
  : "There are currently no ongoing election.";

  return (
    <>
      <div className="flex flex-col items-center justify-center min-h-screen py-2">
        <div className="flex flex-col items-center justify-center min-h-screen py-2">
          <h1 className="text-6xl font-bold">
            Welcome to the voting App!
          </h1>
          <p className="mt-3 text-3xl">
            {statusText}
          </p>
          {
            user == null && electionStatus ? 
            <p className="mt-3 text-2xl">Please make sure to login or register to vote </p>
            : null
          }
          {
            user != null && electionStatus ? 
            <p className="mt-3 text-2xl">Make sure to vote before the election ends </p>
            : null
          }
          {
            user != null && !electionStatus ? 
            <p className="mt-3 text-2xl">Make sure to vote in the next election </p>
            : null
          }
        </div>
      </div>
    </>
  )
}

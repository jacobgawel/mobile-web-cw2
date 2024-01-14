import Image from 'next/image'
import { getElectionDetails } from './server/GetElectionDetails'
import { getCurrentUser } from './actions/authActions'
import Link from 'next/link'
import { Button } from '@/components/ui/button'
import { signIn } from 'next-auth/react'

export default async function Home() {
  const electionDetails = await getElectionDetails()
  var user = await getCurrentUser()

  var electionStatus = electionDetails.data.ongoing;
  var statusText = electionStatus ? "There are currently ongoing elections." 
  : "There are currently no ongoing election.";

  return (
    <>
      <div className="flex flex-col items-center justify-center min-h-screen py-2">
        <div className="flex flex-col items-center justify-center min-h-screen py-2">
          <h1 className="text-6xl font-bold">
            Government Election Voting System
          </h1>
          <p className="mt-3 text-3xl">
            {statusText}
          </p>
          {
            user == null && electionStatus ? 
            <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
              <p className="mt-3 text-2xl">Make sure to login and vote before the election ends</p>
            </div>
            : null
          }
          {
            user != null && electionStatus ?
            <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
              <p className="mt-3 text-2xl">Make sure to vote before the election ends</p>
              <Link href={"/election/vote"}>
                <Button className="mt-3 p-5 pr-10 pl-10">Vote Here</Button>
              </Link>
            </div>
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

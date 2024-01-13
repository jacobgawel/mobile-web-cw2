"use server";

import React from "react";
import { getCurrentUser } from "@/app/actions/authActions";
import Link from "next/link";
import AuthActions from "./AuthActions";
import LoginButton from "./Login";
import { Button } from "@/components/ui/button"

export default async function NavigationBar() {
  const user = await getCurrentUser();
  var role = user?.role;

  return (
    <>
      <header className='sticky top-0 z-50 flex justify-between bg-white p-5 items-center text-grey-800 shadow-md'>
            <div className='flex items-center gap-4 font-semibold'>
                <Link href={"/"}>
                    GEVS
                </Link>
                <Link href={"/election/vote"}>
                    <Button variant="ghost" className="cursor-pointer hover:text-blue-500">Election</Button>
                </Link>
                <Link href={"/election/results"}>
                    <Button variant="ghost" className="cursor-pointer hover:text-blue-500">Election Results</Button>
                </Link>
                <div>
                    { user ? ( <AuthActions user={user} role={role}/> ) : ( <LoginButton /> )}
                </div>
            </div>
        </header>
    </>
  )
}
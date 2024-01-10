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

  let navItems: string[] = ["Home", "Election", "Election Results"]

  return (
    <>
      <header className='sticky top-0 z-50 flex justify-between bg-white p-5 items-center text-grey-800 shadow-md'>
            <div className='flex items-center gap-4 font-semibold'>
                {navItems.map((item, index) => (
                    // If the item is "Home", then link to the root page. Otherwise, link to the page with the same name as the item.
                    // This is a really bad way of doing this but I don't know how to do it better.
                    item == "Home" ? (
                        <Link href={"/"} key={index}>
                            <Button variant="ghost" className="cursor-pointer hover:text-blue-500">{item}</Button>
                        </Link>
                    ) : (
                    <Link href={"/" + item.toLowerCase().replace(" ", "-")} key={index}>
                        <Button variant="ghost" className="cursor-pointer hover:text-blue-500">{item}</Button>
                    </Link>
                    )
                ))}
                <div>
                    { user ? ( <AuthActions user={user} role={role}/> ) : ( <LoginButton /> )}
                </div>
            </div>
        </header>
    </>
  )
}
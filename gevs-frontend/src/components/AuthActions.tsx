"use client";
import { signIn, signOut } from "next-auth/react";
import { getCurrentUser } from "@/app/actions/authActions";
import { Button } from "@/components/ui/button"
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuGroup,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuPortal,
    DropdownMenuSeparator,
    DropdownMenuShortcut,
    DropdownMenuSub,
    DropdownMenuSubContent,
    DropdownMenuSubTrigger,
    DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import Link from "next/link";
import { User } from "next-auth";

type Props = {
    user: Partial<User>; // Partial means that the type is optional. Doesn't have to be a full user.
    role: any;
}

export default function AuthActions({ user, role }: Props) {
    const username = user?.name;
    return (
        <DropdownMenu>
            <DropdownMenuTrigger asChild>
                <Button variant="ghost">Profile</Button>
            </DropdownMenuTrigger>
            <DropdownMenuContent className="w-56">
                <DropdownMenuLabel>Hello, {username}</DropdownMenuLabel>
                <DropdownMenuSeparator />
                <DropdownMenuGroup>
                <DropdownMenuItem>
                    <Link href={"/user/profile"}>
                        Profile
                    </Link>
                </DropdownMenuItem>
                { role === "admin" ? ( 
                    // if the user is an admin, show the admin links
                    <>
                    <DropdownMenuSeparator />
                    <DropdownMenuItem>
                    <Link href={"/admin/session"}>
                        Session Details
                    </Link> 
                    </DropdownMenuItem>
                    <DropdownMenuSeparator />
                    <DropdownMenuItem>
                        <Link href={"/admin/election-dashboard"}>
                            Election Dashboard
                        </Link>
                    </DropdownMenuItem>
                    </>
                ) : null
                    }
                </DropdownMenuGroup>
                <DropdownMenuSeparator />
                <DropdownMenuItem className="cursor-pointer" onClick={() => signOut({callbackUrl: '/'})}>
                    Log out
                </DropdownMenuItem>
            </DropdownMenuContent>
        </DropdownMenu>
    )
}
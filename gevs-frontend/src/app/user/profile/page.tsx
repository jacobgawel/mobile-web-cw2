import * as React from "react"

import { Button } from "@/components/ui/button"
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { getSession } from "../../actions/authActions"

export default async function ProfilePage() {
    
    const session = await getSession()

    return (
        <Card className="w-[350px] m-10">
            <CardHeader>
                <CardTitle>Profile Details</CardTitle>
                <CardDescription>You cannot edit your profile details at this time</CardDescription>
            </CardHeader>
            <CardContent>
                <CardDescription>Name: {session?.user.name}</CardDescription>
                <CardDescription>Email: {session?.user.username}</CardDescription>
                <CardDescription>Unique Voter Code: {session?.user.UVC}</CardDescription>
                <CardDescription>Birth Date: {session?.user.birthdate}</CardDescription>
                <CardDescription>Constituency: {session?.user.Constituency}</CardDescription>
            </CardContent>
        </Card>
    )
}

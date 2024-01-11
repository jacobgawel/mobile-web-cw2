"use client";

import { signIn } from 'next-auth/react';
import { Button } from '@/components/ui/button';
import {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
    CardHeader,
    CardTitle,
  } from "@/components/ui/card"

export default function Page({searchParams}: {searchParams: {callbackUrl: string}}) {
    // gets the fallback url from the query params
    var callbackUrl = searchParams.callbackUrl;
    return (
        <>
            <div className='flex justify-center'>
            <Card className="w-[350px] m-10">
                <CardHeader className='text-center text-2xl'>
                    <CardTitle>Sign In</CardTitle>
                    <CardDescription>Sign in to your account to vote</CardDescription>
                </CardHeader>
                <CardContent style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                    <Button onClick={() => signIn('id-server', {callbackUrl})}>
                        Sign in or create an account
                    </Button> 
                </CardContent>
            </Card>
            </div>
        </>
    )
}

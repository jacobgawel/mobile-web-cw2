"use client";

import { getCandidatesByConstituency } from "../server/GetCandidates";
import { getCurrentUser } from "../actions/authActionsNoHeaders";

import {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
    CardHeader,
    CardTitle,
  } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { useEffect, useState } from "react";
import { User } from "next-auth";
import { Button } from "@/components/ui/button";

export default function ElectionPage() {
    const [canVote, setCanVote] = useState(false);
    const [candidateData, setCandidateData] = useState<any>([]);
    const [user, setUser] = useState<any>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        setLoading(true);
        getCurrentUser().then((user: any) => {
            setUser(user);
            getCandidatesByConstituency(user.Constituency).then((candidates: any) => {
                setCandidateData(candidates.data.result);
                setLoading(false);
            }).catch((error: any) => {
                console.error("Error fetching candidates:", error);
            });
        }).catch((error: any) => {
            console.error("Error fetching user:", error);
        });
    }, []);

    useEffect(() => {
        if (user.role === "voter") {
            setCanVote(true);
        }
    }, [user]);

    console.log("Candidate data:", candidateData);

    return (
        <>
        <div className="m-10">
        <h1 className="text-2xl font-semibold">Vote here for the candidate in your constituency</h1>
        {
            canVote ? (
                <div>
                    <h2 className="m-5">You are eligible to vote</h2>
                    <ul>
                        {
                            loading ? (
                                <div>
                                    <h2>Loading...</h2>
                                </div>
                            ) : (
                                candidateData.map((candidate: any, index: any) => {
                                    return (
                                        <div key={index}>
                                            <Card className="m-5 w-[350px] text-center hover:bg-slate-50">
                                                <CardContent>
                                                    <CardHeader>
                                                        <CardTitle>
                                                            {candidate.name}
                                                        </CardTitle>
                                                    </CardHeader>
                                                    <CardDescription>
                                                        <Label className="text-gray-500">
                                                            {candidate.party}
                                                        </Label>
                                                    </CardDescription>
                                                </CardContent>
                                                <CardFooter style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                                                    <Button variant={"outline"} className="pl-10 pr-10 hover:bg-slate-300">
                                                        Vote
                                                    </Button>
                                                </CardFooter>
                                            </Card>
                                        </div>
                                    );
                                })
                            )                     
                        }
                    </ul>
                </div>  
            ) : (
                <div>
                    <h2>You are not eligible to vote</h2>
                </div>
            )
        }
        </div>
        </>
    );
}
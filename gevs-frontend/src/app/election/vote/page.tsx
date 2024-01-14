"use client";

import { getCandidatesByConstituency } from "../../server/GetCandidates";
import { getCurrentUser } from "../../actions/authActionsNoHeaders";

import {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
    CardHeader,
    CardTitle,
  } from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { useEffect, useState } from "react";
import VoteButton from "./VoteButton";

export default function ElectionPage() {
    const [canVote, setCanVote] = useState(false);
    const [candidateData, setCandidateData] = useState<any>([]);
    const [user, setUser] = useState<any>([]);
    const [loading, setLoading] = useState(true);

    console.log(candidateData)

    useEffect(() => {
        setLoading(true);
        getCurrentUser().then((user: any) => {
            setUser(user);
            getCandidatesByConstituency(user.Constituency).then((candidates: any) => {
                setCandidateData(candidates.data.candidates);
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
        {
            canVote ? (
                <>
                <h1 className="text-2xl font-semibold">Vote here for the candidate in your constituency: {user.Constituency}</h1>
                <div>
                    <h2 className="m-5">You are eligible to vote</h2>
                    <h3 className="m-5">Candidates:</h3>
                    <ul>
                        {
                            loading ? (
                                <div>
                                    <h2>Loading...</h2>
                                </div>
                            ) : (
                                candidateData.map((candidate: any) => {
                                    return (
                                        <div key={candidate.id}>
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
                                                    <VoteButton candidateId={candidate.id} />
                                                </CardFooter>
                                            </Card>
                                        </div>
                                    );
                                })
                            )                     
                        }
                    </ul>
                </div>  
                </>
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
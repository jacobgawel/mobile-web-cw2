"use client";
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
    DialogClose,
} from "@/components/ui/dialog"
import { Button } from "@/components/ui/button";
import { useEffect, useState } from "react";
import { getElectionDetails } from "@/app/server/GetElectionDetails";

export default function AdminBoard() {
    const [electionStatus, setElectionStatus] = useState(false);

    useEffect(() => {
        getElectionDetails().then((res) => {
            setElectionStatus(res.data.ongoing);
        })
    }, [])

    console.log(electionStatus)

    return (
        <>
        <div className="text-2xl text-left m-10 font-semibold">Dashboard</div>
        <div className="m-10">
            <Dialog>
                <DialogTrigger asChild>
                    <Button variant="outline">Edit Election Status</Button>
                </DialogTrigger>
                <DialogContent>
                    <DialogHeader>
                        <DialogTitle>Are you absolutely sure?</DialogTitle>
                        <DialogDescription>
                            This will change the status of the election to open or closed.
                        </DialogDescription>

                    </DialogHeader>
                    <DialogFooter>
                        <DialogClose asChild>
                            <Button type="button" variant="secondary">
                                Close
                            </Button>
                        </DialogClose>
                    </DialogFooter>
                </DialogContent>
            </Dialog>
        </div>
        </>
    )
}
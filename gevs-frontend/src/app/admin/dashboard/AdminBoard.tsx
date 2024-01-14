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
import { use, useEffect, useState } from "react";
import { getElectionDetails } from "@/app/server/GetElectionDetails";
import { Badge } from "@/components/ui/badge"
import { electionSwitch } from "@/app/server/ElectionSwitch";
import { toast } from "sonner";
import { Switch } from "@/components/ui/switch"
import { Label } from "@/components/ui/label"
import { Chart } from "react-google-charts";
import { getElectionResult } from "@/app/server/GetElectionResult";

export default function AdminBoard() {
    const [electionStatus, setElectionStatus] = useState(false);
    const [electionResult, setElectionResult] = useState<any>([]);
    const [electionResultStatus, setElectionResultStatus] = useState("");
    const [chartData, setChartData] = useState<any>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getElectionDetails().then((res) => {
            setElectionStatus(res.data.ongoing);
        })
    }, [])

    function toggleElection() {
        const newElectionStatus = !electionStatus;
        setElectionStatus(newElectionStatus);
        electionSwitch(newElectionStatus).then((res) => {
            console.log(res);
        });
        toast.success(newElectionStatus ? "Election opened" : "Election closed");
    }


    function updateChartData(data: any) {
        var tempChartData = [["Party", "Votes", { role: "style" }]];
        data.seats.map((item: any) => {
            tempChartData.push([item.party, Number(item.seat), "#76A7FA"]);
        });

        setChartData(tempChartData);
    }

    useEffect(() => {
        getElectionResult().then((res) => {
            const data = res.data;
            setElectionResult(data);
            updateChartData(data);
            setLoading(false);
        })
    }, []);

    function getUpdatedChartData() {
        getElectionResult().then((res) => {
            const data = res.data;
            console.log(data)
            setElectionResult(data);
            updateChartData(data);
            toast.success("Chart data updated");
            setElectionResultStatus(data.status);
        })
    }

    const optionsColumnChart = {
        title: "Election Results",
    }

    return (
        <>
        <div className="text-2xl text-left m-10 font-semibold">Dashboard</div>
            <Badge variant={"outline"} className="ml-10">Election Status: {electionStatus ? "Open" : "Closed"}</Badge>
            <Badge variant={"outline"} className="ml-2">Election Result: {electionResult.status}</Badge>
        <div className="ml-10 mt-5">
            <Dialog>
                <DialogTrigger asChild>
                    <Button variant="outline">Edit Election Status</Button>
                </DialogTrigger>
                <DialogContent>
                    <DialogHeader>
                        <DialogTitle>Are you absolutely sure?</DialogTitle>
                        <DialogDescription>
                            {electionStatus ? "This will close the election and prevent any further votes from being cast." : "This will open the election and allow votes to be cast."}
                            <br />
                            <Switch className="mt-5" checked={electionStatus} onCheckedChange={toggleElection} />
                            <Label className="ml-5">{electionStatus ? "Election is opened" : "Election is closed"}</Label>
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
        {
            loading ? (
                <div className="text-2xl text-center m-5 font-semibold">Loading...</div>
            ) : (
        <div className="m-10">
            <div className="flex">
                <h2 className="font-semibold">Election Dashboard</h2>
                <Button className="ml-5" variant="outline" onClick={getUpdatedChartData}>Refresh</Button>
            </div>
            <Chart options={optionsColumnChart} chartType="BarChart" width="50%" height="400px" data={chartData} />
        </div>
            )
        }
        </>
    )
}
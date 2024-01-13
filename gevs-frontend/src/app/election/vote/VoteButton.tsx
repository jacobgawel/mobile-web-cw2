"uses client";

import { voteForCandidate } from "../../server/VoteForCandidate";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";

export default function VoteButton(props: any) {
    const { candidateId } = props;

    function vote() {
        voteForCandidate(candidateId).then((response: any) => {
            if (response.status === 400) {
                toast.warning("You have already voted");
            
            }
            else if (response.status === 200) {
                toast.success("You have successfully voted");
            }
        }).catch((error: any) => {
            console.error("Error voting:", error);
        });
    }

    return (
        <Button onClick={vote}>Vote</Button>
    );
}
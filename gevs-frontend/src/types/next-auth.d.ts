import { DefaultSession } from "next-auth";

declare module "next-auth" {
    interface Session  {
        user: {
            username: string,
            sub: string | undefined
            role: string
            birthdate: string
            Constituency: string
            UVC: string
        } & DefaultSession["user"]
    }

    interface Profile {
        username: string
        role: string
        birthdate: string
        Constituency: string
        UVC: string
    }
}

declare module "next-auth/jwt" {
    interface JWT {
        username: string
        birthdate: string
        role: string
        Constituency: string
        UVC: string
    }
}
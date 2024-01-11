export { default } from "next-auth/middleware"

export const config = { 
    matcher: [
        "/election/:path*",
        "/admin/:path*",
    ],
    pages: {
        signIn: "/api/auth/signin"
    }
}
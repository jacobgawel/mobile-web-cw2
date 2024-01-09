import NextAuth, { NextAuthOptions } from 'next-auth';
import DuendeIDS6Provider from "next-auth/providers/duende-identity-server6"

export const authOptions: NextAuthOptions = {
    session: {
        strategy: 'jwt',
    },
    providers: [
        DuendeIDS6Provider({
          id: 'id-server',
          clientId: 'nextApp',
          clientSecret: 'secret',
          issuer: 'http://localhost:8100',
          authorization: {params: {scope: 'openid profile gevsApp'}},
          idToken: true,
        })
    ],
    callbacks: {
        async jwt({token, profile, account, user}) {
            if (profile) {
                token.username = profile.username;
                token.sub = profile.sub;
                token.role = profile.role;
                token.birthdate = profile.birthdate;
                token.Constituency = profile.Constituency;
                token.UVC = profile.UVC;
            }
            return token;
        },
        async session({session, token, user}) {
            if (token) {
                session.user.username = token.username;
                session.user.sub = token.sub;
                session.user.birthdate = token.birthdate;
                session.user.role = token.role;
                session.user.Constituency = token.Constituency;
                session.user.UVC = token.UVC;
            }
            return session;
        }
    }
}
 
const handler = NextAuth(authOptions);

export { handler as GET, handler as POST}
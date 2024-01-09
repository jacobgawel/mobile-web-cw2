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
    ]
}
 
const handler = NextAuth(authOptions);

export { handler as GET, handler as POST}
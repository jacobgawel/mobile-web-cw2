import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import '@/app/globals.css'
import { cn } from "@/lib/utils"
import NavigationBar from '@/components/NavigationBar'

const inter = Inter({ subsets: ['latin'] })

export const metadata: Metadata = {
  title: 'GEVS - Voting Platform',
  description: 'GEVS Voting platform for the Valley of Shangri-La',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en" suppressHydrationWarning>
      <body className={cn("min-h-screen bg-background font-sans antialiased", inter.className)}>
        <NavigationBar />
        {children}
      </body>
    </html>
  )
}

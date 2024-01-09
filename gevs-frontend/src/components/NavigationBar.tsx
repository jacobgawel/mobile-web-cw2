"use client";

import {
    NavigationMenu,
    NavigationMenuContent,
    NavigationMenuIndicator,
    NavigationMenuItem,
    NavigationMenuLink,
    NavigationMenuList,
    NavigationMenuTrigger,
    NavigationMenuViewport,
} from "@/components/ui/navigation-menu"
import { Button } from "@/components/ui/button"
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuGroup,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuPortal,
    DropdownMenuSeparator,
    DropdownMenuShortcut,
    DropdownMenuSub,
    DropdownMenuSubContent,
    DropdownMenuSubTrigger,
    DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import Link from "next/link";
import React from "react";
import { cn } from "@/lib/utils";
import { signIn } from "next-auth/react";
import { getCurrentUser } from "@/app/actions/authActions";

const components: { title: string; href: string; description: string }[] = [
    {
      title: "View Election Details",
      href: "/election-details",
      description:
        "View the details of the election",
    },
    {
      title: "Voting System",
      href: "/vote",
      description:
        "Cast your vote for the election",
    }
]

export default async function NavigationBar() {

  return (
    <>
    <div className='flex justify-center m-1 mr-10'>
    <NavigationMenu>
        <NavigationMenuList>

            <NavigationMenuItem>
              <Link href={"/"}>
                GEVS
              </Link>
            </NavigationMenuItem>

            <NavigationMenuItem>
                <NavigationMenuTrigger>Options</NavigationMenuTrigger>
                <NavigationMenuContent>
                    <ul className="grid w-[400px] gap-3 p-4 md:w-[500px] md:grid-cols-2 lg:w-[600px] ">
                    {components.map((component) => (
                        <ListItem
                        key={component.title}
                        title={component.title}
                        href={component.href}
                        >
                        {component.description}
                        </ListItem>
                    ))}
                    </ul>
                </NavigationMenuContent>
            </NavigationMenuItem>
            <NavigationMenuItem>
                <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                        <Button variant="ghost">Profile</Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent className="w-56">
                        <DropdownMenuLabel>My Account</DropdownMenuLabel>
                        <DropdownMenuSeparator />
                        <DropdownMenuGroup>
                        <DropdownMenuItem>
                          Profile
                        </DropdownMenuItem>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>
                          <Link href={"/session"}>
                                Session
                          </Link> 
                        </DropdownMenuItem>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>
                          Election Dashboard
                        </DropdownMenuItem>
                        </DropdownMenuGroup>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem>
                          Log out
                        </DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <Button variant="ghost" onClick={() => signIn('id-server', {callbackUrl: '/'})}>Login</Button>
            </NavigationMenuItem>
        </NavigationMenuList>
    </NavigationMenu>
    </div>
    </>
  )
}

const ListItem = React.forwardRef<
  React.ElementRef<"a">,
  React.ComponentPropsWithoutRef<"a">
>(({ className, title, children, ...props }, ref) => {
  return (
    <li>
      <NavigationMenuLink asChild>
        <a
          ref={ref}
          className={cn(
            "block select-none space-y-1 rounded-md p-3 leading-none no-underline outline-none transition-colors hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground",
            className
          )}
          {...props}
        >
          <div className="text-sm font-medium leading-none">{title}</div>
          <p className="line-clamp-2 text-sm leading-snug text-muted-foreground">
            {children}
          </p>
        </a>
      </NavigationMenuLink>
    </li>
  )
})

ListItem.displayName = "ListItem"
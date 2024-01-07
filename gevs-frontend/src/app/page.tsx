import Image from 'next/image'
import NavigationBar from '@/components/NavigationBar'

export default function Home() {
  return (
    <>
      <div className='flex justify-center m-1 mr-10'>
        <NavigationBar />
      </div>
    </>
  )
}

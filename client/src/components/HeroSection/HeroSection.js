import React, { useEffect, useState } from 'react'
import fetchData from '../../services/FetchData'


const HeroSection = () => {
    const [data, setData] = useState([])
    const [loading, setLoading] = useState(true)
    useEffect(() => {   
        const apiUrl = 'https://localhost:7249/api/Formula1Season'
        fetchData(apiUrl)
        .then((result) => {
            setData(result);
            setLoading(false);        
        })
        .catch(() => {
            setLoading(false);
        })
    }, [])
    console.log('Data', data);
  return (
    <div>HeroSection</div>
  )
}

export default HeroSection
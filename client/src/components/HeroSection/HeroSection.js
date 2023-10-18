import React, { useEffect, useState } from 'react'
import fetchData from '../../services/FetchData'
import DriverSideBar from '../DriverSideBar/DriverSideBar'
import DriverCharts from '../DriverCharts/DriverCharts'


const HeroSection = () => {
    const [data, setData] = useState([])
    const [loading, setLoading] = useState(true)
    useEffect(() => {   
        const apiUrl = 'https://localhost:7249/api/Driver?season=2020'
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
    <div>
      <DriverSideBar data={data}/>
      <DriverCharts />
    </div>
  )
}

export default HeroSection
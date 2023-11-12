import React, { useEffect, useState } from 'react';
import fetchData from '../../services/FetchData'; 
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';
import classes from './DriverCharts.module.css'

const DriverCharts = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const apiUrl = 'https://localhost:7249/api/TransformedData?season=2020';

    fetchData(apiUrl)  
      .then((response) => {
        setData(response);
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
      });
  }, []);

  return (
    <div className={classes.DriverChartWrapper}>
      <h2>Driver Data Bar Chart</h2>
      <BarChart width={1600} height={400} data={data}>
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="driverId" />
        <YAxis />
        <Tooltip />
        <Legend />
        {data.length > 0 && data.map((driverData, index) => (
          <Bar
            key={index}
            dataKey={`round[${index}]`}
            stackId="a"
            fill={`rgba(${Math.random() * 255},${Math.random() * 255},${Math.random() * 255},0.6)`}
          />
        ))}
      </BarChart>
    </div>
  );
};

export default DriverCharts;

import React, { useEffect, useState } from 'react';
import fetchData from '../../services/FetchData';
import {
    LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend,
  } from 'recharts';

const DriverCharts = () => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const season = 2020;
    const apiUrlBase = 'https://localhost:7249/api/DriverStanding';
    let round = 1;
    const maxRounds = Infinity; // Set an initial value, can be changed as needed

    const fetchDataForRounds = async () => {
      try {
        const allData = [];

        while (round <= maxRounds) {
          const apiUrl = `${apiUrlBase}?season=${season}&round=${round}`;
          const result = await fetchData(apiUrl);

          // Check if the result is empty or has no data
          if (!result || (Array.isArray(result) && result.length === 0)) {
            break; // Exit the loop if there's no more data
          }

          allData.push(result);
          round++;
        }

        setData(allData);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching data:', error);
        setLoading(false);
      }
    };

    fetchDataForRounds();
  }, []);

  console.log('DataCharts', data);

  return (
    <div>
      <div>
        <h2>Driver Points Over Rounds</h2>
        <LineChart width={800} height={400}>
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey="round" />
          <YAxis />
          <Tooltip />
          <Legend />
          {data.map((roundData, roundIndex) => (            
            roundData.map((driverData, driverIndex) => (
              <Line
                key={`${roundIndex}-${driverIndex}`} 
                type="monotone"
                dataKey="points" 
                name={driverData.driverId} 
              />
            )))
        )}
        </LineChart>
      </div>
    </div>
  ); 
            }
  
  export default DriverCharts;

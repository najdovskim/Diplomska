import React from 'react'
import classes from './DriverSideBar.module.css'

function DriverSideBar({data}) {
    console.log(data);
    return (
    <div className={classes.driverContent}>
        <div className={classes.contentWrapper}>            
            <div className={classes.driverSideBar}>
                <div className={classes.driverSideBarWrapper}>
                    {data.map((driver) => {
                    return (
                        <div className={classes.driverCode}> 
                            <h1>{driver.code}</h1>
                        </div>
                    )
                })}
                </div>
            </div>           
         </div>
    </div>
  )
}

export default DriverSideBar
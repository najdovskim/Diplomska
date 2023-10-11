import React from 'react'
import classes from './Navigation.module.css'
import logo from '../../assets/images/f1logo.png'

const Navigation = () => {
  return (
    <div className= {classes.mainContainer}>
        <div className={classes.contentWraper}>
            <div className={classes.imageWrapper}>
            <img src ={logo} height= {60} width={170} alt='formula1'/>

            </div>
        
                <div className={classes.linkWrapper}>
                    <p>
                        Team
                    </p>
                    <p>
                       Race 
                    </p>
                    <p>
                        Driver
                    </p>

            </div>
        </div>
    </div>
  )
}

export default Navigation
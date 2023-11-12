import React from 'react'
import classes from './Navigation.module.css'
import logo from '../../assets/images/f1logo.png'

const Navigation = () => {
  return (
    <div className= {classes.mainContainer}>
        <div className={classes.contentWrapper}>
            <div className={classes.imageWrapper}>
            <img src ={logo} height= {60} width={170} alt='formula1'/>

            </div>
        
                <div className={classes.linkWrapper}>
                    <p>
                        Teams
                    </p>
                    <p>
                       Chart 
                    </p>                  
            </div>
        </div>
    </div>
  )
}

export default Navigation
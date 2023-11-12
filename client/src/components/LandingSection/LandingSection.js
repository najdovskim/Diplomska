import React from 'react'
import classes from "./LandingSection.module.css"
import BottomMiddleSection from '../BottomMiddleSection/BottomMiddleSection'

const LandingSection = () => {
  return (
    <div className={classes.mainContainer}>

        <div className={classes.contentWrapper}>
        <div className={classes.sectionWrapper}>

            <div className={classes.textWrapper}>
            <h1>
            Formula 1
            </h1>
            <p>
            Formula 1 (F1) is the premier form of open-wheel auto racing featuring high-speed, technologically advanced cars. 
            It's a global championship with multiple teams and drivers, known for its complex regulations, iconic races, and passionate fanbase. 
            F1 cars can exceed 200 mph, and the sport leads in automotive technology.
            </p>

            <button onClick={BottomMiddleSection}  className={classes.formulaButton}>Discover More</button>
            </div>
            </div>
                    </div>

    </div>
  )
}

export default LandingSection
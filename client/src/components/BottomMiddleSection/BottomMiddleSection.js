import React from 'react'
import classes from "./BottomMiddleSection.module.css"
function BottomMiddleSection() {
  return (
        <div className={classes.mainContainer}>
            <div className={classes.contentWrapper}>
                <div className={classes.firstTextSection}>
                        <h1 className={classes.firstItem}>
                        Historic Legacy: Formula 1 has a rich history with legendary drivers and moments that have shaped its legacy.
                        </h1>

                        <h1 className={classes.secondItem}>
                        Passionate Fanbase: The sport has a global and passionate fanbase, with millions of viewers worldwide.
                        </h1>
                </div>


                <div className={classes.secondTextSection}>
                            <h1 className={classes.thirdItem}>
                            Passionate Fanbase: The sport has a global and passionate fanbase, with millions of viewers worldwide.
                            </h1>

                            <button className={classes.button}>
                                    See charts
                            </button>
                </div>
            </div>
        </div>
  ) 
}

export default BottomMiddleSection
import React from 'react'
import classes from "./FormulaLogoSection.module.css"
import formulaData from './FormulaData'

const FormulaLogoSection = () => {
  return (
    <div className={classes.TitleWrapper}>
        <h1>
            Teams
        </h1>
         <div className={classes.heroWrapper}>
        <div className={classes.contentWrapper}>
                <div className={classes.GridContainer}>
                {formulaData.map((formula) => {
                return (
                    <div className={classes.imgContainer} key={formula.id}>
                        <img src={formula.img}/>
                    </div>
                )
            })}
                </div>
        </div>
   </div>
    </div>
  
  )
}

export default FormulaLogoSection
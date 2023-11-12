import React from 'react'
import classes from "./MiddleSection.module.css"

const MiddleSection = () => {

    const forumlaTextData = [
        {
            id: 0,
            text: 'High-Performance Cars: Formula 1 cars are engineered for speed and performance, featuring advanced aerodynamics, powerful engines, and cutting-edge technology.'
        },
        {
            id: 1,
            text: 'Global Championship: Formula 1 is a worldwide championship with races held in various countries, forming a competitive season.'
        },
            
        {
            id: 2,
            text: 'Teams and Drivers: Multiple teams with one or two drivers each compete in Formula 1. The drivers represent their teams in races.'
        },
        {
            id: 3,
            text: 'Points System: Formula 1 has a points system, where drivers and teams earn points based on their performance in each race. These points determine the championship standings.'
        },
    ]
  return (
    <div className={classes.heroContainer}>
        <div className={classes.contentWrapper}>
            <div className={classes.middleContainer}>
                <h1 className={classes.Heading}>Exciting things about Formula 1</h1>
                    <div className={classes.gridContainer}>
                        {forumlaTextData.map((item) => {
                            return (
                                <div className={classes.gridItem} id={item.id}>
                                    <h3 className={`${item.id === 1 ? classes.gridItemBorder
                                    : classes.gridItem }`}>{item.text}</h3>
                                </div>
                            )
                        })}
                    </div>
{/* 
                    <div className={classes.styledHorizontalContainer}> */}
                        <hr className={classes.stylesHorizontalLine}/>
                    {/* </div> */}
            </div>
        </div>
    </div>
  )
}

export default MiddleSection
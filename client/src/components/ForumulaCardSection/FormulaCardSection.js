import React from "react";
import classes from "./FormulaCardSection.module.css";
import FormulaCard from "./FormulaCard/FormulaCard";
import formulaCardFirstImage from "../../assets/images/2pic.jpg";
import formulaCardSecondImage from "../../assets/images/skysports-mclaren-f1_4261836.jpg"
import formulaCardThirdImage from "../../assets/images/aston1.png"
import formulaCardFourthImage from "../../assets/images/prost480x480.webp"
import formulaCardFifthImage from "../../assets/images/Michael-Schumacher-Mika-Hakkinen-Monza-1998.webp"


const FormulaCardSection = () => {
  return (
    <div className={classes.heroContainer}>
          <div className={classes.contentWrapper}>
          <div className={classes.singleWrapper}>
            <FormulaCard
            formulaCardColor={classes.forumlaCardRed}
            imgClassName={classes.imgClassAlone}
            className={classes.FormulaCardContainer}
            title={"Hamilton vs. Rosberg: "}
            image={formulaCardFirstImage}
            description={"Lewis Hamilton and Nico Rosberg's rivalry at Mercedes from 2013 to 2016 led to intense on-track battles and competition for the championship."}
          />
            </div>
      
        <div className={classes.multipleCardsWrapper}>
         
            <FormulaCard
            formulaCardColor={classes.forumlaCardWhite}
            className={classes.FormulaCardContainer2}
            title={"Schumacher vs. Hakkinen:"}
            imgClassName={classes.imgClass}
            image={formulaCardFifthImage}
            description={"Michael Schumacher and Mika Häkkinen had a fierce rivalry in the late 1990s, both racing for top teams and battling for championships."}
          />
           
            <FormulaCard
            formulaCardColor={classes.forumlaCardWhite}
            className={classes.FormulaCardContainer2}
            title={"Senna vs. Prost:"}
            imgClassName={classes.imgClass}
            image={formulaCardFourthImage}
            description={"Ayrton Senna and Alain Prost, two Formula 1 legends, engaged in a fierce rivalry in the late 1980s and early 1990s. They drove for different teams, exhibited contrasting driving styles, and battled intensely for championship titles."}
          />
      
        </div>
          </div>
    </div>
  );
};

export default FormulaCardSection;

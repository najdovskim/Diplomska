import React from "react";
import classes from "./FormulaCard.module.css";

const FormulaCard = ({ image, title, description, className,imgClassName, formulaCardColor }) => {


  return (
    <div className={className}>   
      <div className={classes.FormulaImgContainer}>
        <img className={imgClassName} src={image} />
      </div>
      <div className={formulaCardColor}>
        <h3 className={classes.formulaTitle}>{title}</h3>
        <p className={classes.formulaDescription}>{description}</p>
      </div>
    </div>
  );
};

export default FormulaCard;

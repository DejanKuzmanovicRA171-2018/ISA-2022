import React from "react";
const RadioButtonInput = ({ name, label, value, ...rest }) => {
  return (
    <div className="form-group">
      <label htmlFor={name}>{label}</label>
      <input {...rest} value={value} name={name} id={value} type={"radio"} />
    </div>
  );
};

export default RadioButtonInput;

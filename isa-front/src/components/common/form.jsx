import React, { Component } from "react";
import Joi from "joi-browser";
import Input from "./input";
import Select from "./select";
import RadioButtonInput from "./radioButtonInput";

class Form extends Component {
  state = {
    data: {},

    errors: {},
  };

  validate = () => {
    const options = { abortEarly: false };
    const { error } = Joi.validate(this.state.data, this.schema, options);
    if (!error) return null;

    const errors = {};
    for (let item of error.details) errors[item.path[0]] = item.message;
    console.log("ERROR");
    return errors;
  };
  validateProperty = ({ name, value }) => {
    const obj = { [name]: value };
    const schema = { [name]: this.schema[name] };
    const { error } = Joi.validate(obj, schema);
    return error ? error.details[0].message : null;
  };
  handleSubmit = (e) => {
    e.preventDefault();

    const errors = this.validate();
    this.setState({ errors: errors || {} });
    if (errors) return;

    this.doSubmit();
  };
  handleChange = ({ currentTarget: input }) => {
    const errors = { ...this.state.errors };
    const errorMessage = this.validateProperty(input);
    if (errorMessage) errors[input.name] = errorMessage;
    else delete errors[input.name];

    const data = { ...this.state.data };
    data[input.name] = input.value;

    this.setState({ data, errors });
  };

  renderButton(label) {
    return (
      <button disabled={this.validate()} className="btn btn-primary">
        {label}
      </button>
    );
  }
  renderSelect(name, label, options) {
    const { data, errors } = this.state;
    return (
      <Select
        name={name}
        value={data[name]}
        label={label}
        options={options}
        onChange={this.handleChange}
        error={errors[name]}
      />
    );
  }
  renderInput(name, label, type = "text") {
    const { data, errors } = this.state;

    return (
      <Input
        type={type}
        name={name}
        value={data[name]}
        label={label}
        onChange={this.handleChange}
        error={errors[name]}
      />
    );
  }
  renderSurvery() {
    return (
      <table className="form-control">
        <thead>
          <tr>
            <th>Select one of the options</th>
            <th>Yes</th>
            <th>No</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Da li ste ikada davali krv</td>
            <td>{this.renderInputRadioButton("question1", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question1", "", "no")}</td>
          </tr>
          <tr>
            <td>Da li ste ikada bili odbijeni kao davalac krvi</td>
            <td>{this.renderInputRadioButton("question2", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question2", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li se trenutno osecate zdravim, sposobnim i odmornim da date
              krv ili komponente krvi?
            </td>
            <td>{this.renderInputRadioButton("question3", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question3", "", "no")}</td>
          </tr>
          <tr>
            <td>Da li redovno(svakodnevno) uzimate bilo kakvu vrstu lekova?</td>
            <td>{this.renderInputRadioButton("question4", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question4", "", "no")}</td>
          </tr>
          <tr>
            <td>Da li ste vadili zub u proteklih 7 dana?</td>
            <td>{this.renderInputRadioButton("question5", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question5", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste u poslednjih 7 do 10 dana imali temperaturu preko
              38°,kijavicu,prehladu ili uzimali antibiotike?{" "}
            </td>
            <td>{this.renderInputRadioButton("question6", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question6", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste primili bilo koju vakcinu ili serum u proteklih 12
              meseci?
            </td>
            <td>{this.renderInputRadioButton("question7", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question7", "", "no")}</td>
          </tr>
          <tr>
            <td>Da li ste u poslednjih 6 meseci naglo izgubili na tezini?</td>
            <td>{this.renderInputRadioButton("question8", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question8", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste imali ubode krpelja u proteklih 12 meseci i da li ste se
              zbog toga javljali lekaru?
            </td>
            <td>{this.renderInputRadioButton("question9", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question9", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste se ikada lecili od epilepsije,secerne
              bolesti,astme,tuberkoloze,infarkta,mozdanog udara,malignih
              oboljenja,mentalnih bolesti ili malarije?
            </td>
            <td>{this.renderInputRadioButton("question10", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question10", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li bolujete od neke hronicne bolesti:
              srca,pluca,bubrega,jetre,zeluca i creva,kostiju zglobova,nervnog
              sistema,krvi i krvnih sudova?
            </td>
            <td>{this.renderInputRadioButton("question11", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question11", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste ikada imali problema sa stitasom zlezdom,hipofizom i/ili
              primali hormone?
            </td>
            <td>{this.renderInputRadioButton("question12", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question12", "", "no")}</td>
          </tr>
          <tr>
            <td>Da li imate neke promene na kozi ili bolujete od alergije?</td>
            <td>{this.renderInputRadioButton("question13", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question13", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li dugo krvarite posle povrede ili spontano dobijate modrice?
            </td>
            <td>{this.renderInputRadioButton("question14", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question14", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste u proteklih 6 meseci imali neku operaciju ili primili
              krv?
            </td>
            <td>{this.renderInputRadioButton("question15", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question15", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste u proteklih 6 meseci imali akupunkturu,pirsing ili
              tetovazu?
            </td>
            <td>{this.renderInputRadioButton("question16", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question16", "", "no")}</td>
          </tr>
          <tr>
            <td>Da li ste bolovali ili bolujete od xepatitisa A,B ili C?</td>
            <td>{this.renderInputRadioButton("question17", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question17", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste bili u kontaktu ili zivite sa osobom obolelom od
              hepatitisa?
            </td>
            <td>{this.renderInputRadioButton("question18", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question18", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste ikada koristili preparate koji se zvanicno ne izdaju na
              recept i/ili preparate za bodi bilding(steroide)?
            </td>
            <td>{this.renderInputRadioButton("question19", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question19", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste imali seksualne odnose tokom proteklih 6 meseci bez
              zastite sa osobom koja je HIV pozitivna?
            </td>
            <td>{this.renderInputRadioButton("question20", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question20", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste imali seksualne odnose tokom proteklih 6 meseci bez
              zastite sa osobom koja ima ili je imala hepatitis B ili C?
            </td>
            <td>{this.renderInputRadioButton("question21", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question21", "", "no")}</td>
          </tr>

          <tr>
            <td>Da li ste u drugom stanju?</td>
            <td>{this.renderInputRadioButton("question22", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question22", "", "no")}</td>
          </tr>
          <tr>
            <td>
              Da li ste u poslednjih 6 meseci imali porodjaj ili prekid
              trudnoce?
            </td>
            <td>{this.renderInputRadioButton("question23", "", "yes")}</td>
            <td>{this.renderInputRadioButton("question23", "", "no")}</td>
          </tr>
        </tbody>
      </table>
    );
  }

  renderInputRadioButton(name, label, value, type = "radio") {
    return (
      <RadioButtonInput
        type={type}
        name={name}
        value={value}
        label={label}
        onChange={this.handleChange}
        checked={this.state.data[name] === value}
      />
    );
  }
}

export default Form;

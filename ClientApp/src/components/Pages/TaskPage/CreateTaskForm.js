import React, { Component } from 'react';
import PropTypes from 'prop-types';

class CreateTaskForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: '',
            description: '',
        };

        this._handleInputChange = this._handleInputChange.bind(this);
        this._handleSubmit = this._handleSubmit.bind(this);
    }

    _handleSubmit(e) {
        e.preventDefault();
        const {name, description} = this.state;
        if (name && description) {
            this.props._createTask(this.state);
        }
    }

    _handleInputChange(event) {
        const {name, value} = event.target;
        this.setState({
            [name]: value
        });
    }
    

    render() {
        const {name, description} = this.state;
        return (
            <form>
                <div className="form-group">
                    <label htmlFor="taskName">Task name:</label>
                    <input type="text"
                        className="form-control"
                        name="name"
                        id="taskName"
                        value={this.state.name}
                        onChange={this._handleInputChange}
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="taskDescription">Task description:</label>
                    <input type="text"
                        name="description"
                        className="form-control"
                        id="taskDescription"
                        value={this.state.description}
                        onChange={this._handleInputChange}
                    />
                </div>
                <button disabled={!name || !description} onClick={this._handleSubmit} type="submit" className="btn btn-success">Submit</button>
            </form>
        );
    }
};

CreateTaskForm.propTypes = {
    _createTask: PropTypes.func
};

export default CreateTaskForm;
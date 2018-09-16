import React, { Component } from 'react';
import PropTypes from 'prop-types';

class UpdateTaskForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: props.name,
            description: props.description,
        };

        this._handleInputChange = this._handleInputChange.bind(this);
        this._handleSubmit = this._handleSubmit.bind(this);
        this._updateTask = props._updateTask;
    }

    _handleSubmit(e) {
        e.preventDefault();
        const {name, description} = this.state;
        if (name && description) {
            this._updateTask({...this.state, id: this.props.id});
        }
    }

    _handleInputChange(event) {
        const {name, value} = event.target;
        this.setState({
            [name]: value
        });
    }

    render() {
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
                <button disabled={!this.state.description || !this.state.name} onClick={this._handleSubmit} type="submit" className="btn btn-success">Submit</button>
            </form>
        );
    }
};

UpdateTaskForm.propTypes = {
    id: PropTypes.number,
    name: PropTypes.string,
    description: PropTypes.string,
    _updateTask: PropTypes.func,
};

export default UpdateTaskForm;
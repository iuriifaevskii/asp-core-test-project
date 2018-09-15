import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

class TaskList extends Component {
    _handleClick = (item) => this.props._removeTask(item.id);

    render() {
        const { tasks } = this.props;
        const tasksItems = tasks.map((item) =>
            <li key={item.id}>
                {item.name} <Link to={`/task/${item.id}`}>read more</Link>
                <button onClick={this._handleClick.bind(this, item)} className='btn btn-danger'>remove</button>
            </li>
        );
        return (
            <ul>
                {tasksItems}
            </ul>
        );
    }
};

TaskList.propTypes = {
    tasks: PropTypes.array,
    _removeTask: PropTypes.func
};

export default TaskList;
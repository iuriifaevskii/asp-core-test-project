import React from 'react';
import { Link } from 'react-router-dom';

function TaskList(props) {
    const { tasks } = props;
    const tasksItems = tasks.map((item) =>
        <li key={item.id}>
            {item.name} <Link to={`/task/${item.id}`}>read more</Link>
        </li>
    );
    return (
        <ul>
            {tasksItems}
        </ul>
    );
}

export default TaskList;
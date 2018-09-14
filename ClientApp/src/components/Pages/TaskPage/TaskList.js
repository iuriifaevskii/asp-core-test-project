import React from 'react';

function TaskList(props) {console.log(props)
    const { tasks } = props;
    const tasksItems = tasks.map((item) =>
        <li key={item.id}>{item.name}</li>
    );
    return (
        <ul>
            {tasksItems}    
        </ul>
    );
}

export default TaskList;
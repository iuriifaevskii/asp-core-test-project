import React from 'react';

function SingleTaskView(props) {
    const { task } = props;
    return (
        <div>
            {task ?
                <ul>
                    <li>{task.name}</li>
                    <li>{task.description}</li>
                </ul>
                :
                <div>No items with that id</div>
            }
        </div>
    )
}

export default SingleTaskView;
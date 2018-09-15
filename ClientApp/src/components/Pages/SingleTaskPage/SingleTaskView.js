import React from 'react';
import PropTypes from 'prop-types';

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
    );
};

SingleTaskView.propTypes = {
    task: PropTypes.object
};

export default SingleTaskView;
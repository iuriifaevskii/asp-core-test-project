import React, { Component } from 'react';
import axios from 'axios';
import TaskList from './TaskList';

const tasks = [
    { id: 1, name: 'make review' },
    { id: 2, name: 'clean a room'}
];

class TaskPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            taskList: []
        }
    }

    componentDidMount() {
        this.getTasks();
    }

    getTasks() {
        return axios.get('http://localhost:51929/api/Task/getAll')
            .then(responseJson => this.setState({taskList: responseJson.data}));
    }
    
    render() {
        return (
            <div>
                <TaskList
                    tasks={this.state.taskList}
                />
            </div>
        );
    }
}

export default TaskPage;
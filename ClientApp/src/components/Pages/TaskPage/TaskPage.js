import React, { Component } from 'react';
import axios from 'axios';
import TaskList from './TaskList';
import CreateTaskForm from './CreateTaskForm';

class TaskPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            taskList: []
        };

        this._getTasks = this._getTasks.bind(this);
        this._removeTask = this._removeTask.bind(this);
        this._createTask = this._createTask.bind(this);
    }

    componentDidMount() {
        this._getTasks();
    }

    _getTasks() {
        return axios.get('http://localhost:51929/api/Task/getAll')
            .then(responseJson => this.setState({taskList: responseJson.data}));
    }

    _removeTask(id) {
        return axios.delete(`http://localhost:51929/api/Task/removeOne/${id}`)
            .then(responseJson => {
                const taskArray = this.state.taskList.filter(item => item.id !== id);
                this.setState({
                    taskList: [...taskArray]
                });
            })
            .then(() => alert('removed successfully'))
            .catch(e => alert('error in removeTask!'));
    }

    _createTask(task) {
        return axios.post('http://localhost:51929/api/Task/createTask', task)
            .then(responseJson => {
                const taskList = [...this.state.taskList];
                taskList.push(responseJson.data);
                this.setState({taskList});
            })
            .then(() => alert('created successfully'))
            .catch(e => alert('error in createTask!'));
    }

    render() {
        return (
            <div className="row">
                <div className="col-sm-6">
                    <h1>Task List</h1>
                    <TaskList
                        tasks={this.state.taskList}
                        _removeTask={this._removeTask}
                    />
                </div>
                <div className="col-sm-6">
                    <h1>Create task</h1>
                    <CreateTaskForm
                        _createTask={this._createTask}
                    />
                </div>
            </div>
        );
    }
}

export default TaskPage;
import React, {Component} from 'react';
import axios from 'axios';

import SingleTaskView from './SingleTaskView';
import UpdateTaskForm from './UpdateTaskForm';

class SingleTaskPage extends Component {
    constructor(props) {
        super(props);
        
        this.state = {
            singleTask: {
                id: null,
                name: '',
                description: ''
            }
        }

        this._updateTask = this._updateTask.bind(this);
    }

    componentDidMount() {
        const { id } = this.props.match.params;
        this._getSingleTask(id);
    }

    _updateTask(task) {
        return axios.put(`http://localhost:51929/api/Task/updateOne`, task)
            .then(responseJson => {
                this.setState({ ...this.state, singleTask: {...responseJson.data}})
            });
    }

    _getSingleTask(id) {
        return axios.get(`http://localhost:51929/api/Task/getOne/${id}`)
            .then(responseJson => {
                this.setState({ ...this.state, singleTask: {...responseJson.data}})
            })
    }

    render() {
        return (
            <div className="row">
                <div className="col-sm-6">
                    <h1>Single task</h1>
                    {this.state.singleTask.id
                    ? <SingleTaskView
                        task={this.state.singleTask} 
                    />
                    : <div />}
                </div>
                <div className="col-sm-6">
                    <h1>Update task</h1>
                    {
                        this.state.singleTask.name!=='' && this.state.singleTask.description
                        ?
                        <UpdateTaskForm
                            id={this.state.singleTask.id}
                            name={this.state.singleTask.name}
                            description={this.state.singleTask.description}
                            _updateTask={this._updateTask}
                        />
                        :
                        <div />
                    }
                </div>
            </div>
        );
    }
};

export default SingleTaskPage;
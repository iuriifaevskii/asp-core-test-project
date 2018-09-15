import React, {Component} from 'react';
import axios from 'axios';

import SingleTaskView from './SingleTaskView';

class SingleTaskPage extends Component {
    constructor(props) {
        super(props);
        
        this.state = {
            singleTask: {},
        }
    }

    componentDidMount() {
        const { id } = this.props.match.params;
        this._getSingleTask(id);
    }

    _getSingleTask(id) {
        return axios.get(`http://localhost:51929/api/Task/getOne/${id}`)
            .then(responseJson => this.setState({singleTask: responseJson.data}))
    }

    render() {
        const { singleTask } = this.state;
        return (
            <div>
                <SingleTaskView
                    task={singleTask} 
                />
            </div>
        );
    }
}

export default SingleTaskPage;
import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

export class Shop extends Component
{
    constructor(props){
        super(props);
        this.state={deps:[]}
    }

    refreshList(){
        fetch('https://localhost:44337/api/shop')
        .then(response=>response.json())
        .then(data=>{
            this.setState({deps:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    render(){
        const {deps}=this.state;
        return(
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Price with Discount</th>
                            <th>Brend</th>
                            <th>Release year</th>
                            <th>Size</th>
                            <th>Model</th>
                        </tr>
                    </thead>
                    <tbody>
                        {deps.map(dep=>
                            <tr key={dep.id}>
                                <td>{dep.id}</td>
                                <td>{dep.name}</td>
                                <td>{dep.price}</td>
                                <td>{dep.price_with_discount}</td>
                                <td>{dep.brend}</td>
                                <td>{dep.release_year}</td>
                                <td>{dep.size}</td>
                                <td>{dep.model}</td>
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}

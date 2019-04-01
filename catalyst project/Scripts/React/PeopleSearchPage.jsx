function PeopleSearchPage(props) {
    let [state, updateState] = React.useState({
        loadingResults: false,
        searchPerformed: false
    });

    function enterPressed(evt) {
        if (evt.key == 'Enter') {
            searchClicked(evt)
        }
    }

    function searchClicked(evt) {        
        updateState(prevState => ({
            ...prevState,
            loadingResults: true
        }));

        var searchText = $('#searchInput').val()
        axios.get("/api/people/" + searchText).then(response => {
            console.log(response.data);
            updateState(prevState => ({
                ...prevState,
                personList: response.data,
                loadingResults: false,
                searchPerformed: true
            }));
        });
        evt.preventDefault();
    }

    function renderPersonList() {
        if (state.loadingResults) {
            return <div>Loading search results, please wait...</div>
        }
        else if (state.searchPerformed && state.personList.length > 0) {
            let personNodes = state.personList.map(person => (
                <Person Name={person.Name} Age={person.Age} Address={person.Address} Interests={person.Interests} ImagePath={person.ImagePath}></Person>
            ));
            return <div className="searchResults">
                    <h2>Search Matches</h2>
                    <table>
                        <tr><th>Name</th><th>Age</th><th>Address</th><th>Interests</th><th>Picture</th></tr>
                        {personNodes}
                    </table>
                </div>;
        }
        else if (state.searchPerformed && state.personList.length == 0) {
            return <div>No search results found</div>
        }
        else return "";
    }

    return (
        <div className="people">
            <h1>People</h1>
            <input type="text" id="searchInput" onKeyPress={enterPressed}></input>
            <button onClick={searchClicked}>Submit</button>
            {renderPersonList()}
            <hr />
        </div>
    );
}

class Person extends React.Component {
    render() {
        return (
            <tr>
                <th>
                    <strong>{this.props.Name}</strong>
                </th>
                <th>
                    {this.props.Age}
                </th>
                <th>
                    {this.props.Address}
                </th>
                <th>
                    {this.props.Interests}
                </th>
                <th>
                    <img src={this.props.ImagePath}/>
                </th>
            </tr>
        );
    }
}

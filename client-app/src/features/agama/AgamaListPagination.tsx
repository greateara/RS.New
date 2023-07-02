import { observer } from "mobx-react-lite";
import ReactPaginate from "react-paginate";
import { useStore } from "../../app/stores/Store";
import { Button, Dropdown, Grid, Input, Menu, Table } from "semantic-ui-react";
import { useEffect, useRef, useState } from "react";


export default observer(function AgamaListPagination() {
    const { agamaStore } = useStore()
    const { setPaginationSearch, setPaginationCount, setPaginationSkip, setPaginationNumOfRows } = agamaStore
    const { paginationSearch, paginationCount, paginationSkip, paginationNumOfRows } = agamaStore
    const { agamaRowsSortKodePage } = agamaStore
    // const [paginationSearch, setPaginationSearch] = useState('~')
    // const [paginationSkip, setPaginationSkip] = useState(0)
    // const [paginationCount, setPaginationCount] = useState(0)
    // const [paginationSelect, setPaginationSelect] = useState(1)
    // const [paginationNumOfRows, setPaginationNumOfRows] = useState(2)

    // const { agamaStore } = useStore()
    // const { agamaRowsSortKodePage, agamaRowsPage, agamaRows } = agamaStore
    // // const { setPaginationSearch, setPaginationCount, setPaginationSelect, setPaginationSkip } = agamaStore
    // const { paginationSearch, paginationCount, paginationSelect, paginationSkip } = agamaStore

    const [pgNumOfRows, setPgNumOfRows] = useState(10)

    const inputRef = useRef(null);
    const dropdownRef = useRef(null);


    const handlePageSelect = (data: any) => {
        console.log('select')
        // setPaginationSelect(data.selected + 1)

        // console.log(data);
        // // console.log(agamaRowsPage);
        // // console.log(agamaRows.size);
        // // console.log(agamaRowsPage.size)
        // console.log('before', paginationCount, paginationSearch, paginationSelect, paginationSkip)
        // setPaginationSelect(data.selected);
        // //perhatikan nilai seleted dimulai dari nol
        // console.log('after', paginationCount, paginationSearch, paginationSelect, paginationSkip)
    };

    // const handleSearch = (data: any) => {
    //     console.log(data);
    //     setPaginationSearch(data.value)
    // }

    const handleInputChange = (event: any) => {
        setPaginationSearch(event.target.value)
        agamaStore.loadAgamasFilter();

        // const inputValue = event.target.value;
        // console.log('Input Value:', event.target.value);
    };

    const handleDropdownChange = (event: any, data: any) => {
        // const dropdownValue = event.target.value;
        // console.log('Dropdown Value:', event);
        // console.log(data.value)
        // setPaginationNumOfRows(data.value)
        setPgNumOfRows(data.value)
        // console.log(pgNumOfRows)
    };

    const options = [
        { key: '~', text: '~', value: 0 },
        { key: '10', text: '10', value: 10 },
        { key: '50', text: '50', value: 50 },
        { key: '100', text: '100', value: 100 },
    ]

    useEffect(() => {
        console.log('num of rows', pgNumOfRows)
        console.log('search', paginationSearch)
        console.log('effect sr c s nr', paginationSearch, paginationCount, paginationSkip, paginationNumOfRows)
        // agamaStore.loadAgamasPage('a', 3, 2)
        // agamaStore.loadAgamasPage(paginationSearch, paginationNumOfRows, paginationSkip)
        // setPaginationCount(agamaRowsPage.size)
        // console.log('Select Count Skip', paginationSelect, paginationCount, paginationSkip)
        // console.log('row', agamaRowsPage)
        console.log(agamaRowsSortKodePage)
    }, [pgNumOfRows, paginationSearch])

    // console.log(agamaRowsPage)

    return (
        <>

            <Table className="ui compact table striped">
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.HeaderCell>Kode</Table.HeaderCell>
                        <Table.HeaderCell>Uraian</Table.HeaderCell>
                        {/* <Table.HeaderCell>TimeStamp</Table.HeaderCell> */}
                        <Table.HeaderCell>Deleted</Table.HeaderCell>
                        <Table.HeaderCell>Action</Table.HeaderCell>
                    </Table.Row>
                </Table.Header >

                <Table.Body>
                    {agamaRowsSortKodePage.map((agama: any) => (

                        <Table.Row key={agama.id}>
                            <Table.Cell>
                                {/* <Button > */}
                                {agama.id.substring(0, 7).toUpperCase()}
                                {/* </Button> */}
                            </Table.Cell>
                            <Table.Cell>{agama.kode}</Table.Cell>
                            <Table.Cell>{agama.uraian}</Table.Cell>
                            {/* <Table.Cell>{agama.timeStamp}</Table.Cell> */}
                            <Table.Cell>{agama.deleted}</Table.Cell>
                            <Table.Cell>
                                <Button.Group>
                                    <Button compact size='mini' positive
                                        onClick={() => agamaStore.selectAgama(agama.id)}>Pick</Button>
                                    <Button.Or />
                                    <Button
                                        // name={agama.id} loading={loading && target === agama.id}
                                        size='mini' negative
                                    // onClick={(e) => handleDeleteItem(e, agama.id, agama.timeStamp)}
                                    >Del</Button>
                                </Button.Group>
                                {/* <Button as='a' onClick={() => deleteItem(agama.id)}>Del</Button> */}
                            </Table.Cell>
                        </Table.Row>
                    ))}
                </Table.Body>
            </Table >

            <Grid columns={2} relaxed='very'>
                <Grid.Column>
                    <Input
                        ref={inputRef}
                        onChange={handleInputChange}
                        label={<Dropdown defaultValue='All' options={options}
                            ref={dropdownRef} onChange={handleDropdownChange}
                        />}
                        labelPosition='right'
                        placeholder='Criteria'
                    />
                </Grid.Column>
                <Grid.Column>
                    <ReactPaginate
                        breakLabel="..."
                        nextLabel=">>"
                        onPageChange={handlePageSelect}
                        pageRangeDisplayed={10}
                        pageCount={10}
                        previousLabel="<<"
                        renderOnZeroPageCount={null}

                        containerClassName="pagination navigation"
                        // pageClassName="page-page"
                        pageLinkClassName="page-num"
                        previousClassName="page-num"
                        nextClassName="page-num"
                        activeClassName="active"
                    />
                </Grid.Column>

            </Grid>
        </>
    );
}
)

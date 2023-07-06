import { observer } from "mobx-react-lite";
import ReactPaginate from "react-paginate";
import { useStore } from "../../app/stores/Store";
import { Button, Dropdown, Grid, Header, Icon, Input, Label, Table } from "semantic-ui-react";
import { useEffect, useRef, useState } from "react";
import { AgamaAPI } from "../../app/models/AgamaAPI";

export default observer(function AgamaListPagination() {
    const { agamaStore } = useStore()
    const { setPaginationSearch,
        pgCount, setPgItemPerPage, pgNumOfColumn, setPgNumOfColumn,
        pgSelected, setPgSelected, pgSkip, setPgSkip
    } = agamaStore
    const { paginationSearch, agamaFilter,
        pgItemPerPage
    } = agamaStore

    const { agamaRowsSortKodePage } = agamaStore
    const [currentItems, setCurrentItems] = useState<AgamaAPI[]>([])
    const [ItemOffSet, setItemOffSet] = useState(0)

    const inputRef = useRef(null);
    const dropdownRef = useRef(null);


    const handlePageSelect = (data: any) => {
        console.log('select', data)
        setPgSelected(data.selected)
        setPgSkip(data.selected * pgItemPerPage)

    };

    const handleInputChange = (event: any) => {
        setPaginationSearch(event.target.value)
        agamaStore.loadAgamasFilter();
    };

    const handleDropdownChange = (event: any, data: any) => {
        // setPgNumOfRows(data.value)
        setPgItemPerPage(data.value);
        setPgNumOfColumn();

    };

    const options = [
        // { key: '~', text: '~', value: 0 },
        { key: '1', text: '1', value: 1 },
        { key: '2', text: '2', value: 2 },
        { key: '10', text: '10', value: 10 },
        { key: '50', text: '50', value: 50 },
        { key: '100', text: '100', value: 100 },
        { key: '500', text: '500', value: 500 },
    ]

    useEffect(() => {
        const agamaArray: AgamaAPI[] = Array.from(agamaFilter.values());
        const slicedArray: AgamaAPI[] = agamaArray.slice(pgSkip, pgItemPerPage + pgSkip);
        setCurrentItems(slicedArray)

        console.log('pgCount', pgCount)
        console.log('pgSelect', pgSelected)
        console.log('agama-filter',agamaFilter)
        console.log('agama-array',agamaArray)
    }, [agamaFilter, pgItemPerPage, pgSkip, pgCount, pgSelected])


    return (
        <>
            
            <label>
                Count {pgCount}, 
                Search {paginationSearch}
                ItemPerPage {pgItemPerPage} //
                NumOfColumn {pgNumOfColumn} //
                Selected {pgSelected}  //
                Skip {pgSkip}
            </label>
            

            <Header className="ui center aligned header black" as='h1'>
                ==|  LIST  Uji Coba |==
                <Label as='a' color="red" corner onClick={() => agamaStore.openForm()}>
                    <Icon name='add' />
                </Label>

            </Header>
            <hr color="red"></hr>
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
                    {currentItems.map((agama: any) => (
                        // {agamaRowsSortKodePage.map((agama: any) => (

                        <Table.Row key={agama.id}>
                            <Table.Cell>
                                {/* <Button > */}
                                {/* {agama.id.substring(0, 7).toUpperCase()} */}
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
                        label={<Dropdown defaultValue={10} options={options}
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
                        pageRangeDisplayed={2}
                        pageCount={pgNumOfColumn}
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

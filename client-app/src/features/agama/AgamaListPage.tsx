import { SyntheticEvent, useState } from "react";
import { useStore } from "../../app/stores/Store";
import { Button, Header, Icon, Label, Table } from "semantic-ui-react";
import { observer } from "mobx-react-lite";

// interface Props {
//     agamas: AgamaAPI[];
//     // selectAgama: (id: string) => void;
//     // openForm: () => void;
//     deleteItem: (id: string, timeStamp: string) => void;
//     submitting: boolean
// }
export default observer(function AgamaListPage() {

    const { agamaStore } = useStore()
    const {deleteAgama, agamaRowsSortKode, loading} = agamaStore
    const [target, setTarget] = useState('')

    function handleDeleteItem(e: SyntheticEvent<HTMLButtonElement>, id: string, timeStamp: string) {
        setTarget(e.currentTarget.name)
        deleteAgama(id, timeStamp)
    }

    return (
        <>
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
                    {agamaRowsSortKode.map((agama: any) => (

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
                                    <Button name={agama.id} loading={loading && target === agama.id}
                                        size='mini' negative
                                        onClick={(e) => handleDeleteItem(e, agama.id, agama.timeStamp)}>Del</Button>
                                </Button.Group>
                                {/* <Button as='a' onClick={() => deleteItem(agama.id)}>Del</Button> */}
                            </Table.Cell>
                        </Table.Row>
                    ))}
                </Table.Body>
            </Table >
            {/* <AgamaListContent agamas={agamas} /> */}
            {/* agamas merupakan nama interface pada Component AgamaListContent
            sedangkan {agamas} adalah diambil dari useState */}
        </>
    )
})

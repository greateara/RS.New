import React from "react"
import { Header, List, Table } from "semantic-ui-react"
import { AgamaAPI } from "../../app/models/AgamaAPI"
import { Link } from "react-router-dom"

//parameter yang diterima dari AgamaList.tsx
interface Props {
    agamas: AgamaAPI[]
}

export default function AgamaListContent({ agamas }: Props) {
    return (
        <>
            {/* <List>
                {props.agamas.map((agama) => (
                    <List.Item key={agama.id}>
                        {agama.id}
                        {agama.uraian}
                        {agama.timestamp}
                        {agama.deleted}
                        {agama.kode}
                    </List.Item>
                ))}
            </List> */}
            {/* //penggunaan props adalah induk dari seluruh parameter yang dikirim dari AgamaList */}
            <Header className="ui center aligned header black" as='h1'>___ LIST ___</Header>
            <hr color="red"></hr>

            <Table className="ui compact table striped">
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.HeaderCell>Kode</Table.HeaderCell>
                        <Table.HeaderCell>Uraian</Table.HeaderCell>
                        <Table.HeaderCell>TimeStamp</Table.HeaderCell>
                        <Table.HeaderCell>Deleted</Table.HeaderCell>
                    </Table.Row>
                </Table.Header >

                <Table.Body>
                    {agamas.map((agama: any) => (

                        <Table.Row key={agama.id}>
                            <Table.Cell>
                                <Link  to={`/detail/${agama.id}`}>{agama.id.substring(0, 7).toUpperCase()} </Link>

                            </Table.Cell>
                            <Table.Cell>{agama.kode}</Table.Cell>
                            <Table.Cell>{agama.uraian}</Table.Cell>
                            <Table.Cell>{agama.timeStamp}</Table.Cell>
                            <Table.Cell>{agama.deleted}</Table.Cell>
                        </Table.Row>

                    ))}
                </Table.Body>
            </Table >
            <hr color="red"></hr>

        </>
    )
}
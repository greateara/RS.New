import React, { SyntheticEvent, useState } from "react";
import { Button, Grid, Item } from "semantic-ui-react";
import { OrgType } from "../../../app/models/OrgType";
import { Link } from "react-router-dom";
import { useStore } from "../../../app/stores/Store";
import {format} from 'date-fns';


interface Props {
    orgType: OrgType;
}
export default function OrgTypeListItem({orgType} : Props) {
    const { orgTypeStore } = useStore();
    const { deleteOrgType, loading } = orgTypeStore;
    const [target, setTarget] = useState('');

    function handleOrgTypeDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        deleteOrgType(id);
    }
    
    return (
        <Item key={orgType.id}>
            <Item.Content >
                <Item.Header as='a'>ID : {orgType.id}</Item.Header>
                <Item.Meta>*</Item.Meta>
                <Item.Content>
                    <Grid>
                        <Grid.Column width={2}>Code: {orgType.code}</Grid.Column>
                        <Grid.Column width={4}>Display: {orgType.display}</Grid.Column>
                        <Grid.Column width={6}>SaveDate: {format( orgType.saveDate!, 'yyyy-MM-dd')}</Grid.Column>
                        <Grid.Column width={2}>Delete: {orgType.deleted}</Grid.Column>
                    </Grid>
                </Item.Content>
                <Item.Description>
                    <Grid>
                        <Grid.Column width={12}>Definition: {orgType.definition}</Grid.Column>
                        <Grid.Column width={4}>
                            {/* <Buttonfloated='right' content='View' color='blue' /> */}
                            {/* <Button onClick={() => orgTypeStore.selectOrgType(orgType.id)}
                            floated='right' content='View' color='blue' /> */}
                            <Button as={Link} to={`/orgType/${orgType.id}`}
                                floated='right' content='View' color='green' />
                            <Button
                                as={Link} to={`/orgType/${orgType.id}`}
                                name={orgType.id}
                                loading={loading && target === orgType.id}
                                // onClick={(e) => handleOrgTypeDelete(e, orgType.id)}
                                floated='right'
                                content='Delete'
                                color='red' />
                        </Grid.Column>
                    </Grid>
                </Item.Description>
                <Item.Extra>
                    ***
                    {/* <Button floated='right' content='View' color='blue' /> */}
                    {/* <Label basic content={OrgType.display} /> */}
                </Item.Extra>
            </Item.Content>
        </Item>
    )
}
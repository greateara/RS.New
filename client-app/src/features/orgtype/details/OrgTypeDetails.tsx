import React, { useEffect } from 'react'
import { Button, Card, Image } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/Store'
import LoadingComponent from '../../../app/layout/loadingComponent';
import { observer } from 'mobx-react-lite';
import { Link, useParams } from 'react-router-dom';
import format from 'date-fns/format';

export default observer(function OrgTypeDetails() {

    const { orgTypeStore } = useStore();
    const { selectedOrgType: orgType, loadingOrgType, loadingInitial } = orgTypeStore;
    const { id } = useParams(); // menerima parameter dari route

    useEffect(() => {
        if (id) loadingOrgType(id);
    }, [id, loadingOrgType])

    if (loadingInitial || !orgType) return <LoadingComponent />;

    return (
        <Card fluid>
            <Image src='/assets/RSS1.png' />
            <Card.Content>
                <Card.Header>{orgType.id}</Card.Header>
                <Card.Meta>
                    <span >{format( orgType.saveDate!, 'yyyy-MM-dd h:mm aa')}</span>
                </Card.Meta>
                <Card.Description>
                    {orgType.definition}
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button.Group width='2'>
                    <Button as={Link} to={`/manage/${orgType.id}`} basic color='blue' content='Edit' />
                    <Button as={Link} to='/OrgType' basic color='grey' content='Cancel' />
                </Button.Group>
            </Card.Content>
        </Card>
    )
})
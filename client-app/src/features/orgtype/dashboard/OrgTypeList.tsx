import { Header, Segment } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/Store';
import { observer } from 'mobx-react-lite';
import OrgTypeListItem from './OrgTypeListItem';
import { Fragment } from 'react';

export default observer(function OrgTypeList() {
    const { orgTypeStore } = useStore();
    const { groupedOrgType } = orgTypeStore;

    return (
        <>
        {groupedOrgType.map(([group, orgTypes]) => 
        <Fragment key={group}>
            <Header sub color='orange'>
                {group}
            </Header>
            <Segment>
            {orgTypes.map(orgType => (
                <OrgTypeListItem  key={orgType.id} orgType={orgType}/>
            ))}
        </Segment>
        </Fragment>
        )}
        </>
        
    )
})
import { Link } from "react-router-dom";
import { Button, Header, Icon, Segment, SegmentInline } from "semantic-ui-react";


export default function NotFound() {
    return (
        <Segment placeholder style={{display: 'flex', alignItems: 'center', justifyContent: 'center'}}>
            <Header>
                <Icon name='search'  />
                Oops - looked everywhere couldn't found
            </Header>
            <SegmentInline>
                <Button as={Link} to='/OrgType' >
                    Return to Organization Type 
                </Button>
            </SegmentInline>
        </Segment>
    )
}
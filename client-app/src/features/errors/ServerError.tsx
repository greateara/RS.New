import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/Store";
import { Container, Header, Segment } from "semantic-ui-react";

export default observer(function ServerError() {
    const { commonStore } = useStore();
    console.log(commonStore);
    return (

        <Container>
            <Header as='h1' content='Server Error' />
            <Header sub as='h5' color='red' content={commonStore.error?.code} />
            {commonStore.error?.code && (
                <Segment>
                    <Header sub as='h4' content='Stack trace' color='teal' />
                    <code style={{ marginTop: '10px' }} >
                        {commonStore.error.message}
                        {commonStore.error.response}
                    </code>
                </Segment>
            )}
        </Container>
    )

}
)
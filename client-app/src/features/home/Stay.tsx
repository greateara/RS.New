import { Container, Header, Segment, Image } from "semantic-ui-react";

export default function Stay() {
    return (
        <Segment inverted textAlign="center" vertical className="masterhead">
            <Container text>
                <Header as='h1' inverted>
                    <Image size='massive' src="/assets/sibolgalogo.png" alt='logo'
                        style={{ marginBottom: 12 }} />
                </Header>
                <Header as='h2' inverted content='Wellcome to RS.NetReact' />
            </Container>
        </Segment>
    )
}
import { link } from "fs";
import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";
import { useStore } from "../../app/stores/Store";
import { observer } from "mobx-react-lite";
import LoginForm from "../users/LoginForm";
import RegisterForm from "../users/RegisterForm";

export default observer(function HomePage() {
    const { userStore, modalStore } = useStore();
    return (
        <Segment inverted textAlign="center" vertical className="masterhead">
            <Container text>
                <Header as='h1' inverted>
                    <Image size='massive' src="/assets/sibolgalogo.png" alt='logo' style={{ marginBottom: 12 }} />
                </Header>
                {userStore.IsLoggedIn ? (
                    <>
                        <Header as='h2' inverted content='Wellcome to RS.NetReact' />
                        <Button as={Link} to='/OrgType' size='huge' inverted >
                            Goto Organization Type
                        </Button>
                    </>
                ) : (
                    <>
                        <Header as='h2' inverted content='Wellcome to RS.NetReact' />
                        <Button onClick={() => modalStore.openModal(<LoginForm />)} inverted >
                            Login!
                        </Button>
                        <Button onClick={() => modalStore.openModal(<RegisterForm />)} inverted >
                            Register!
                        </Button>
                    </>
                )}
            </Container>
        </Segment>
    )
})
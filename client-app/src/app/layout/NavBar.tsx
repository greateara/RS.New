// import react from 'react';
import { Button, Container, Dropdown, DropdownItem, Image, Menu } from 'semantic-ui-react';
// import { useStore } from '../stores/Store';
import { Link, NavLink } from 'react-router-dom';
import { useStore } from '../stores/Store';
import { observer } from 'mobx-react-lite';

// interface Props{
//     openForm: () => void;
// }
// export default function NavBar({openForm}: Props) {
export default observer(function NavBar() {
    const { userStore: { user, logout } } = useStore();
    return (
        <Menu inverted fixed='top'>
            <Container>

                <Menu.Item as={NavLink} to='/' header>
                    <img src="/assets/sibolgalogo.png" alt="logo" style={{ marginRight: '10px' }} />
                    RS.NetReact App
                </Menu.Item>
                <Menu.Item >Master
                    <Dropdown>
                        <Dropdown.Menu>
                            <Dropdown.Header>Data Referensi</Dropdown.Header>
                            <Dropdown.Item>
                                <Dropdown text='Data Induk'>
                                    <Dropdown.Menu>
                                        <Dropdown.Item as={NavLink} to='/Agama' name='Agama'>Agama</Dropdown.Item>
                                        <Dropdown.Item>Bahasa</Dropdown.Item>
                                        <Dropdown.Item>Organisasi</Dropdown.Item>
                                    </Dropdown.Menu>
                                </Dropdown>
                            </Dropdown.Item>
                            <Dropdown.Item>Home Goods</Dropdown.Item>
                            <Dropdown.Divider />
                            <Dropdown.Header>Data Pendukung</Dropdown.Header>
                            <Dropdown.Item>Cancellations</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
                <Menu.Item as={NavLink} to='/OrgType' name='OrgType' />
                <Menu.Item as={NavLink} to='/errors' name='Errors' />
                {/* 
                <Menu.Item>
                    <Button as={NavLink} to='/createOrgType' positive content='Create OrgType' />
                </Menu.Item> 
                */}
                <Menu.Item position='right'>
                    <Image src={user?.image || '/assets/user.png'} avatar spaced='right' />
                    <Dropdown pointing='top left' text={user?.displayName}>
                        <Dropdown.Menu>
                            <Dropdown.Item as={Link} to={`/profile/${user?.userName}`} text='My Profile' icon='user' />
                            <Dropdown.Item onClick={logout} text='Log-Out' icon='power' />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>

            </Container>
        </Menu >
    )
})
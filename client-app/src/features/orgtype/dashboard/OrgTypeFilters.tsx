import Calendar from "react-calendar";
import { Grid, Header, Label, Menu } from "semantic-ui-react";


export default function OrgTypeFilters() {
    return (
        <>
            <Grid >
                <Grid.Row centered>
                    <Grid.Column width={6}>
                        <h2>Filter By Classification</h2>
                        <Menu vertical size='large' style={{ width: '100%' }}>
                            <Header icon='filter' attached color='teal' content='Filters' />
                            <Menu.Item content='All Organization Types' />
                            <Menu.Item content='Types govt' />
                            <Menu.Item content='Types edu' />
                            <Menu.Item content='Types bus' />
                            <Menu.Item content='Types ins' />
                        </Menu>
                    </Grid.Column>
                    <Grid.Column width={6}>
                    <h2>Filter By Date</h2>

                        <Header />
                        <Calendar />
                    </Grid.Column>
                </Grid.Row>

            </Grid >

        </>
    )
}
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/loadingComponent";
import { useStore } from "../../app/stores/Store";
// import AgamaListPagination from "./ProvinsiList";
// import ProvinsiList from "./ProvinsiListMT";
import ProvinsiList from "./ProvinsiList";

export default observer(function Provinsi() {
    const { provinsiStore } = useStore()
    const { pgSearch } = provinsiStore

    useEffect(() => {
        provinsiStore.loadItems();
        // console.log('Provinsi.tsx-useEffect-Items', provinsiStore.items)
    }, [provinsiStore, pgSearch])

    if (provinsiStore.loadingInitial) return <LoadingComponent content=" ... Loading" />

    return (
        <>
            <Grid>
                <Grid.Column width={16}>
                    {/* {provinsiStore.editMode && <AgamaEntry />} */}
                </Grid.Column>
                <Grid.Column width={16}>
                    {/* {provinsiStore.item && !provinsiStore.editMode && <AgamaDetail />} */}
                </Grid.Column>
                <Grid.Column width={16}>
                    {/* <AgamaList />
                    <AgamaListPage /> */}
                    {/* <ProvinsiListMT />  */}
                    <ProvinsiList />
                </Grid.Column>
            </Grid>
        </>
    )
}
)
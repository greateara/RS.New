import { observer } from "mobx-react-lite";
import AgamaList from "./AgamaList";
import AgamaEntry from "./AgamaEntry";
import AgamaDetail from "./AgamaDetail";
import { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/loadingComponent";
import { useStore } from "../../app/stores/Store";
import AgamaListPage from "./AgamaListPage";
import AgamaListPagination from "./AgamaListPagination";

export default observer(function Agama() {
    const { agamaStore } = useStore()
    

    useEffect(() => {
        agamaStore.loadAgamas();
        agamaStore.loadAgamasFilter();
        // agamaStore.loadAgamasPage('a',3,2)
        console.log('agama eff')
    }, [agamaStore])

    if (agamaStore.loadingInitial) return <LoadingComponent content=" ... Loading" />

    return (
        <>
            <Grid>
                <Grid.Column width={16}>
                    {/* //Jika editMode = true */}
                    {agamaStore.editMode &&
                        <AgamaEntry/>}
                </Grid.Column>
                <Grid.Column width={16}>
                    {agamaStore.agamaPick && !agamaStore.editMode &&
                        <AgamaDetail />}
                    {/* tapilkan detail agama bila ada nilai agamas[0] */}
                </Grid.Column>
                <Grid.Column width={16}>
                    {/* <AgamaList />
                    <AgamaListPage /> */}
                    <AgamaListPagination/>
                </Grid.Column>
            </Grid>
        </>
    )
}
)
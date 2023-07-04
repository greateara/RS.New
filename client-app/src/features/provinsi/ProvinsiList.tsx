import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/Store";


export default observer(function AgamaListPagination() {
    const { provinsiStore } = useStore()

    console.log(provinsiStore.items)
    console.log(provinsiStore.item)
    return (
        <>
            Ini List Pagination
           
            {/* {provinsiStore.items} */}
        </>
    );
}
)

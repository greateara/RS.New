import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import ReactPaginate from "react-paginate";
import { useStore } from "../../app/stores/Store";
import { AgamaAPI } from "../../app/models/AgamaAPI";


export default observer(function AgamaListPagination() {
    const { agamaStore } = useStore()
    const { agamaRowsSortKodePage} = agamaStore
    
    const [currentItems, setCurrentItems] = useState<AgamaAPI>([])
    const [pageCount, setPageCount] = useState(0)
    const [itemOffset, setItemOffset] = useState(0) 
    const [itemsPerPage, setItemPerPage] = useState(3);

    useEffect(() => {
        const endOffset = itemOffset + itemsPerPage;
        setCurrentItems(agamaRowsSortKodePage)
        // setCurrentItems(agamaRowsSortKodePage())
        // setCurrentItems(agamaRowsSortKodePage.slice(itemOffset, endOffset))
        // setPageCount(Math.ceil(agamaRowsSortKodePage.length / itemsPerPage));
    },[itemOffset, itemsPerPage])
    

    const handlePageClick = (event) => {
        const newOffset = (event.selected * itemsPerPage) % agamaRowsSortKodePage.length;
        console.log(
            `User requested page number ${event.selected}, which is offset ${newOffset}`
        );
        setItemOffset(newOffset);
    };

    return (
        <>
            <ReactPaginate
                breakLabel="..."
                nextLabel="next >"
                onPageChange={handlePageClick}
                pageRangeDisplayed={5}
                pageCount={pageCount}
                previousLabel="< previous"
                renderOnZeroPageCount={null}
            />
        </>
    );
}
)

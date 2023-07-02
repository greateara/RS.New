import { useEffect } from "react";
// import { Grid, List } from 'semantic-ui-react';
// import { OrgType } from "../../../app/models/OrgType";
import { useStore } from "../../../app/stores/Store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/loadingComponent";
import OrgTypeList from "./OrgTypeList";
import OrgTypeFilters from "./OrgTypeFilters";
// import {OrgType} from '../../../app/models/OrgType'

// interface Props {
//     orgTypes: OrgType[];
//     // selectedOrgType: OrgType | undefined;
//     // selectOrgType: (id: string) => void;
//     // cancelSelectOrgType: () => void;
//     // editMode: boolean;
//     // openForm: (id: string) => void;
//     // closeForm: () => void;
//     // createOrEdit: (orgType: OrgType) => void;
//     deleteOrgType: (id: string) => void;
//     submitting: boolean;
// }
export default observer(function OrgTypeDashboard() {

    const { orgTypeStore } = useStore();
    const { loadingOrgTypes, orgTypesReg } = orgTypeStore;

    useEffect(() => {
        if (orgTypesReg.size <= 1) loadingOrgTypes();
        // orgTypeStore.loadingOrgTypes();
    }, [loadingOrgTypes])

    if (orgTypeStore.loadingInitial) return <LoadingComponent content='Loading App' />

    return (
        <>
            <OrgTypeFilters/>
            {/* {selectedOrgType && !editMode && <OrgTypeDetails />}
            {editMode && <OrgTypeForm />}
            <OrgTypeList /> */}
            <OrgTypeList />
        </>
    )
}
)
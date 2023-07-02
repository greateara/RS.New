import { makeAutoObservable, runInAction } from 'mobx'
import { OrgType } from '../models/OrgType'
import agent from '../api/Agent';
import { v4 as uuid } from 'uuid'
import { format } from 'date-fns';

export default class OrgTypeStore {
    orgTypesReg = new Map<string, OrgType>();
    selectedOrgType: OrgType | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = false;

    constructor() {
        makeAutoObservable(this)
    }

    get orgTypesByDate() {
        return Array.from(this.orgTypesReg.values()).sort((a, b) =>
            a.saveDate!.getTime() - b.saveDate!.getTime());
    }

    get groupedOrgType () {
        return Object.entries(
            this.orgTypesByDate.reduce(( orgTypes, orgType) => {
                // const saveDate = orgType.saveDate!.toISOString().split('T')[0];
                const saveDate =  format( orgType.saveDate!, 'yyyy-MM-dd');
                orgTypes[saveDate] = orgTypes[saveDate] ? 
                    [...orgTypes[saveDate], orgType] :
                    [orgType]
                return orgTypes;
            }, {} as {[key: string] : OrgType[]})
        )
    }
    loadingOrgTypes = async () => {
        this.setLoadingInitial(true);
        try {
            const orgTypes = await agent.OrgTypes.list();
            // runInAction(() => {
            orgTypes.forEach(orgType => {
                this.SetOrgType(orgType);
                // orgType.saveDate = orgType.saveDate.split('T')[0];
                // // this.orgTypes.push(orgType);
                // this.orgTypesReg.set(orgType.id, orgType);
            });
            this.setLoadingInitial(false);

            //    this.loadingInitial = false;
            // })
        } catch (error) {
            console.log(error);
            // runInAction(() => {
            // this.loadingInitial = false;
            // })
            this.setLoadingInitial(false);

        }
    }

    loadingOrgType = async (id: string) => {
        let orgType = this.GetOrgType(id);
        if (orgType) {
            this.selectedOrgType = orgType;
            return orgType;
        }
        else {
            this.loadingInitial = true;
            try {
                orgType = await agent.OrgTypes.details(id);
                this.SetOrgType(orgType);
                runInAction(() => this.selectedOrgType = orgType);
                this.setLoadingInitial(false);
                return orgType;

            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
                // this.loadingInitial = false;

            }
        }
    }

    private SetOrgType = (orgType: OrgType) => {
        // orgType.saveDate = orgType.saveDate.split('T')[0];
        orgType.saveDate =   new Date(orgType.saveDate!);
        this.orgTypesReg.set(orgType.id, orgType);
    }
    private GetOrgType = (id: string) => {
        return this.orgTypesReg.get(id);
    }
    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    // selectOrgType = (id: string) => {
    //     // this.selectedOrgType = this.orgTypes.find(a => a.id === id);
    //     this.selectedOrgType = this.orgTypesReg.get(id); //.orgTypes.find(a => a.id === id);
    // }

    // cancelSelectedOrgType = () => {
    //     this.selectedOrgType = undefined;
    // }

    // openForm = (id?: string) => {
    //     id ? this.selectOrgType(id) : this.cancelSelectedOrgType();
    //     this.editMode = true;
    //     console.log(id);
    // }

    // closeForm = () => {
    //     this.editMode = false;
    // }

    createOrgType = async (orgType: OrgType) => {
        this.loading = true;
        orgType.id = uuid();
        try {
            await agent.OrgTypes.create(orgType);
            runInAction(() => {
                // this.orgTypes.push(orgType);
                this.orgTypesReg.set(orgType.id, orgType); //.orgTypes.push(orgType);
                this.selectedOrgType = orgType;
                this.editMode = false;
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    updateOrgType = async (orgType: OrgType) => {
        this.loading = true;
        // orgType.id = uuid();
        try {
            await agent.OrgTypes.update(orgType);
            runInAction(() => {
                // console.log(orgType);
                // console.log(this.orgTypes);
                // this.orgTypes = this.orgTypes.map(a => a.id === orgType.id ? orgType : a);
                // this.orgTypes = this.orgTypes.filter(a => a.id !== orgType.id).concat(orgType);
                // this.orgTypes = [...this.orgTypes.filter( a => a.id === orgType.id), orgType];
                // console.log(this.orgTypes);
                this.orgTypesReg.set(orgType.id, orgType); //.orgTypes.push(orgType);

                this.selectedOrgType = orgType;
                this.editMode = false;
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    deleteOrgType = async (id: string) => {
        this.loading = true;
        try {
            await agent.OrgTypes.delete(id);
            runInAction(() => {
                // this.orgTypes = [...this.orgTypes.filter( a => a.id !== id)];
                this.orgTypesReg.delete(id); //.orgTypes = [...this.orgTypes.filter( a => a.id !== id)];
                // if (this.selectedOrgType?.id === id) this.cancelSelectedOrgType()
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }


}
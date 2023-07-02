import { makeAutoObservable, runInAction } from "mobx";
import { AgamaAPI } from "../models/AgamaAPI";
import agent from "../api/Agent";
import { v4 as uuid } from 'uuid'


export default class AgamaStore {
    agamaRows = new Map<string, AgamaAPI>()
    agamaFilter = new Map<string, AgamaAPI>()
    agamaPick: AgamaAPI | undefined = undefined

    // pagination
    paginationSearch = '~'
    paginationCount = 500  //Samakan dengan jumlah record dari API
    paginationSkip = 0
    paginationSelect = 1
    paginationNumOfRows = 10

    //var yang akan inheren ...rows ...row ...pick
    //variabel lokal ... ...s

    editMode = false
    loading = false
    loadingInitial = true
    // submitting = false

    constructor() {
        makeAutoObservable(this)
    }

    // set setPaginationSearch(newValue: string) {
    //     this.paginationSearch = newValue;
    // }
    // set setPaginationCount(newValue: number) {
    //     this.paginationCount = newValue;
    // }
    // set setPaginationSkip(newValue: number) {
    //     this.paginationSkip = newValue;
    // }
    //  setPaginationSelect = (newValue: number) => {
    //     this.paginationSelect = newValue;
    //     console.log('newval',newValue, this.paginationSelect)

    // }



    get agamaRowsSortKode() {
        return Array.from(this.agamaRows.values())
            .sort((a, b) => a.kode < b.kode ? -1 : 1)

    }

    get agamaRowsSortKodePage() {
        return Array.from(this.agamaFilter.values())
            .sort((a, b) => a.kode < b.kode ? -1 : 1)

    }

    loadAgamas = async () => {
        // this.setLoadingInitial(true)
        try {
            const agamas = await agent.Agama.list()
            // runInAction(() => {
            agamas.forEach(agama => {
                // agama.timeStamp = agama.timeStamp.split('T')[0];
                // this.agamaRows.push(agama)
                this.agamaRows.set(agama.id, agama)
            })
            this.setLoadingInitial(false)
            // })
        } catch (error) {
            console.log(error)
            // runInAction(() => {
            this.setLoadingInitial(false)
            // })
        }
    }

    loadAgamasFilter = async (
        // searcText: string
        // ,
        // count: number,
        // skip: number
    ) => {
        console.log('call api')
        // this.setLoadingInitial(true)
        if (this.paginationSearch == "") this.paginationSearch = "~"
        try {
            const agamas = await agent.Agama.listFilter(this.paginationSearch)
            runInAction(() => {
                agamas.forEach(agama => {
                    // agama.timeStamp = agama.timeStamp.split('T')[0];
                    // this.agamaRows.push(agama)
                    this.agamaFilter.set(agama.id, agama)
                })
                this.setLoadingInitial(false)
                console.log('aga', agamas)
            })
        } catch (error) {
            console.log(error)
            // runInAction(() => {
            this.setLoadingInitial(false)
            // })
        }
    }

    setPaginationSearch = (search: string) => {
        console.log('before update src', this.paginationSearch)
        this.paginationSearch = search
        console.log('after update src', this.paginationSearch)

    }
    setPaginationCount = (val: number) => { this.paginationCount = val }
    setPaginationSkip = (val: number) => { this.paginationSkip = val }
    setPaginationNumOfRows = (val: number) => { this.paginationNumOfRows = val }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state
    }

    selectAgama = (id: string) => {
        this.agamaPick = this.agamaRows.get(id)
    }

    cancelAgama = () => {
        this.agamaPick = undefined
    }

    openForm = (id?: string) => {
        id ? this.selectAgama(id) : this.cancelAgama()
        this.editMode = true
    }

    closeForm = () => {
        this.editMode = false
    }

    createAgama = async (agama: AgamaAPI) => {
        this.loading = true
        agama.id = uuid()
        agama.timeStamp = new Date().toISOString()
        try {
            await agent.Agama.create(agama)
            runInAction(() => {
                this.agamaRows.set(agama.id, agama)
                this.agamaPick = agama
                this.editMode = false
                this.loading = false
            })
        } catch (error) {
            console.log(error)
            runInAction(() => {
                // this.editMode = false
                this.loading = false
            })
        }
    }

    updateAgama = async (agama: AgamaAPI) => {
        this.loading = true
        // agama.id = uuid()
        try {
            await agent.Agama.update(agama)
            runInAction(() => {
                this.agamaRows.set(agama.id, agama)
                this.agamaPick = agama
                this.editMode = false
                this.loading = false
            })
        } catch (error) {
            console.log(error)
            runInAction(() => {
                // this.editMode = false
                this.loading = false
            })
        }
    }

    deleteAgama = async (id: string, timeStamp: string) => {
        this.loading = true
        try {
            await agent.Agama.delete(id, timeStamp)
            runInAction(() => {
                this.agamaRows.delete(id)
                // if (this.selectedAgama?.id === id) this.cancelAgama;
                this.loading = false
            })
        } catch (error) {
            console.log(error)
            runInAction(() => {
                this.loading = false
            })
        }
    }

}
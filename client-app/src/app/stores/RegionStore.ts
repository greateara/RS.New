import { makeAutoObservable, runInAction } from "mobx";
import { AgamaAPI } from "../models/AgamaAPI";
import agent from "../api/Agent";
import { v4 as uuid } from 'uuid'


export default class RegionStore {
    agamaRows = new Map<string, AgamaAPI>()
    agamaPick: AgamaAPI | undefined = undefined

    //var yang akan inheren ...rows ...row ...pick
    //variabel lokal ... ...s

    editMode = false
    loading = false
    loadingInitial = true
    // submitting = false

    constructor() {
        makeAutoObservable(this)
    }

    get agamaRowsSortKode() {
        return Array.from(this.agamaRows.values())
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
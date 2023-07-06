import { makeAutoObservable, runInAction } from "mobx";
import { ProvinsiAPI } from "../models/ProvinsiAPI";
import agent from "../api/Agent";
import { v4 as uuid } from 'uuid'
import { array } from "yup";


export default class ProvinsiStore {
    items = new Map<string, ProvinsiAPI>()
    item: ProvinsiAPI | undefined = undefined
    itemRows :  ProvinsiAPI[] = []

    pgSearch = '~'

    editMode = false
    loading = false
    loadingInitial = true

    constructor() {
        makeAutoObservable(this)
    }

    loadItems = async (
    ) => {
        // this.setLoadingInitial(true)
        console.log('provinsiStore - loadItems()')
        if (this.pgSearch == "") this.pgSearch = "~"
        try {
            const provinsis = await agent.Provinsi.listFilter(this.pgSearch)
            runInAction(() => { //digunakan untuk dipanggil berulang-ulang strick-mode
                this.items.clear(); //mesti dihapus dulu sebelum di isi kembali
                provinsis.forEach(provinsi => {
                    this.items.set(provinsi.id, provinsi)
                })
                this.setLoadingInitial(false)
                this.itemRows = provinsis
                console.log('provinsiStore-provinsis', provinsis)
            })
        } catch (error) {
            // console.log(error)
            this.setLoadingInitial(false)
        }
    }

    setPgSearch = (search: string) => {
        // console.log('before update src', this.pgSearch)
        this.pgSearch = search
        // console.log('after update src', this.pgSearch)
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state
    }

    itemSelect = (id: string) => {
        this.item = this.items.get(id)
    }

    itemReset = () => {
        this.item = undefined
    }

    openForm = (id?: string) => {
        id ? this.itemSelect(id) : this.itemReset()
        this.editMode = true
    }

    closeForm = () => {
        this.editMode = false
    }

    create = async (provinsi: ProvinsiAPI) => {
        this.loading = true
        provinsi.id = uuid()
        provinsi.timeStamp = new Date().toUTCString()
        try {
            await agent.Provinsi.create(provinsi)
            runInAction(() => {
                this.items.set(provinsi.id, provinsi)
                this.item = provinsi
                this.editMode = false
                this.loading = false
            })
        } catch (error) {
            console.log(error)
            runInAction(() => {
                this.loading = false
            })
        }
    }

    update = async (provinsi: ProvinsiAPI) => {
        this.loading = true
        try {
            await agent.Provinsi.update(provinsi)
            runInAction(() => {
                this.items.set(provinsi.id, provinsi)
                this.item = provinsi
                this.editMode = false
                this.loading = false
            })
        } catch (error) {
            console.log(error)
            runInAction(() => {
                this.loading = false
            })
        }
    }

    delete = async (id: string, timeStamp: string) => {
        this.loading = true
        try {
            await agent.Provinsi.delete(id, timeStamp)
            runInAction(() => {
                this.items.delete(id)
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
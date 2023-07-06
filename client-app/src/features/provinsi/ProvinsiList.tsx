import { useEffect, useMemo, useState } from 'react';
import { MaterialReactTable, type MRT_ColumnDef } from 'material-react-table';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/Store';
import { ProvinsiAPI } from '../../app/models/ProvinsiAPI';
import { Button } from 'semantic-ui-react';


export default observer(function ProvinsiList() {

  const { provinsiStore } = useStore()
  // const { items } = provinsiStore
  const { setPgSearch, itemRows, loadingInitial } = provinsiStore
  const [globalFilter, setGlobalFilter] = useState('~');
  // const [isRefetching, setIsRefetching] = useState(false);
  // const [isLoading, setIsLoading] = useState(false);
  // console.log('items', provinsiStore.items)
  // console.log('item', provinsiStore.item)

  const handlePilih = () => {
    console.log('Pilih Click')
  }

  const columns = useMemo<MRT_ColumnDef<ProvinsiAPI>[]>(
    () => [
      {
        // accessorkey: "id",
        accessorFn: (row) => row.id.toUpperCase().substring(0, 8),
        header: 'Id',
        size: 1,
      },
      {
        accessorKey: 'kode',
        header: 'Kode',
        size: 5,
      },
      // {
      //   accessorKey: 'deleted', //normal accessorKey
      //   header: 'Deleted',
      //   size: 5,
      // },
      {
        accessorKey: 'uraian',
        header: 'Uraian',
        size: 300,
      },
      {
        accessorFn: () => <Button onClick={handlePilih}>test</Button>,
        header: 'Action',
        size: 50,
      },
    ],
    [],
  );



  useEffect(() => {
    // if (!loadingInitial) {
      // setIsRefetching(true)
      // setIsLoading(true)
    // };
    setPgSearch(globalFilter)
    // setIsRefetching(false)
    // setIsLoading(false)
  }, [globalFilter])

  // if (provinsiStore.loadingInitial) return <LoadingComponent content=" ... Loading" />

  return (
    <>
      <MaterialReactTable
        columns={columns}
        data={itemRows}
        manualFiltering
        onGlobalFilterChange={setGlobalFilter}
        state={{
          // globalFilter,
          // showProgressBars: isRefetching,
          // isLoading,
        }}
      />
    </>
  )
})

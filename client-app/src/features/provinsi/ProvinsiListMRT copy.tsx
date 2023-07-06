import React, { useEffect, useMemo, useState } from 'react';
import { MaterialReactTable, type MRT_ColumnDef } from 'material-react-table';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/Store';
import { ProvinsiAPI } from '../../app/models/ProvinsiAPI';
import { Button } from 'semantic-ui-react';

//example data type
type Person = {
  name: {
    firstName: string;
    lastName: string;
  };
  address: string;
  city: string;
  state: string;
};

//nested data is ok, see accessorKeys in ColumnDef below
// const data: Person[] = [
//   {
//     name: {
//       firstName: 'John',
//       lastName: 'Doe',
//     },
//     address: '261 Erdman Ford',
//     city: 'East Daphne',
//     state: 'Kentucky',
//   },
//   {
//     name: {
//       firstName: 'Jane',
//       lastName: 'Doe',
//     },
//     address: '769 Dominic Grove',
//     city: 'Columbus',
//     state: 'Ohio',
//   },
//   {
//     name: {
//       firstName: 'Joe',
//       lastName: 'Doe',
//     },
//     address: '566 Brakus Inlet',
//     city: 'South Linda',
//     state: 'West Virginia',
//   },
//   {
//     name: {
//       firstName: 'Kevin',
//       lastName: 'Vandy',
//     },
//     address: '722 Emie Stream',
//     city: 'Lincoln',
//     state: 'Nebraska',
//   },
//   {
//     name: {
//       firstName: 'Joshua',
//       lastName: 'Rolluffs',
//     },
//     address: '32188 Larkin Turnpike',
//     city: 'Omaha',
//     state: 'Nebraska',
//   },
// ];



export default observer(function ProvinsiListMRT() {

  const { provinsiStore } = useStore()
  const { items } = provinsiStore
  const [itemRows, setItemRows] = useState<ProvinsiAPI[]>([])
  const [globalFilter, setGlobalFilter] = useState('~');
  const { pgSearch, setPgSearch } = provinsiStore

  console.log('items', provinsiStore.items)
  console.log('item', provinsiStore.item)

  useEffect(() => {
    // provinsiStore.loadItems();
    // console.log(items)
    setPgSearch(globalFilter)

    const provinsiArray: ProvinsiAPI[] = Array.from(items.values());
    // const slicedArray: ProvinsiAPI[] = provinsiArray.slice(0, 35);
    setItemRows(provinsiArray)

    // provinsiStore.loadItems()
    // setItemRows(provinsiArray)

    console.log('ProvinsiList.tsx-GlobalFilter', globalFilter)
    console.log('ProvinsiList.tsx-items', items)
    console.log('ProvinsiList.tsx-itemRows', itemRows)
    console.log('ProvinsiList.tsx-provinsiArray', provinsiArray)
    console.log('pgSearch', pgSearch)
  }, [globalFilter])

  // const columns = useMemo<MRT_ColumnDef<Person>[]>(
  //   () => [
  //     {
  //       accessorKey: 'name.firstName', //access nested data with dot notation
  //       header: 'First Name',
  //       size: 150,
  //     },
  //     {
  //       accessorKey: 'name.lastName',
  //       header: 'Last Name',
  //       size: 150,
  //     },
  //     {
  //       accessorKey: 'address', //normal accessorKey
  //       header: 'Address',
  //       size: 200,
  //     },
  //     {
  //       accessorKey: 'city',
  //       header: 'City',
  //       size: 150,
  //     },
  //     {
  //       accessorKey: 'state',
  //       header: 'State',
  //       size: 150,
  //     },
  //   ],
  //   [],
  // );

  const handlePilih = () => {
    console.log('Pilih Click')
  }

  const columns = useMemo<MRT_ColumnDef<ProvinsiAPI>[]>(
    () => [
      {
        accessorkey: "id",
        // accessorFn: (row) => row.id.toUpperCase().substring(0, 8),
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
        accessorFn: (row) => <Button onClick={handlePilih}>test</Button>,
        header: 'Action',
        size: 50,
      },
    ],
    [],
  );

  return (
    <>
      <MaterialReactTable columns={columns} data={itemRows}
        // enableColumnFilters={false} positionGlobalFilter="left"
        // muiTableHeadCellColumnActionsButtonProps={}
        // enableBottomToolbar
        manualFiltering
        onGlobalFilterChange={setGlobalFilter}
        state={{ globalFilter, }}
      // state={{PgSearch}} //hoist internal global state to your state
      // state={ arr } //pass in your own managed globalFilter state

      />
    </>
  )
}
)

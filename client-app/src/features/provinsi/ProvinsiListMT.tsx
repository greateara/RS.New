import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/Store";

import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { useEffect, useState } from "react";


import { ProvinsiAPI } from "../../app/models/ProvinsiAPI";

function createData(
  name: string,
  calories: number,
  fat: number,
  carbs: number,
  protein: number,
) {
  return { name, calories, fat, carbs, protein };
}

const rows = [
  createData('Frozen yoghurt', 159, 6.0, 24, 4.0),
  createData('Ice cream sandwich', 237, 9.0, 37, 4.3),
  createData('Eclair', 262, 16.0, 24, 6.0),
  createData('Cupcake', 305, 3.7, 67, 4.3),
  createData('Gingerbread', 356, 16.0, 49, 3.9),
];


export default observer(function ProvinsiListMR() {
  const { provinsiStore } = useStore()
  const { items, pgSearch } = provinsiStore
  const [itemRows, setItemRows] = useState<ProvinsiAPI[]>([])

  console.log('items', provinsiStore.items)
  console.log('item', provinsiStore.item)

  // const data = [
  //   { name: "RSS", age: 10 },
  //   { name: "RsSS", age: 10 },
  //   { name: "RSddS", age: 10 },
  // ]

  // const columns = [
  //   { title: 'name', field: 'name' },
  //   { title: 'age', field: 'age' },


  // ]

  useEffect(() => {
    // provinsiStore.loadItems();
    // console.log(items)
    const provinsiArray: ProvinsiAPI[] = Array.from(items.values());
    // const slicedArray: ProvinsiAPI[] = provinsiArray.slice(0, 35);

    setItemRows(provinsiArray)

    console.log('ProvinsiList.tsx-itemRows', itemRows)
    console.log('ProvinsiList.tsx-provinsiArray', provinsiArray)
  }, [items, pgSearch])



  return (
    <>
      <div>
        Ini List Pagination
      </div>
      <Paper sx={{ width: '100%', overflow: 'hidden' }}>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead> <h2>Daftar Provinsi</h2>
              <TableRow>
                <TableCell align="center">Id</TableCell>
                <TableCell align="center">Kode&nbsp;(g)</TableCell>
                <TableCell align="center">Uraian&nbsp;(g)</TableCell>
                <TableCell align="center">TimeStamp&nbsp;(g)</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {itemRows.map((row) => (
                <TableRow
                  key={row.id}
                // sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {row.id.toUpperCase().substring(0, 8)}
                  </TableCell>
                  <TableCell align="left">{row.kode}</TableCell>
                  <TableCell align="left">{row.uraian}</TableCell>
                  <TableCell align="left">{row.timeStamp}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
    </>
  );
}
)

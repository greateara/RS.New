import { useEffect, useMemo, useState } from 'react';
import { MaterialReactTable, type MRT_ColumnDef } from 'material-react-table';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/Store';
import { ProvinsiAPI } from '../../app/models/ProvinsiAPI';
import { Button, IconButton } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import SendIcon from '@mui/icons-material/Send';
import ButtonGroup from 'semantic-ui-react/dist/commonjs/elements/Button/ButtonGroup';

export default observer(function ProvinsiList() {

  const { provinsiStore } = useStore()
  const { setPgSearch, itemRows } = provinsiStore
  const [globalFilter, setGlobalFilter] = useState('~');

  const handleSend = () => {
    console.log('ini dari send')
  }

  const buttons = [
    <Button key="one" color="warning" startIcon={<DeleteIcon />} onChange={handleSend}>Del</Button>,
    <Button key="two" color="info" endIcon={<SendIcon />}>Send</Button>,
  ];

  const columns = useMemo<MRT_ColumnDef<ProvinsiAPI>[]>(
    () => [
      {
        accessorFn: (row) => row.id.toUpperCase().substring(0, 8),
        header: 'Id',
        size: 100,
      },
      {
        accessorKey: 'kode',
        header: 'Kode',
        size: 100,
      },
      {
        accessorKey: 'uraian',
        header: 'Uraian',
        size: 700,
      },
      {
        accessorFn: () =>
          <>
            <ButtonGroup size="small" aria-label="small button group"              >
              {buttons}
            </ButtonGroup>
          </>,
        header: 'Action',
        size: 5,
      },
    ],
    [],
  );

  useEffect(() => {
    setPgSearch(globalFilter)
  }, [globalFilter])

  return (
    <>
      <MaterialReactTable
        initialState={{ density: 'compact', }}
        columns={columns}
        data={itemRows}
        manualFiltering
        onGlobalFilterChange={setGlobalFilter}
        state={{
        }}
      />
    </>
  )
})

import { Box, Grid, Typography } from "@mui/material";
import { Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import * as Yup from 'yup'
// import { palette } from '@mui/system';

// import MyTextField from '../../app/common/formUI/MyTextField/MyTestF'
// import MyTextField from "../../app/common/formUI/MyT";
import MyTextField from "../../app/common/formUI/MyTextField";

const initialValue = {
    id: '',
    kode: 0,
    deleted: '',
    uraian: '',
    timeStamp: ''
}

const formValidation = Yup.object().shape({
    //https://www.npmjs.com/package/yup
    id: Yup.string().nullable(),
    kode: Yup.number().integer().typeError('enter valid number').required('Required'),
    uraian: Yup.string().required('Required'),
    timeStamp: Yup.date().required('Required').default(() => new Date())
})

export default observer(function ProvinsiDetail() {
    return (
        <>
            <Box sx={{ borderColor: 'success.main' }}>

                <Formik
                    initialValues={{ ...initialValue }}
                    validationSchema={{ ...formValidation }}
                    onSubmit={(values) => {
                        console.log(values)
                    }}
                >
                    <Form>
                        Ini adalah details
                        <Grid container spacing={1} xs={6} border={1}>
                            <Grid item xs={12}>
                                <Typography>
                                    Your Detail
                                </Typography>
                            </Grid>
                            <Grid item xs={6}>
                                <MyTextField name='id' label="Id" />
                            </Grid>
                            <Grid item xs={6}>
                                <MyTextField name='kode' label="Kode" />
                            </Grid>
                            {/* <Grid item xs={12}>
                            <Typography>
                                Address
                            </Typography>
                        </Grid> */}
                            <Grid item xs={6}>
                                <MyTextField name='uraian' label="Uraian" />
                            </Grid>
                            {/* <Grid item xs={12}>
                            <Typography>
                                Basic Informastion
                            </Typography>
                        </Grid> */}
                            <Grid item xs={6}>
                                <MyTextField name='timeStamp' label="Time Stamp" />
                            </Grid>
                        </Grid>

                    </Form>

                </Formik>
            </Box>

        </>
    )
})
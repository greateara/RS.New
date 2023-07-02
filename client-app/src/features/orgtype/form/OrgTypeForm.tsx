import { useEffect, useState } from 'react';
import { Button, Segment } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/Store';
import { observer } from 'mobx-react-lite';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { OrgType } from '../../../app/models/OrgType';
import LoadingComponent from '../../../app/layout/loadingComponent';
import { v4 as uuid } from 'uuid';
import { Formik, Form } from 'formik';
import * as Yup from 'yup'
import MyText from '../../../app/common/form/MyText';
import MyTextArea from '../../../app/common/form/MyTextArea';
import MySelect from '../../../app/common/form/MySelect';
import { CodeOptions } from '../../../app/common/options/CodeOptions';
import MyDate from '../../../app/common/form/MyDate';

export default observer(function OrgTypeForm() {

    const { orgTypeStore } = useStore();
    const { selectedOrgType,
        createOrgType,
        updateOrgType,
        loading,
        loadingOrgType,
        loadingInitial } = orgTypeStore;
    const { id } = useParams();
    const navigate = useNavigate();
    const [orgType, setorgType] = useState<OrgType>({
        id: '',
        deleted: 0,
        saveDate: null,
        code: '',
        display: '',
        definition: ''
    });
    const validationSchema = Yup.object({
        code: Yup.string().required('Code is required'),
        display: Yup.string().required(),
        definition: Yup.string().required(),
        saveDate: Yup.date().required('saveDate is required')
    })

    useEffect(() => {
        if (id) loadingOrgType(id).then(orgType => setorgType(orgType!))
    }, [id, loadingOrgType])

    function handleFormSubmit(orgType: OrgType) {
        if (orgType.id.length === 0) {
            let newOrgType = {
                ...orgType,
                id: uuid()
            };
            createOrgType(newOrgType).then(() => navigate(`/OrgType/${orgType.id}`))
        } else {
            updateOrgType(orgType).then(() => navigate(`/OrgType/${orgType.id}`))
        }
    }

    // function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
    //     const { name, value } = event.target;
    //     setorgType({ ...orgType, [name]: value })
    // }

    if (loadingInitial) return <LoadingComponent content='loading organizatioan type' />

    return (
        <Segment clearing>
            <Formik
                validationSchema={validationSchema}
                enableReinitialize
                initialValues={orgType}
                onSubmit={values => handleFormSubmit(values)}>
                {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                    <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                        <MyText placeholder='Id' name='id' />
                        <MyDate
                            placeholderText='Save Date'
                            name='saveDate'
                            showTimeSelect
                            timeCaption='time'
                            dateFormat='yyyy-MM-dd h:mm aa'
                        />
                        <MyText placeholder='Deleted' name='deleted' />
                        <MySelect options={CodeOptions} placeholder='Code' name='code' />
                        <MyText placeholder='Display' name='display' />
                        <MyTextArea rows={3} placeholder='Definition' name='definition' />
                        <Button
                            disabled={isSubmitting || !dirty || !isValid}
                            loading={loading} floated='right'
                            positive type='submit' content='Submit' />
                        <Button as={Link} to='/OrgType' floated='right' type='button' content='Cancel' />
                    </Form>
                )}
            </Formik>
        </Segment>
    )
})

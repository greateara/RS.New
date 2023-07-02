import { ChangeEvent, useState } from "react";
import { useStore } from "../../app/stores/Store";
import { observer } from "mobx-react-lite";
import { Button, Form, Header, Input, Segment, TextArea } from "semantic-ui-react";

// interface Props {
//     // selectedAgama: AgamaAPI | undefined;
//     // selectAgama: (id: string) => void;
//     // cancelAgama: () => void;
//     // editMode: boolean;
//     // openForm: (id: string) => void;
//     // closeForm: () => void;
//     createOrEdit: (agama: AgamaAPI) => void;
//     submitting: boolean
// }

export default observer(function AgamaEntry() {

    const { agamaStore } = useStore();
    const { agamaPick, closeForm, createAgama, updateAgama,
        loading } = agamaStore

    const initialState = agamaPick ?? {
        id: '',
        kode: 0,
        deleted: 0,
        uraian: '',
        timeStamp: ''
    } 

    const [agamaForm, setAgamaForm] = useState(initialState);

    function handleSubmit() {
        agamaForm.id ? updateAgama(agamaForm) : createAgama( agamaForm)
        // createOrEdit(agamaForm)
        // console.log(agamaForm);
    }

    function handleInput(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setAgamaForm({ ...agamaForm, [name]: value })
        // console.log('agamaForm', agamaForm)
        // console.log('initial', initialState)
    }

    return (
        <>
            <Header className="ui center aligned header black" as='h1'> ___ ENTRY ___</Header>
            <Segment clearing>
                <Form onSubmit={handleSubmit} autoComplete='off'>
                    <Form.Group widths='equal'>
                        <Form.Field
                            // id='form-input-control-first-name'
                            control={Input}
                            label='Id' placeholder='Id'
                            value={agamaForm.id} name='id'
                            onChange={handleInput}
                        />
                        <Form.Field
                            // id='form-input-control-first-name'
                            control={Input}
                            label='Kode'
                            placeholder='Kode'
                            value={agamaForm.kode} name='kode'
                            onChange={handleInput}
                        />
                        <Form.Field
                            // id='form-input-control-first-deleted'
                            control={Input}
                            label='Deleted'
                            placeholder='Deleted'
                            value={agamaForm.deleted} name='deleted'
                            onChange={handleInput}
                        />
                    </Form.Group>
                    {/* <Form.Field
                        // id='form-input-control-first-deleted'
                        control={Input}
                        label='Time Stamp'
                        placeholder='timeStamp'
                        type='date'
                        value={agamaForm.timeStamp} name='timeStamp'
                        onChange={handleInput}
                    /> */}
                    <Form.Field
                        id='form-textarea-control-opinion'
                        control={TextArea}
                        label='Uraian'
                        placeholder='Uraian'
                        value={agamaForm.uraian} name='uraian'
                        onChange={handleInput}
                    />
                    <Button loading={loading} onClick={handleSubmit} floated='right' positive type='submit' content='Submit' />
                    {/* <Button onClick={handleSubmit} floated='right' positive type='submit' content='Submit' /> */}
                    <Button onClick={closeForm} floated='right' type='button' content='Cancel' />
                </Form>
            </Segment>
        </>
    )
})

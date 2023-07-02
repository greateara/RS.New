import React, { useState } from 'react';
import { Button, Header, Segment } from "semantic-ui-react";
import axios from 'axios';
import ValidationError from './ValidationErrors';
import { MyAlert } from "../../app/layout/MyAlert"
import Swal from 'sweetalert2';

export default function TestErrors() {
    const baseUrl = 'http://localhost:5006/'
    const [errors, setErrors] = useState(null);

    function handleNotFound() {
        axios.get(baseUrl + 'buggy/not-found').catch(err => console.log(err.response));
    }

    function handleBadRequest() {
        axios.get(baseUrl + 'buggy/bad-request').catch(err => console.log(err.response));
    }

    function handleServerError() {
        axios.get(baseUrl + 'buggy/server-error').catch(err => console.log(err.response));
    }

    function handleUnauthorised() {
        axios.get(baseUrl + 'buggy/unauthorised').catch(err => console.log(err.response));
    }

    function handleBadGuid() {
        axios.get(baseUrl + 'orgtype/notaguid').catch(err => console.log(err.response));
    }

    function handleValidationError() {
        axios.post(baseUrl + 'OrgType', {}).catch(err => setErrors(err)); // console.log(err));
    }

    function AAlert() {
        // Swal.fire().fire({
        //     title: 'Sweet!',
        //     text: 'Modal with a custom image.',
        //     // imageUrl: 'https://unsplash.it/400/200',
        //     // imageWidth: 400,
        //     // imageHeight: 200,
        //     // imageAlt: 'Custom image',
        // })
        Swal.fire(
            'The Internet?',
            'That thing is still around?',
            'question'
        )
    }

    const handleButtonClick = () => {
        MyAlert(); // Memanggil fungsi MyAlert saat tombol diklik
      };
    
    return (
        <>
            <Header as='h1' content='Test Error component' />
            <Segment>
                <Button.Group widths='7'>
                    <Button onClick={handleNotFound} content='Not Found' basic primary />
                    <Button onClick={handleBadRequest} content='Bad Request' basic primary />
                    <Button onClick={handleValidationError} content='Validation Error' basic primary />
                    <Button onClick={handleServerError} content='Server Error' basic primary />
                    <Button onClick={handleUnauthorised} content='Unauthorised' basic primary />
                    <Button onClick={handleBadGuid} content='Bad Guid' basic primary />
                </Button.Group>
            </Segment>
            {errors && <ValidationError errors={errors} />}
            <Button onClick={AAlert}>Test Alert</Button>
            <Button onClick={handleButtonClick}>Test Alert</Button>
        </>
    )
}
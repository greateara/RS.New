import { ErrorMessage, Form, Formik, FormikHelpers, FormikValues } from "formik"
import MyText from "../../app/common/form/MyText"
import { Button, Header, Label } from "semantic-ui-react"
import { useStore } from "../../app/stores/Store";
import { observer } from "mobx-react-lite";
import * as Yup from 'yup';
import { isBuiltin } from "module";
// import ValidationError from "../errors/ValidationErrors";
import ValidationErrors from "../errors/ValidationErrors";

export default observer(function RegisterForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ displayName: '', userName: '', email: '', password: '', error: null }}
            onSubmit={(values, { setErrors }) =>
                userStore.register(values).catch(error =>
                    setErrors({ error}))}
            validationSchema={Yup.object({
                displayName: Yup.string().required(),
                userName: Yup.string().required(),
                email: Yup.string().email(),
                password: Yup.string().required(),
            })}
        >
            {({ handleSubmit, isSubmitting, isValid, dirty, errors }) => (
                <Form className="ui form error" onSubmit={handleSubmit} autoComplete="off">
                    <Header as='h3' content='Register to RS.NetReact' color="orange" textAlign="center" />

                    <MyText placeholder="Display Name" name="displayName" />
                    <MyText placeholder="User Name" name="userName" />
                    <MyText placeholder="Email" name="email" />
                    <MyText placeholder="Password" name="password" type='password' />
                    <ErrorMessage
                        name='error' render={() =>
                            // <Label style={{ marginBottom: 10 }} basic color='red' 
                            // content={errors.error} />
                            <ValidationErrors errors={errors.error}  />
                        }
                    />
                    <Button
                    disabled={!isValid || !dirty || isSubmitting}
                        loading={isSubmitting} positive content='Register'
                        type='submit' fluid />
                </Form>
            )}
        </Formik>
    )
})
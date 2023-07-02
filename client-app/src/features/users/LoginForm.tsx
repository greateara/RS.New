import { ErrorMessage, Form, Formik, FormikHelpers, FormikValues } from "formik"
import MyText from "../../app/common/form/MyText"
import { Button, Header, Label } from "semantic-ui-react"
import { useStore } from "../../app/stores/Store";
import { observer } from "mobx-react-lite";

export default observer(function LoginForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ email: '', password: '', error: null }}
            onSubmit={(values, { setErrors }) =>
                userStore.login(values).catch(error =>
                    setErrors({ error: 'invalid email or pasword' }))}
        >
            {({ handleSubmit, isSubmitting, errors }) => (
                <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                    <Header as='h3' content='Login to RS.NetReact' color="orange" textAlign="center" />

                    <MyText placeholder="Email" name="email" />
                    <MyText placeholder="Password" name="password" type='password' />
                    <ErrorMessage
                        name='error' render={() =>
                            <Label style={{ marginBottom: 10 }} basic color='red' content={errors.error} />}
                    />
                    <Button loading={isSubmitting} positive content='Login' type='submit' fluid />
                </Form>
            )}
        </Formik>
    )
})
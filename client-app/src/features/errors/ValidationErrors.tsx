import { Message } from "semantic-ui-react";

interface Props {
    // errors: string[];
    errors: any;
}

export default function ValidationErrors({ errors }: Props) {
    return (
        <>
            {/* <Message errors> */}
            <Message errors={errors.toString()}>
                {/* console.log(errors); */}

                {/* {errors && ( */}
                {
                    // errors  && (
                    <Message.List>
                        {/* {errors.map((err: string, i: any) => ( */}
                        {errors.map((err: any, i: any) => (
                            <Message.Item key={i}>{err}</Message.Item>
                        ))}
                    </Message.List>
                    // )
                }
            </Message>
        </>
    )
}
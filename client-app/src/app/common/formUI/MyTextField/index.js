import { TextField } from '@mui/material'
import { useField } from 'formik'

const TextfieldWrapper = ({
    name,
    ...otherProps
}) => {
    const [field, meta] = useField(name)
    const configMyTextField = {
        field,
        ...otherProps,
        fullWidth: true,
        variant: 'standard'
    }

    if (meta && meta.touched && meta.error) {
        configMyTextField.error = true;
        configMyTextField.helperText = meta.error;
    }
    return (
        <TextField {...configMyTextField} />
    )
};

export default TextfieldWrapper;
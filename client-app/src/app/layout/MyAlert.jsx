import { Swal } from "sweetalert2";


export function MyAlert() {
    Swal.fire(
        'The Internet?',
        'That thing is still around?',
        'question'
    )
}

export interface ServerError {
    // statusCode: number;
    // messsage: string;
    // details: string;

    code: string;
    message: string;
    response: string | any;
    
    // status : string,
    // statusText : string,
    // data: string
    // res : string;
}
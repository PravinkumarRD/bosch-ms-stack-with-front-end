import { AccessToken } from "./access-token";

export class AuthResponse {
    token: string;
    message: string;
    success: boolean;
    role:string;
    email:string;
}

import { HostUrl } from "./HostUrl";

export enum FileController{
    get = HostUrl.hostUrl+HostUrl.file,
    post = HostUrl.hostUrl+HostUrl.file,
}
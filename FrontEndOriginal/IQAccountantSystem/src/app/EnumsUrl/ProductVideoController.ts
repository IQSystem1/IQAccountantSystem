import { HostUrl } from "./HostUrl";

export enum ProductVideoController{
    get = HostUrl.hostUrl+HostUrl.productVideo,
    post = HostUrl.hostUrl+HostUrl.productVideo,
    put = HostUrl.hostUrl+HostUrl.productVideo,
    delete = HostUrl.hostUrl+HostUrl.productVideo+"Delete",
}
import { HostUrl } from "./HostUrl";

export enum ProductImageController{
    get = HostUrl.hostUrl+HostUrl.productImage,
    post = HostUrl.hostUrl+HostUrl.productImage,
    put = HostUrl.hostUrl+HostUrl.productImage,
    delete = HostUrl.hostUrl+HostUrl.productImage+"Delete",
}
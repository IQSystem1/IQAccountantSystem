import { HostUrl } from "./HostUrl";

export enum ProductController{
    get = HostUrl.hostUrl+HostUrl.product,
    post = HostUrl.hostUrl+HostUrl.product,
    put = HostUrl.hostUrl+HostUrl.product,
    delete = HostUrl.hostUrl+HostUrl.product,
    getByCode = HostUrl.hostUrl+HostUrl.product+"Get/",
    search = HostUrl.hostUrl+HostUrl.product+"Search/",

}
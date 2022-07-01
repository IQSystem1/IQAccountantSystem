import { HostUrl } from "./HostUrl";

export enum SaleController{
    get = HostUrl.hostUrl+HostUrl.sale,
    post = HostUrl.hostUrl+HostUrl.sale
}
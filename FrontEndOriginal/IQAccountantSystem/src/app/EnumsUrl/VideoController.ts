import { HostUrl } from "./HostUrl";

export enum VideoController{
    get = HostUrl.hostUrl+HostUrl.video,
    post = HostUrl.hostUrl+HostUrl.video,
    put = HostUrl.hostUrl+HostUrl.video,
    delete = HostUrl.hostUrl+HostUrl.video,
    getByProductId = HostUrl.hostUrl+HostUrl.video+"GetByProductId/"

}
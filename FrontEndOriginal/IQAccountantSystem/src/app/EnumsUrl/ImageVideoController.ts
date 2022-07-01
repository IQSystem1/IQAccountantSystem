import { HostUrl } from "./HostUrl";

export enum ImageVideoController{
    get = HostUrl.hostUrl+HostUrl.imageVideo,
    post = HostUrl.hostUrl+HostUrl.imageVideo,
    put = HostUrl.hostUrl+HostUrl.imageVideo,
    delete = HostUrl.hostUrl+HostUrl.imageVideo,
    getByProductId = HostUrl.hostUrl+HostUrl.imageVideo+"GetByProductId/",
    getByProductCode = HostUrl.hostUrl+HostUrl.imageVideo+"GetVideosByProductCode/"

}
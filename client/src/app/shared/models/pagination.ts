import {ITrack} from "./track";

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: ITrack[];
}

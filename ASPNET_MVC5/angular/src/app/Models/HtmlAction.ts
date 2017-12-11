export interface HtmlAction {
  id: number;
  name: string;
  DisplayName: string;
  LinkTitle: string;
  ActionName: string;
  ControllerName: string;
  RouteValues?: {} | null;
}

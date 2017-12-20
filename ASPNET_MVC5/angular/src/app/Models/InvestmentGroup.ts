import { GroupsLink } from './investment';
export interface InvestmentGroup {
  id: number;
  name: string;
  description: string;
  type: string;
  investments?: (GroupsLink)[] | null;
}

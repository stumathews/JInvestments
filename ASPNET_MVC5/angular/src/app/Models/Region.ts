export interface Region {
  id: number;
  description: string;
  name: string;
  investments?: (InvestmentsEntity)[] | null;
}
export interface InvestmentsEntity {
  investmentID: number;
  investment?: null;
  regionID: number;
}

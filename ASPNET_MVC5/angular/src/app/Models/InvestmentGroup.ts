export interface InvestmentGroup {
  id: number;
  name: string;
  description: string;
  type: string;
  investments?: (InvestmentsEntity)[] | null;
}
export interface InvestmentsEntity {
  investmentID: number;
  investment?: null;
  investmentGroupID: number;
}

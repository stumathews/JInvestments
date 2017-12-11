export interface InvestmentRisk {
  id: number;
  description: string;
  type: number;
  name: string;
  investments?: (InvestmentsEntity)[] | null;
}
export interface InvestmentsEntity {
  investmentID: number;
  investment?: null;
  investmentRiskID: number;
}

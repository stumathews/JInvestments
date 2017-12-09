export interface InvestmentInfluenceFactor {
  id: number;
  name: string;
  description: string;
  influence: string;
  investments?: (InvestmentsEntity)[] | null;
}
export interface InvestmentsEntity {
  investmentID: number;
  investment?: number | null;
  investmentInfluenceFactorID: number;
}

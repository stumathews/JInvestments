export interface Investment {
  id: number;
  description: string;
  symbol: string;
  valueProposition: string;
  desirabilityStatement: string;
  initialInvestment: number;
  name: string;
  value: number;
  factors?: (FactorsEntity)[] | null;
  regions?: (RegionsEntity)[] | null;
  risks?: (RisksEntity)[] | null;
  groups?: (GroupsEntity)[] | null;
}
export interface FactorsEntity {
  investmentID: number;
  investmentInfluenceFactorID: number;
  investmentInfluenceFactor?: null;
}
export interface RegionsEntity {
  investmentID: number;
  regionID: number;
  region?: null;
}
export interface RisksEntity {
  investmentID: number;
  investmentRiskID: number;
  investmentRisk?: null;
}
export interface GroupsEntity {
  investmentID: number;
  investmentGroupID: number;
  investmentGroup?: null;
}

export interface Investment {
  id: number;
  description: string;
  symbol: string;
  valueProposition: string;
  desirabilityStatement: string;
  initialInvestment: number;
  name: string;
  value: number;
  factors?: (FactorsLink)[] | null;
  regions?: (RegionsLink)[] | null;
  risks?: (RisksLink)[] | null;
  groups?: (GroupsLink)[] | null;
}
export interface FactorsLink {
  investmentID: number;
  investmentInfluenceFactorID: number;
  investmentInfluenceFactor?: null;
}
export interface RegionsLink {
  investmentID: number;
  regionID: number;
  region?: null;
}
export interface RisksLink {
  investmentID: number;
  investmentRiskID: number;
  investmentRisk?: null;
}
export interface GroupsLink {
  investmentID: number;
  investmentGroupID: number;
  investmentGroup?: null;
}

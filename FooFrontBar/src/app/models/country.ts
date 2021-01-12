import { CountryHistory } from './country-history';

export class Country {
  guid: string;
  name: string;
  code: string;
  total: number;
  active: number;
  death: number;
  recovered: number;
  history: CountryHistory[];
}

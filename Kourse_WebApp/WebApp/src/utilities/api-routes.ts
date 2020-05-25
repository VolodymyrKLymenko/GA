import { environment } from 'src/environments/environment';

export const ApiGARoutes = {
    calculate: `${environment.gaServerUrl}/calculations/bestroute`,
    statistic: `${environment.gaServerUrl}/calculations/statistic`
};

import { environment } from 'src/environments/environment';

export const ApiRoutes = {
    governments: `${environment.openDataServerUrl}/ogd/zpr/list.json`,

    laws: `${environment.openDataServerUrl}/ogd/zpr`,
};

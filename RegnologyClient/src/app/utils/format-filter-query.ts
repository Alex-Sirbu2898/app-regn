export function formatQueryString(queryParam: string): string {
    return queryParam == '' ? '' : '?' + queryParam;
}
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  timeOut: 60000,
  url: 'http://localhost:52751/',
  services: {
    list: 'api/employees',
    get: 'api/employees/'
  }
};

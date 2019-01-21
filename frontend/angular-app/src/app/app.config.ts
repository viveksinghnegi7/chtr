export interface Configuration {
    apiURL: string;
    signalRBase: string;
  }
  
  export const CONFIG: Configuration = {
    apiURL: 'http://localhost:57256/api',
    signalRBase: 'http://localhost:57256'
  };
  
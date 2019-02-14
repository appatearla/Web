import auth0 from 'auth0-js';
import Vue from 'vue';
import { AUTH_CONFIG } from './auth0-variables';

const webAuth = new auth0.WebAuth({
  domain: AUTH_CONFIG.domain,
  clientID: AUTH_CONFIG.clientId,
  redirectUri: AUTH_CONFIG.callbackUrl,
  // we will use the api/v2/ to access the user information as payload
  audience: 'https://appatearla.auth0.com/api/v2/',
  responseType: 'token id_token',
  scope: 'openid profile',
});

export class AuthService extends Vue {
  get token(): string {
    return localStorage.getItem('id_token') as string;
  }
  set token(idToken) {
    localStorage.setItem('id_token', idToken);
  }
  get accessToken(): string {
    return localStorage.getItem('access_token') as string;
  }
  set accessToken(accessToken: string) {
    localStorage.setItem('access_token', accessToken);
  }

  get expiresAt(): number {
    return parseInt(localStorage.getItem('expires_at') as string, undefined);
  }
  set expiresAt(expiresIn: number) {
    const expiresAt = JSON.stringify(expiresIn * 1000 + new Date().getTime());
    localStorage.setItem('expires_at', expiresAt);
  }
  get user() {
    return JSON.parse(localStorage.getItem('user') as string);
  }
  set user(user) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  public login() {
    webAuth.authorize();
  }

  public logout() {
    return new Promise((resolve, reject) => {
      localStorage.removeItem('access_token');
      localStorage.removeItem('id_token');
      localStorage.removeItem('expires_at');
      localStorage.removeItem('user');
      webAuth.logout({
        returnTo: AUTH_CONFIG.returnTo, // Allowed logout URL listed in dashboard
        clientID: AUTH_CONFIG.clientId, // Your client ID
      });
    });
  }

  public isAuthenticated() {
    return new Date().getTime() < this.expiresAt;
  }

  public handleAuthentication() {
    return new Promise((resolve, reject) => {
      webAuth.parseHash((err, authResult) => {
        if (authResult && authResult.accessToken && authResult.idToken) {
          this.expiresAt = authResult.expiresIn as number;
          this.accessToken = authResult.accessToken;
          this.token = authResult.idToken;
          this.user = authResult.idTokenPayload;
          resolve();
        } else if (err) {
          this.logout();
          reject(err);
        }
      });
    });
  }
}

export default {
  install: (Vue: any) => {
    Vue.prototype.$auth = new AuthService();
  },
};

declare module 'vue/types/vue' {
  interface Vue {
    $auth: AuthService;
  }
}

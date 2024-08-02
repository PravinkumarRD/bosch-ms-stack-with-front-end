import { HttpHeaders, HttpInterceptorFn } from '@angular/common/http';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  if (!req.url.includes('authenticate')) {
    const headers = req.headers
        .set('Content-Type', 'application/json')
        .set('Authorization',`Bearer ${localStorage.getItem('token')}`)
        //.set('bosch-authorization-token', `${localStorage.getItem('token')}`);
      const authReq = req.clone({ headers });
      return next(authReq);
  }
  return next(req);
};

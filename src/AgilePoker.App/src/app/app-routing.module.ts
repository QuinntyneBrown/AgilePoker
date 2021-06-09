import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{ path: 'workspace', loadChildren: () => import('./workspace/workspace.module').then(m => m.WorkspaceModule) }, { path: 'landing', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) }, { path: 'not-found', loadChildren: () => import('./not-found/not-found.module').then(m => m.NotFoundModule) }, { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

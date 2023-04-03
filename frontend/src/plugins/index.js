import { loadFonts } from './webfontloader'
import { registerLayouts } from '../layouts/register'

import vuetify from './vuetify'
import router from '../router'

export function registerPlugins(app) {
  loadFonts()
  
  app
    .use(vuetify)
    .use(router)
  
  registerLayouts(app)
}

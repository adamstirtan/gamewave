import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

import { createVuetify } from 'vuetify'

export default createVuetify({
  theme: {
    themes: {
      light: {
        colors: {
          primary: '#016FB9',
          secondary: '#E7EAEE',
          header: '#EEEEEE',
          success: '#60992D'
        }
      }
    }
  }
})

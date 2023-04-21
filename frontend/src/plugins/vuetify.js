import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

import { createVuetify } from 'vuetify'

export default createVuetify({
  theme: {
    themes: {
      light: {
        colors: {
          primary: '#016FB9',
          secondary: '#CFD5DD',
          header: '#E7EAEE',
          success: '#60992D'
        }
      }
    }
  }
})

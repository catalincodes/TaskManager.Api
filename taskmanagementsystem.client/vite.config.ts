import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    port: 5118,
    proxy: {
      '/api': {
        // This pulls DIRECTLY from what is exported in the process of dev.sh
        target: process.env.VITE_API_TARGET || 'http://localhost:5113',
        changeOrigin: true,
        secure: false
      }
    }
  }
})

import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfileService {
  async getProfile() {
    try {
      const res = await api.get('/profile')
      AppState.profile = res.data
      logger.log('profile', AppState.profile)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getWishlists() {
    try {
      var id = AppState.profile.id
      logger.log('ps id', id)
      const res = await api.get('/profile/' + id + '/wishlists')
      AppState.wishlists = res.data
      logger.log('profile service', AppState.wishlists)
    } catch (e) {
      logger.log('Profile Serviece', e)
    }
  }
}

export const profileService = new ProfileService()

import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'
import { AppState } from '../AppState'

class WishlistService {
  async createWishlist(nw) {
    try {
      const res = await api.post('api/wishlists', nw)
      logger.log('fe service', res.data)
    } catch (e) {
      logger.log(e)
    }
  }

  async getWishlists() {
    try {
      const res = await api.get('api/wishlists')
      AppState.wishlists = res.data
      logger.log('ws', res.data)
    } catch (e) {
      logger.log(e)
    }
  }

  async addToWishlist(wId, pId) {
    try {
      const newWp = {
        WishlistId: wId,
        ProductId: pId
      }
      const res = await api.post('api/wishlistproducts', newWp)
      logger.log('w.s.', res.data)
    } catch (e) {
      logger.log(e)
    }
  }
}

export const wishlistService = new WishlistService()

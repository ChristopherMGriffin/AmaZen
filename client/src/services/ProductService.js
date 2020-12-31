import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class ProductService {
  async create(np) {
    try {
      const res = await api.post('api/products', np)
      logger.log(res.data)
      this.getAll()
    } catch (e) {
      logger.log(e)
    }
  }

  async deleteProduct(id) {
    try {
      const res = await api.delete('api/products/' + id)
      logger.log(res)
      this.getAll()
    } catch (e) {
      logger.log(e)
    }
  }

  async getAll() {
    try {
      const res = await api.get('api/products')
      AppState.products = res.data
      logger.log('products', AppState.products)
    } catch (e) {
      logger.log(e)
    }
  }

  async getOne(id) {
    try {
      const res = await api.get('api/products/' + id)
      AppState.activeProduct = res.data
    } catch (e) {
      logger.log(e)
    }
  }
}

export const productService = new ProductService()

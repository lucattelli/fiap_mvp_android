package net.azurewebsites.digitalsmartcrafters.smartmarket

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query
import java.util.*

interface RetrofitConsultaListaCompraItemService {
    //http://smartmarketwebapi.azurewebsites.net/ConsultaListaCompraItem
    @GET("ConsultaListaCompraItem")
    fun listar(@Query("idListaCompra") idListaCompra: Int,
               @Query("idMercado") idMercado: Int,
               @Query("dataCriacao") dataCriacao: Calendar) : Call<ConsultaListaCompraItem>

    @GET("ConsultaListaCompra")
    fun consultar(@Query("idListaCompra") idListaCompra: Int,
                  @Query("idMercado") idMercado: Int,
                  @Query("dataCriacao") dataCriacao: Calendar,
                  @Query("idProduto") idProduto: Int) : Call<ConsultaListaCompraItem>
}
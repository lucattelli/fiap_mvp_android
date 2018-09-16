package net.azurewebsites.digitalsmartcrafters.smartmarket

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query
import java.util.*

interface RetrofitConsultaListaCompraService {
    //http://smartmarketwebapi.azurewebsites.net/ConsultaListaCompra
    @GET("ConsultaListaCompra")
    fun listar(@Query("idListaCompra") idListaCompra: Int) : Call<ConsultaListaCompra>

    @GET("ConsultaListaCompra")
    fun consultar(@Query("idListaCompra") idListaCompra: Int,
                  @Query("idMercado") idMercado: Int,
                  @Query("dataCriacao") dataCriacao: Calendar) : Call<ConsultaListaCompra>
}
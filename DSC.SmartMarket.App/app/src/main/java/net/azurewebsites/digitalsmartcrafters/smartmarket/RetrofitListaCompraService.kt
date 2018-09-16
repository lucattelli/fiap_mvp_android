package net.azurewebsites.digitalsmartcrafters.smartmarket

import okhttp3.ResponseBody
import retrofit2.Call
import retrofit2.http.*

interface RetrofitListaCompraService {
        //http://smartmarketwebapi.azurewebsites.net/ListaCompra
        @GET("ListaCompra")
        fun listar(@Query("idCliente") idCliente: Int) : Call<ListaCompra>

        @GET("ListaCompra")
        fun consultar(@Query("idListaCompra") idListaCompra: Int) : Call<ListaCompra>

        @PUT("ListaCompra")
        fun incluir(@Body() listaCompra: ListaCompra) : Call<ResponseBody>

        @POST("ListaCompra")
        fun alterar(@Body() listaCompra: ListaCompra) : Call<ResponseBody>

        @DELETE("ListaCompra")
        fun excluir(@Query("idListaCompra") idListaCompra: Int) : Call<ResponseBody>

    }
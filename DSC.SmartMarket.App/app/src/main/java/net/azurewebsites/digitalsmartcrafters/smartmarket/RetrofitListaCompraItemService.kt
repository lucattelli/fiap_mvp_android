package net.azurewebsites.digitalsmartcrafters.smartmarket

import okhttp3.ResponseBody
import retrofit2.Call
import retrofit2.http.*

interface RetrofitListaCompraItemService {
    //http://smartmarketwebapi.azurewebsites.net/ListaCompraItem
    @GET("ListaCompraItem")
    fun listar(@Query("idListaCompra") idListaCompra: Int) : Call<ListaCompraItem>

    @GET("ListaCompraItem")
    fun consultar(@Query("idListaCompra") idListaCompra: Int, @Query("idProduto") idProduto: Int) : Call<ListaCompraItem>

    @PUT("ListaCompraItem")
    fun incluir(@Body() listaCompraItem: ListaCompraItem) : Call<ResponseBody>

    @POST("ListaCompraItem")
    fun alterar(@Body() listaCompraItem: ListaCompraItem) : Call<ResponseBody>

    @DELETE("ListaCompraItem")
    fun excluir(@Query("idListaCompra") idListaCompra: Int, @Query("idProduto") idProduto: Int) : Call<ResponseBody>
}
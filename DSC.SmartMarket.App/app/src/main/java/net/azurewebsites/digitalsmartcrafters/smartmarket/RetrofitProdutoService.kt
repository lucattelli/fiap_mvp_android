package net.azurewebsites.digitalsmartcrafters.smartmarket

import okhttp3.ResponseBody
import retrofit2.Call
import retrofit2.http.*

interface RetrofitProdutoService {
    //http://smartmarketwebapi.azurewebsites.net/Produto
    @GET("Produto")
    fun listar() : Call<Produto>

    @GET("Produto")
    fun consultar(@Query("id") id: Int) : Call<Produto>

    @PUT("Produto")
    fun incluir(@Body() produto: Produto) : Call<ResponseBody>

    @POST("Produto")
    fun alterar(@Body() produto: Produto) : Call<ResponseBody>

    @DELETE("Produto")
    fun excluir(@Query("id") id: Int) :     Call<ResponseBody>

}
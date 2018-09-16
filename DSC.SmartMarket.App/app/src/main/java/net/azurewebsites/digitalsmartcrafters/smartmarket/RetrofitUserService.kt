package net.azurewebsites.digitalsmartcrafters.smartmarket

import okhttp3.ResponseBody
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.PUT
import retrofit2.http.Query

interface RetrofitUserService {

    //http://smartmarketwebapi.azurewebsites.net/usuario?email=lucas2@produweb.com.br&senha=123456
    @GET("usuario")
    fun doLogin(@Query("email") email: String, @Query("senha") senha: String) : Call<User>

    @PUT("usuario")
    fun createUser(@Body() user: User) : Call<ResponseBody>

}
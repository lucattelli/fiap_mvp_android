package net.azurewebsites.digitalsmartcrafters.smartmarket

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class RetrofitFactory {

    val URL: String = "http://smartmarketwebapi.azurewebsites.net/"
    val retrofitFactory = Retrofit.Builder()
            .baseUrl(URL)
            .addConverterFactory(GsonConverterFactory.create())
            .build()
    fun RetrofitUserService(): RetrofitUserService {
        return retrofitFactory.create(RetrofitUserService::class.java)
    }

}
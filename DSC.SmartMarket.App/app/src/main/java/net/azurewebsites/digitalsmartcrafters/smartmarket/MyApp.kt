package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.app.Application

class MyApp : Application() {

    private var user: User? = null

    fun getUser() : User {
        return user!!
    }

    fun setUser(u : User) {
        user = u
    }

}
package net.azurewebsites.digitalsmartcrafters.smartmarket

import com.google.gson.annotations.SerializedName

data class User (
    @SerializedName("Id") val id: Long,
    @SerializedName("Nome") val nome: String,
    @SerializedName("Email") val email: String,
    @SerializedName("Senha") val senha: String,
    @SerializedName("Cliente") val cliente: Client
)
package net.azurewebsites.digitalsmartcrafters.smartmarket

import com.google.gson.annotations.SerializedName

class Client (
    @SerializedName("Id") val id: Long,
    @SerializedName("Nome") val nome: String,
    @SerializedName("CPF") val cpf: String,
    @SerializedName("RG") val rg: String,
    @SerializedName("Email") val email: String,
    @SerializedName("Telefone") val telefone: String
)
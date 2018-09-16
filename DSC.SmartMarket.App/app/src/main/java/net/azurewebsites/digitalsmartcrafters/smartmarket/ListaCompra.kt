package net.azurewebsites.digitalsmartcrafters.smartmarket

import com.google.gson.annotations.SerializedName
import java.util.*

data class ListaCompra (
    @SerializedName("Id") val id: Int,
    @SerializedName("Descricao") val descricao: String,
    @SerializedName("DataCriacao") val dataCriacao: Calendar,
    @SerializedName("DataUltimaConsulta") val dataUltimaConsulta: Calendar,
    @SerializedName("QuantidadeItem") val quantidadeItem: Int
)
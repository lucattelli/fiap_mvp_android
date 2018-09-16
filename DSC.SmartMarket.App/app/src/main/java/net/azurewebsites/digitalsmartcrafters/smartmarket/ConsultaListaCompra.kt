package net.azurewebsites.digitalsmartcrafters.smartmarket

import com.google.gson.annotations.SerializedName
import java.util.*

data class ConsultaListaCompra (
    @SerializedName("IdListaCompra") val idListaCompra: Int,
    @SerializedName("IdMercado") val idMercado: Int,
    @SerializedName("DataCriacao") val dataCriacao: Calendar,
    @SerializedName("ValorTotal") val valorTotal: Float,
    @SerializedName("ListaCompra") val listaCompra: ListaCompra
)
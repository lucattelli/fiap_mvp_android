package net.azurewebsites.digitalsmartcrafters.smartmarket

import com.google.gson.annotations.SerializedName
import java.util.*

data class ConsultaListaCompraItem (
        @SerializedName("IdListaCompra") val idListaCompra: Int,
        @SerializedName("IdMercado") val idMercado: Int,
        @SerializedName("DataCriacao") val dataCriacao: Calendar,
        @SerializedName("IdProduto") val idProduto: Int,
        @SerializedName("ValorProduto") val valorProduto: Float,
        @SerializedName("Quantidade") val quantidade: Int,
        @SerializedName("Disponivel") val disponivel: Int,
        @SerializedName("ListaCompraItem") val listaCompraItem: ListaCompraItem
)
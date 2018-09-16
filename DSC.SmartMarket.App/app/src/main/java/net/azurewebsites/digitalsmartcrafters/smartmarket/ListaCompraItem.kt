package net.azurewebsites.digitalsmartcrafters.smartmarket

import com.google.gson.annotations.SerializedName
import java.util.*

data class ListaCompraItem (
    @SerializedName("IdListaCompra") val idListaCompra: Int,
    @SerializedName("IdProduto") val idProduto: Int,
    @SerializedName("Quantidade") val quantidade: Int,
    @SerializedName("Produto") val produto: Produto
)
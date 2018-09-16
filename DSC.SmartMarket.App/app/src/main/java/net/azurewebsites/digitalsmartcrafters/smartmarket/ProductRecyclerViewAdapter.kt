package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageButton
import android.widget.TextView
import android.widget.Toast
import kotlinx.android.synthetic.main.products_recycler_item.view.*
import java.nio.file.Files.delete



class ProductRecyclerViewAdapter(val productList: ArrayList<Product>) : RecyclerView.Adapter<ProductRecyclerViewAdapter.ViewHolder>() {

    override fun getItemCount(): Int {
        return productList.size
    }

    override fun onBindViewHolder(vh: ViewHolder, item: Int) {
        val product: Product = productList[item]
        vh.textViewProductName.setText(product.name)
        vh.textViewProductQuantity.setText("Quantidade " + product.quantity.toString())
        vh.buttonDelete.setOnClickListener(View.OnClickListener {
            val idx = productList.indexOf(product)
            productList.remove(product)
            notifyItemRemoved(idx)
        })
    }

    override fun onCreateViewHolder(vg: ViewGroup, item: Int): ViewHolder {
        var view = LayoutInflater.from(vg.context).inflate(R.layout.products_recycler_item, vg, false)
        return ViewHolder(view)
    }

    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val textViewProductName = itemView.textViewProductName as TextView
        val textViewProductQuantity = itemView.textViewProductQuantity as TextView
        val buttonDelete = itemView.buttonDelete as ImageButton
    }

}
package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.Toast
import kotlinx.android.synthetic.main.fragment_products.*
import kotlinx.android.synthetic.main.fragment_products.view.*

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
private const val ARG_PARAM1 = "param1"
private const val ARG_PARAM2 = "param2"

/**
 * A simple [Fragment] subclass.
 *
 */
class ProductsFragment : Fragment() {

    private lateinit var linearLayoutManager: LinearLayoutManager

    private var mProducts = ArrayList<Product>()

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        val view = inflater.inflate(R.layout.fragment_products, container, false)
        return view
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)
        if (mProducts.size > 0) {
            initializeProductRecycler()
        }
        search_action.setOnClickListener {
            val toast = Toast.makeText(context, "Click works!", Toast.LENGTH_SHORT)
            toast.show()
            mProducts.add(Product((mProducts.size + 1).toLong(), "Produto " + mProducts.size.toString(), mProducts.size.toLong()))
            if (this.products_recycler.adapter == null) {
                initializeProductRecycler()
            } else {
                this.products_recycler.adapter?.notifyDataSetChanged()
            }
        }
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
    }

    private fun initializeProductRecycler(){
        products_recycler.layoutManager = LinearLayoutManager(context, LinearLayout.VERTICAL, false)
        products_recycler.adapter = ProductRecyclerViewAdapter(mProducts)
        products_recycler.visibility = RecyclerView.VISIBLE
        products_no_products.visibility = TextView.INVISIBLE
    }

}

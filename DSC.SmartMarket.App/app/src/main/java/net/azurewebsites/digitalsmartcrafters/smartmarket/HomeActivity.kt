package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.support.design.widget.BottomNavigationView
import android.support.v4.app.Fragment
import android.support.v4.app.FragmentTransaction
import android.widget.FrameLayout
import kotlinx.android.synthetic.main.activity_home.*

class HomeActivity : AppCompatActivity() {

    private var mProductsFragment: ProductsFragment? = null
    private var mCartFragment: CartFragment? = null
    private var mNearMeFragment: NearMeFragment? = null
    private var mSettingsFragment: SettingsFragment? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home)

        mProductsFragment = ProductsFragment()
        mCartFragment = CartFragment()
        mNearMeFragment = NearMeFragment()
        mSettingsFragment = SettingsFragment()

        main_nav.setOnNavigationItemSelectedListener { item ->
            when (item.itemId) {
                R.id.nav_products -> {
                    setTitle(R.string.nav_products_title)
                    setFragement(mProductsFragment!!)
                    return@setOnNavigationItemSelectedListener true
                }
                R.id.nav_cart -> {
                    setTitle(getString(R.string.nav_cart_title))
                    setFragement(mCartFragment!!)
                    return@setOnNavigationItemSelectedListener true
                }
                R.id.nav_nearme -> {
                    setTitle(getString(R.string.nav_nearme_title))
                    setFragement(mNearMeFragment!!)
                    return@setOnNavigationItemSelectedListener true
                }
                R.id.nav_settings -> {
                    setTitle(getString(R.string.nav_settings_title))
                    setFragement(mSettingsFragment!!)
                    return@setOnNavigationItemSelectedListener true
                }
            }
            false
        }

        main_nav.setSelectedItemId(R.id.nav_products)

    }

    private fun setFragement(fragment: Fragment) {
        var fragmentTransaction: FragmentTransaction? = supportFragmentManager.beginTransaction()
        fragmentTransaction?.replace(R.id.main_frame, fragment)
        fragmentTransaction?.commit()
    }


}

package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.content.Intent
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Toast

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun loginOnClick(view: View) {
        val loginIntent = Intent(this, LoginActivity::class.java);
        startActivity(loginIntent)
    }

    fun signupOnClick(view: View) {
        val signupIntent = Intent(this, SignupActivity::class.java)
        startActivity(signupIntent)
    }

}

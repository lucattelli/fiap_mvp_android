package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.animation.Animator
import android.animation.AnimatorListenerAdapter
import android.annotation.TargetApi
import android.support.v7.app.AppCompatActivity
import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.text.TextUtils
import android.util.Log
import android.view.View
import android.widget.Toast
import kotlinx.android.synthetic.main.activity_login.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class LoginActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)
        /**
        email.setText("lucas3@produweb.com.br")
        password.setText("123456")
        */
    }

    fun attemptLogin(view: View) {
        if (ifFormValid()) {
            showProgress(true)
            val call = RetrofitFactory().RetrofitUserService().doLogin(email.text.toString(), password.text.toString())
            call.enqueue(object: Callback<User> {
                override fun onResponse(call: Call<User>, response: Response<User>) {
                    showProgress(false)
                    val user = response.body()
                    val errorBody = response.errorBody()
                    if (user != null) {
                        var app = applicationContext as MyApp
                        app.setUser(user)
                        var h = Intent(applicationContext, HomeActivity::class.java)
                        h.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP or Intent.FLAG_ACTIVITY_CLEAR_TASK or Intent.FLAG_ACTIVITY_NEW_TASK)
                        startActivity(h)
                        finish()
                    } else {
                        email.error = getString(R.string.error_incorrect_password)
                        email.requestFocus()
                    }
                }
                override fun onFailure(call: Call<User>?, t: Throwable?) {
                    showProgress(false)
                    Log.e("Erro", t?.message)
                    val toast = Toast.makeText(applicationContext, R.string.error_login, Toast.LENGTH_SHORT)
                    toast.show()
                }
            })
        }
    }

    private fun ifFormValid(): Boolean {

        email.error = null
        password.error = null

        var cancel = false
        var focusView: View? = null

        val emailStr = email.text.toString()
        if (TextUtils.isEmpty(emailStr)) {
            email.error = getString(R.string.error_field_required)
            focusView = email
            cancel = true
        }

        val passwordStr = password.text.toString()
        if (!emailStr.contains("@")) {
            email.error = getString(R.string.error_invalid_email)
            focusView = email
            cancel = true
        }

        if (cancel) {
            focusView?.requestFocus()
            return false
        } else {
            return true
        }
    }

    @TargetApi(Build.VERSION_CODES.HONEYCOMB_MR2)
    private fun showProgress(show: Boolean) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            val shortAnimTime = resources.getInteger(android.R.integer.config_shortAnimTime).toLong()
            login_form.visibility = if (show) View.GONE else View.VISIBLE
            login_form.animate()
                    .setDuration(shortAnimTime)
                    .alpha((if (show) 0 else 1).toFloat())
                    .setListener(object : AnimatorListenerAdapter() {
                        override fun onAnimationEnd(animation: Animator) {
                            login_form.visibility = if (show) View.GONE else View.VISIBLE
                        }
                    })
            login_progress.visibility = if (show) View.VISIBLE else View.GONE
            login_progress.animate()
                    .setDuration(shortAnimTime)
                    .alpha((if (show) 1 else 0).toFloat())
                    .setListener(object : AnimatorListenerAdapter() {
                        override fun onAnimationEnd(animation: Animator) {
                            login_progress.visibility = if (show) View.VISIBLE else View.GONE
                        }
                    })
        } else {
            login_progress.visibility = if (show) View.VISIBLE else View.GONE
            login_form.visibility = if (show) View.GONE else View.VISIBLE
        }
    }
}

package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.animation.Animator
import android.animation.AnimatorListenerAdapter
import android.annotation.TargetApi
import android.content.Intent
import android.os.Build
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.EditText
import android.widget.Toast
import kotlinx.android.synthetic.main.activity_login.*
import kotlinx.android.synthetic.main.activity_signup.*
import okhttp3.ResponseBody
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import org.json.JSONObject



class SignupActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_signup)
        /**
        signupNome.setText("Lucas Miranda Andrade 4")
        signupEmail.setText("lucas4@produweb.com.br")
        signupConfirmEmail.setText(signupEmail.text)
        signupSenha.setText("123456")
        signupConfirmSenha.setText(signupSenha.text)
        signupRG.setText("47740084X")
        signupCPF.setText("83122250055")
        signupTelefone.setText("11988887777")
        */
    }

    fun confirmarOnClick(view: View) {
        if (isFormValid()) {
            showProgress(true)
            var client = getClient()
            var user = getUser(client)
            val call = RetrofitFactory().RetrofitUserService().createUser(user)
            call.enqueue(object: Callback<ResponseBody> {
                override fun onResponse(call: Call<ResponseBody>, response: Response<ResponseBody>) {
                    showProgress(false)
                    if (response.isSuccessful) {    //if (user != null) {
                        var l = Intent(applicationContext, LoginActivity::class.java)
                        l.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP or Intent.FLAG_ACTIVITY_CLEAR_TASK or Intent.FLAG_ACTIVITY_NEW_TASK)
                        startActivity(l)
                        finish()
                        Toast.makeText(applicationContext, "Cadastro Realizado! Faça o Login.", Toast.LENGTH_LONG).show()
                    } else {
                        try {
                            val jObjError = JSONObject(response.errorBody()?.string())
                            Toast.makeText(applicationContext, jObjError.getString("Message"), Toast.LENGTH_LONG).show()
                        } catch (e: Exception) {
                            Toast.makeText(applicationContext, e.message, Toast.LENGTH_LONG).show()
                        }
                    }
                }
                override fun onFailure(call: Call<ResponseBody>?, t: Throwable?) {
                    showProgress(false)
                    Log.e("Erro", t?.message)
                    val toast = Toast.makeText(applicationContext, R.string.error_login, Toast.LENGTH_SHORT)
                    toast.show()
                }
            })
        }
    }

    private fun isFormValid() : Boolean {
        cleanupErrors()
        if (!validateFieldNotEmpty(signupNome, "Nome")) {
            return false
        }
        if (!validateFieldNotEmpty(signupEmail, "E-mail")) {
            return false
        }
        if (!validateFieldNotEmpty(signupConfirmEmail, "Confirmar o E-mail")) {
            return false
        }
        if (!validateFieldNotEmpty(signupSenha, "Senha")) {
            return false
        }
        if (!validateFieldNotEmpty(signupConfirmSenha, "Confirmar a Senha")) {
            return false
        }
        if (!validateFieldNotEmpty(signupRG, "RG")) {
            return false
        }
        if (!validateFieldNotEmpty(signupCPF, "CPF")) {
            return false
        }
        if (!validateFieldNotEmpty(signupTelefone, "Telefone")) {
            return false
        }
        return true
    }

    private fun cleanupErrors() {
        signupNome.error = null
        signupEmail.error = null
        signupConfirmEmail.error = null
        signupSenha.error = null
        signupConfirmSenha.error = null
        signupRG.error = null
        signupCPF.error = null
        signupTelefone.error = null
    }

    private fun validateFieldNotEmpty(field : EditText, description: String): Boolean {
        if (field.text.toString().equals("")) {
            field.error = description + " é obrigatório"
            return false
        } else {
            return true
        }
    }

    private fun getClient() : Client {
        return Client(
                id = 0,
                nome = signupNome.text.toString(),
                email = signupEmail.text.toString(),
                rg = signupRG.text.toString(),
                cpf = signupCPF.text.toString(),
                telefone = signupTelefone.text.toString())
    }

    private fun getUser(client : Client) : User {
        return User(
                id = 0,
                nome = signupNome.text.toString(),
                email = signupEmail.text.toString(),
                senha = signupSenha.text.toString(),
                cliente = client)
    }

    @TargetApi(Build.VERSION_CODES.HONEYCOMB_MR2)
    private fun showProgress(show: Boolean) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            val shortAnimTime = resources.getInteger(android.R.integer.config_shortAnimTime).toLong()
            signupForm.visibility = if (show) View.GONE else View.VISIBLE
            signupForm.animate()
                    .setDuration(shortAnimTime)
                    .alpha((if (show) 0 else 1).toFloat())
                    .setListener(object : AnimatorListenerAdapter() {
                        override fun onAnimationEnd(animation: Animator) {
                            signupForm.visibility = if (show) View.GONE else View.VISIBLE
                        }
                    })
            signup_progress.visibility = if (show) View.VISIBLE else View.GONE
            signup_progress.animate()
                    .setDuration(shortAnimTime)
                    .alpha((if (show) 1 else 0).toFloat())
                    .setListener(object : AnimatorListenerAdapter() {
                        override fun onAnimationEnd(animation: Animator) {
                            signup_progress.visibility = if (show) View.VISIBLE else View.GONE
                        }
                    })
        } else {
            signup_progress.visibility = if (show) View.VISIBLE else View.GONE
            signupForm.visibility = if (show) View.GONE else View.VISIBLE
        }
    }

}

package net.azurewebsites.digitalsmartcrafters.smartmarket

import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import kotlinx.android.synthetic.main.fragment_settings.*

class SettingsFragment : Fragment() {

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        return inflater.inflate(R.layout.fragment_settings, container, false)
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)
        var app = activity?.applicationContext as MyApp
        user_name.setText(app.getUser().nome.toString())
        user_email.setText(app.getUser().email.toString())
        user_rg.setText(app.getUser().cliente.rg.toString())
        user_cpf.setText(app.getUser().cliente.cpf.toString())
        user_telefone.setText(app.getUser().cliente.telefone.toString())
    }


}
